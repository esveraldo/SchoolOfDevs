using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolOfDevs.Context;
using SchoolOfDevs.Extensions;
using SchoolOfDevs.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddContext(builder.Configuration);
builder.Services.AddRegisterServices();
builder.Services.AddRegisterAutoMapper(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddlewate>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
