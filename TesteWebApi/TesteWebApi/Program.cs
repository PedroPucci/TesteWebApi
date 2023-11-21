using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TesteWebApi.Repository;
using TesteWebApi.Repository.Repository;
using TesteWebApi.Repository.Repository.Interfaces;
using TesteWebApi.Service;
using TesteWebApi.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

builder.Services.AddScoped<IRepositoryUoW, RepositoryUoW>();
builder.Services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

IMapper mapper = new Mappers().Configuration().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<IRepositoryUoW, RepositoryUoW>();
builder.Services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Projeto Teste API",
        Description = "Projeto Teste - ASP.NET Core Web API",
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "development",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
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