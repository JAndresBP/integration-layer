using System.Text;
using Newtonsoft.Json.Linq;

namespace parser;

public class Attribute {
    public string SourceName {get;set;}
    public string TarjetName {get;set;}
    public string Format {get;set;}
}

public class SchemaConfiguration
{
    public int Id {get;set;}
    public IList<Attribute> Attributes {get;set;}
}

public class XYZClientService{
    private readonly HttpClient _httpClient;

    public XYZClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateClient(JObject data){
        var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");
        Console.WriteLine($"content : {data.ToString()}");
        var result = await _httpClient.PostAsync("/Clients",content);
        Console.WriteLine($"result : {result.RequestMessage}");
        Console.WriteLine($"result : {result.IsSuccessStatusCode}");
        Console.WriteLine($"result : {result.ReasonPhrase}");
        Console.WriteLine($"result : {result.StatusCode}");
    }
}