using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TwinSim.Domain.Interfaces;
using TwinSim.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ITwinService, TwinService>();

var app = builder.Build();

app.MapControllers();

app.Run();