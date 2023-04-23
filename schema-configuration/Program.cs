using MongoDB.Driver;
using schema_configuration;

var builder = WebApplication.CreateBuilder(args);


var connectionString = Environment.GetEnvironmentVariable("MONGO_SERVER") ?? "0.0.0.0:27017";
// Add services to the container.
var client = new MongoClient($"mongodb://root:example@{connectionString}");
var db = client.GetDatabase("schemas");
builder.Services.AddSingleton<IMongoCollection<SchemaConfiguration>>(db.GetCollection<SchemaConfiguration>("schema-configuration"));


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
