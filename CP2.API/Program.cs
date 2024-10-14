using CP2.API.Application.Interfaces;
using CP2.API.Application.Services;
using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Infrastructure.Data.Repositories;
using CP2.API.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(x => {
    x.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddTransient<IVendedorRepository, VendedorRepository>();

builder.Services.AddTransient<IFornecedorApplicationService, FornecedorApplicationService>();
builder.Services.AddTransient<IVendedorApplicationService, VendedorApplicationService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api cp2 rm553791 Jhonatan Sampaio Ferreira",
        Version = "v1",
        Description = "API para cadastro de vendedores e fornecedores"
    });
    c.EnableAnnotations(); // Habilitar anotações no Swagger
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
