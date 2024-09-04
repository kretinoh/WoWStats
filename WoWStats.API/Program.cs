using WoWStats.API.Models.Config;

var builder = WebApplication.CreateBuilder(args);

//Cargar configuración de OAuth en el contenedor
builder.Services.Configure<OAuthSettings>(builder.Configuration.GetSection("OAuthSettings"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
