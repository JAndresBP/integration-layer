using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
namespace schema_configuration.Controllers;

[ApiController]
[Route("[controller]")]
public class SchemaConfigurationsController : ControllerBase
{
    private readonly IMongoCollection<SchemaConfiguration> _collection;

    public SchemaConfigurationsController(IMongoCollection<SchemaConfiguration> collection)
    {
        _collection = collection;
    }

    [HttpPost()]
    public async Task<StatusCodeResult> Post(SchemaConfiguration schemaConfiguration)
    {
        var filter = Builders<SchemaConfiguration>.Filter.Eq(r => r.Id, schemaConfiguration.Id);
        await _collection.ReplaceOneAsync(filter, schemaConfiguration, new ReplaceOptions{IsUpsert = true});
        return Ok();
    }
}
