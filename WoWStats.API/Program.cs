using WoWStats.API.Models.Config;

var builder = WebApplication.CreateBuilder(args);

//Cargar configuración de OAuth en el contenedor
builder.Services.Configure<OAuthSettings>(builder.Configuration.GetSection("OAuthSettings"));

//Config Redis distributed cache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis"); // Usa la conexión a Redis desde appsettings.json
    options.InstanceName = "WoWStats_"; // Opcional, prefijo para las keys en Redis
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
