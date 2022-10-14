using CursoArquitecturaNet.Application.Interfaces;
using CursoArquitecturaNet.Application.Services;
using CursoArquitecturaNet.Core.Repositories;
using CursoArquitecturaNet.Core.Repositories.Base;
using CursoArquitecturaNet.Infraestructura.Data;
using CursoArquitecturaNet.Infraestructura.Repository;
using CursoArquitecturaNet.Infraestructura.Repository.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<CursoArquitecturaNetContext>(c =>
c.UseInMemoryDatabase("CursoArquitecturaNetConnection"));

builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
