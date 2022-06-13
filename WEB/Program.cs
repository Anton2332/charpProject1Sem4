


using Application.Category.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddMediatR(typeof(GetCategoryByIdQuery).GetTypeInfo().Assembly);
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
