namespace client_service;

public class Product {
    public int Id {get;set;}
    public string Name {get;set;}
    public int Ammount {get;set;}
}

public class Client
{
    public int Id {get;set;}
    public string Name {get;set;}
    public DateTime BirthDate {get;set;}
    public IList<Product> Products {get;set;}

}
