using APIStreamingUTHG1.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var stringConnection = builder.Configuration.GetConnectionString("defaultConnection");

builder.Services.AddDbContext<ModelContext>(x =>
x.UseOracle(
        stringConnection,
        options => options.UseOracleSQLCompatibility("11")
    )
);


// Controladores pendientes
// Historial, Resumen, ValoracionesYComentario

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


