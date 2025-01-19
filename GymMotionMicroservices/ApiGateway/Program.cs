using ApiGateway.Extensions;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var ocelot = builder.Services.AddOcelot();

builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddOcelotConfigFiles("./Routes", new[]
    {
        "common", "ejercicios", "entrenamientos"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseOcelot().Wait();

app.UseHttpsRedirection();

app.Run();