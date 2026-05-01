using apbdKolokwium1Base.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//dependency injection
builder.Services.AddScoped<ISampleDbService, SampleDbService>();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();