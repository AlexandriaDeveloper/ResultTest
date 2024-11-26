using FluentValidation;
using ResultTest;
using ResultTest.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<FakeData>();
builder.Services.AddScoped<IValidator<Employee>, EmployeeValidation>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// Use middleware to handle Result<T> and Error<T> responses



app.UseAuthorization();

app.MapControllers();

app.Run();
