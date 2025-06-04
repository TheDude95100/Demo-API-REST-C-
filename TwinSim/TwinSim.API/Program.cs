using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TwinSim.Domain.Interfaces;
using TwinSim.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ITwinService, TwinService>();

var app = builder.Build();

FakeDate(app.Services.GetRequiredService<ITwinService>());

app.MapControllers();

app.Run();


static void FakeDate(ITwinService service)
{
    service.Create(new TwinObject
    {
        Name = "Drone A1",
        Position = new Position(10, 0, 5),
        Status = TwinStatus.Active
    });

    service.Create(new TwinObject
    {
        Name = "Capteur B2",
        Position = new Position(-3, 2, 1),
        Status = TwinStatus.Inactive
    });

    service.Create(new TwinObject
    {
        Name = "Bras Mécanique C3",
        Position = new Position(0, 0, 0),
        Status = TwinStatus.Error
    });
}