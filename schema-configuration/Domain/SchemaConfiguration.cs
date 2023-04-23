namespace schema_configuration;

public class DateConfiguration {
    public string AttributeName {get;set;}
    public string DateFormat {get;set;}
}

public class ProductsConfiguration {
    public string IdAttribute {get;set;}
    public string NameAttribute {get;set;}
    public string AmmountAttribute {get;set;}
}

public class SchemaConfiguration
{
    public int Id {get;set;}
    public string IdAttribute {get;set;}
    public string NameAttribute {get;set;}
    public DateConfiguration BirthDateAttribute {get;set;}
    public IList<ProductsConfiguration> Products {get;set;} 

}
