using AluguelMotos.DataBase;
using AluguelMotos.Models;
using AluguelMotos.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRepositorioMotos, RepositorioMotos>();
builder.Services.AddTransient<IRepositorioEntregadores, RepositorioEntregador>();




var app = builder.Build();

// Configure the HTTP request pipeline.
builder.WebHost.UseUrls("http://0.0.0.0:5000");

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
