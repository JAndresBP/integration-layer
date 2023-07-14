namespace schema_configuration;
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
