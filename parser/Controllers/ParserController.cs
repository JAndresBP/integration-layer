using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
namespace parser.Controllers;

[ApiController]
[Route("[controller]")]
public class ParserController : ControllerBase
{
    private readonly IMongoCollection<SchemaConfiguration> _collection;
    private readonly XYZClientService _clientService;

    public ParserController(IMongoCollection<SchemaConfiguration> collection, XYZClientService clientService)
    {
        _collection = collection;
        _clientService = clientService;
    }

    [HttpPost()]
    public async Task<IActionResult> Post([FromQuery] int schemaId)
    {
        try{
            var requestBody = string.Empty;
            var filter = Builders<SchemaConfiguration>.Filter.Eq(r => r.Id, schemaId);
            var schema = _collection.Find<SchemaConfiguration>(filter).FirstOrDefault();

            using(StreamReader sr = new StreamReader(Request.Body)){
                requestBody = await sr.ReadToEndAsync();
            }

            Console.WriteLine(requestBody);

            var sourceObject = JObject.Parse(requestBody);
            Console.WriteLine(sourceObject.ToString());

            JObject tarjetObject = new JObject();

            foreach(var attr in schema.Attributes){
                Console.WriteLine($"attribute source: {attr.SourceName} tarjet : {attr.TarjetName}");
                tarjetObject[attr.TarjetName] = sourceObject?.Value<dynamic>(attr.SourceName);
                Console.WriteLine(tarjetObject.ToString());
            }
            
            
            await _clientService.CreateClient(tarjetObject);
            
            
            return Ok(tarjetObject.ToString());
        }catch(Exception e){
            Console.WriteLine(e.ToString());
           return BadRequest(); 
        }
    }
}
