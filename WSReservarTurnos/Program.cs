using Microsoft.OpenApi.Models;
using WSReservarTurnos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<TurnosService, TurnosService>();
builder.Services.AddScoped<ServiciosService, ServiciosService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Turnos API",
        Description = "ASP.NET Core Web API Turnos",
        Contact = new OpenApiContact
        {
            Name = "Alexander Escobar",
            Email = "<alex.escobar104@hotmail.com>",
            Url = new Uri("https://github.com/AlexanderEscobar104")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
