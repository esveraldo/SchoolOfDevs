using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolOfDevs.Context;
using SchoolOfDevs.Extensions;
using SchoolOfDevs.Middleware;
using SchoolOfDevs.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRegisterServices();
builder.Services.AddRegisterAutoMapper();
builder.Services.AddConfigToken();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddContext(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddlewate>();

app.UseHttpsRedirection();

//NECESSÁRIO PARA A AUTENTICAÇÃO COM TOKEN(NESSA ORDEM)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
