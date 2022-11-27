using Business.Core;
using Business.Interfaces;
using Business.Services;
using Infrastructure.Contexts;
using Infrastructure.Core;
using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
 
builder.Services.AddDbContext<VolvoContext>(options =>
        options.UseSqlServer(connectionString));




builder.Services.AddScoped<VolvoContext>();
  
 
builder.Services.AddTransient(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>)); // repository generic
builder.Services.AddTransient(typeof(IServiceGeneric<>), typeof(ServiceGeneric<>)); // repository generic

// use transient para recriar a cada request
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
 
builder.Services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();

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
