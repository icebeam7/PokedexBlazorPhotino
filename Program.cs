using Photino.Blazor;
using System;
using Microsoft.Extensions.DependencyInjection;
using PokeApiNet;
using MudBlazor.Services;

namespace PokedexBlazorPhotino
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

            appBuilder.Services
                .AddMudServices()
                .AddSingleton<PokeApiClient>()
                .AddSingleton<StateService>()
                .AddLogging();

            // register root component
            appBuilder.RootComponents.Add<App>("app");

            var app = appBuilder.Build();

            // customize window
            app.MainWindow
                .SetIconFile("favicon.ico")
                .SetTitle("Photino Hello World");

            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
                app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
            };

            app.Run();
        }
    }
}
