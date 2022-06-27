using Avanade.IT.ChallengeSE.Api.Configurations;
using Avanade.IT.ChallengeSE.Application.Mappers;
using Avanade.IT.ChallengeSE.CrossCuting.DependencyInjection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersSetup();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerSetup();
builder.Services.AddDatabaseSetup(builder.Configuration, builder.Environment);
builder.Services.AddDependencyInjectionSetup();
builder.Services.AddAutoMapper(typeof(AutoMapping));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Adding MediatR for Domain Events and Notifications
var assembly = AppDomain.CurrentDomain.Load("Avanade.IT.ChallengeSE.Application");
builder.Services.AddMediatR(assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
