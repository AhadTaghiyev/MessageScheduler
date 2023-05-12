using FluentValidation.AspNetCore;
using MessageScheduler.Core.Abstactions.Repositories.ReadRepositories;
using MessageScheduler.Core.Abstactions.Repositories.WriteRepositories;
using MessageScheduler.Data.Contexs;
using MessageScheduler.Data.Repositories.ReadRepositories;
using MessageScheduler.Data.Repositories.WriteRepositories;
using MessageScheduler.Service.Dtos.MessageDto;
using MessageScheduler.Service.Extensions;
using MessageScheduler.Service.ServiceRegisterations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});
builder.Services.AddServiceRegistration(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
