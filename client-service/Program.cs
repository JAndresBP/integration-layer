using MongoDB.Driver;
using client_service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("MONGO_SERVER") ?? "0.0.0.0:27017";
var user = Environment.GetEnvironmentVariable("MONGO_USERNAME") ?? "root";
var pass = Environment.GetEnvironmentVariable("MONGO_PASSWORD") ?? "example";
// Add services to the container.
var client = new MongoClient($"mongodb://{user}:{pass}@{connectionString}");
var db = client.GetDatabase("centraldb");
builder.Services.AddSingleton<IMongoCollection<Client>>(db.GetCollection<Client>("clients"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
