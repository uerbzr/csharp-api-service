using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Diagnostics;
using workshop.data;
using workshop.data.models;
using workshop.repository;
using workshop.repository.interfaces;
using workshop.service;
using workshop.service.interfaces;
using workshop.wwwapi.Endpoints;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(options => {
    //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("workshop.wwwapi"));
    options.LogTo(message => Debug.WriteLine(message));

});
builder.Services.AddScoped<ICalculatorService, CalculatorService>();
builder.Services.AddScoped<IRepository<Calculation>, Repository<Calculation>>();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}
app.ConfigureCalculatorEndpoints();

app.UseHttpsRedirection();

app.Run();

