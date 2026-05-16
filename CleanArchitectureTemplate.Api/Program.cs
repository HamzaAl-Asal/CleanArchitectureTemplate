using CleanArchitectureTemplate.Api.Extensions;
using CleanArchitectureTemplate.App;
using CleanArchitectureTemplate.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .RegisterAppModuleServices()
    .RegisterInfrastructureModuleServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterApiEndpoints();

app.Run();