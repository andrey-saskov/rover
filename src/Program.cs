using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rover.Controllers;
using Rover.Controllers.Program;
using Rover.Controllers.Program.Action;
using Rover.Entities;
using Rover.Entities.Enums;
using Rover.MapViewer;
// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        var mapViewer = host.Services.GetService<IMapViewer>();
        var mapController = host.Services.GetService<IMapController>();
        var roverController = host.Services.GetService<IRoverController>();

        mapViewer.Clear();

        var map = mapController.Initialize(new Position() { X = 0, Y = 0 }, new Position() { X = 5, Y = 3 });

        var rover = roverController.Create(
            new Position() { X = 1, Y = 1 },
            Direction.East,
            "RFRFRFRF"
        );
        mapController.DeployObject(rover);

        for (int i = 0; i < 20; i++)
        {
            mapViewer.DrawMap(map);
            mapController.Synchronize();
        }

        rover = roverController.Create(
            new Position() { X = 3, Y = 2 },
            Direction.North,
            "FRRFLLFFRRFLL"
        );
        mapController.DeployObject(rover);

        for (int i = 0; i < 20; i++)
        {
            mapViewer.DrawMap(map);
            mapController.Synchronize();
        }

        rover = roverController.Create(
            new Position() { X = 0, Y = 3 },
            Direction.West,
            "LLFFFLFLFL"
        );
        mapController.DeployObject(rover);

        for (int i = 0; i < 20; i++)
        {
            mapViewer.DrawMap(map);
            mapController.Synchronize();
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IMapViewer, ConsoleViewer>();
                services.AddSingleton<IMapController, MapController>();
                services.AddScoped<IRoverController, RoverController>();
                services.AddScoped<ISynchronizer, RoverController>();

                services.AddScoped<IProgramBuilder, ProgramBuilder>();
                services.AddScoped<IAction, MoveForward>();
                services.AddScoped<IAction, TurnLeft>();
                services.AddScoped<IAction, TurnRight>();
            });

        return hostBuilder;
    }
}
