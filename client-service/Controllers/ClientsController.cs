using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace client_service.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IMongoCollection<Client> _collection;

    public ClientsController(IMongoCollection<Client> collection)
    {
        _collection = collection;
    }

    [HttpPost()]
    public async Task<StatusCodeResult> Post([FromBody]Client client)
    {
        var filter = Builders<Client>.Filter.Eq(r => r.Id, client.Id);
        await _collection.ReplaceOneAsync(filter, client, new ReplaceOptions{IsUpsert = true});
        return Ok();
    }
}
