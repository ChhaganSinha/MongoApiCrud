using Microsoft.EntityFrameworkCore;
using MongoApiCrud.DataContext;
using MongoApiCrud.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Correct way to read MongoDB config
var mongoSettings = builder.Configuration.GetSection("MongoDbSettings");
var mongoConn = mongoSettings.GetValue<string>("ConnectionString") ?? "mongodb://localhost:27017";
var mongoDb = mongoSettings.GetValue<string>("DatabaseName") ?? "TestDb1";

// ✅ Register MongoDB EF Core context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMongoDB(mongoConn, mongoDb));

// ✅ Register Repository
builder.Services.AddScoped<AppRepository>();

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
