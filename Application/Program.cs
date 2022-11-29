using Business.Core;
using Business.Facade;
using Business.Interfaces;
using Business.Services;
using Business.Validators;
using Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Contexts;
using Infrastructure.Core;
using Infrastructure.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddHealthChecks();

builder.Services.AddControllersWithViews()
               .AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           ).AddFluentValidation(options =>
           {
               // Validate child properties and root collection elements
               options.ImplicitlyValidateChildProperties = true;
               options.ImplicitlyValidateRootCollectionElements = true;

               // Automatic registration of validators in assembly
               options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
           });




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 

 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
 
builder.Services.AddDbContext<VolvoContext>(options =>
        options.UseSqlServer(connectionString).UseLazyLoadingProxies(false));
 
 
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>)); // repository generic
builder.Services.AddScoped(typeof(IServiceGeneric<>), typeof(ServiceGeneric<>)); // repository generic
builder.Services.AddScoped(typeof(IFacade<>), typeof(Facade<>)); // repository generic

// di vehicle
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
 
// di vehicle model
builder.Services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();

//// di validação
builder.Services.AddScoped<IValidator<Vehicle>, VehicleValidator>();
builder.Services.AddScoped<IValidator<VehicleModel>, VehicleModelValidator>();

builder.Services.AddScoped<IVehicleFacade, VehicleFacade>();
builder.Services.AddScoped<IVehicleModelFacade, VehicleModelFacade>();

 

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
