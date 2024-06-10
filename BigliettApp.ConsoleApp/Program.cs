using BigliettApp.ConsoleApp.Controllers;
using BigliettApp.DataLayer.Services;
using BigliettApp.DataLayer.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace BigliettApp.ConsoleApp;

public class Program
{
    public static void Main()
    {
        var sc = new ServiceCollection();

        sc.AddScoped<MenuController>();
        sc.AddScoped<ClienteService>();
        sc.AddSingleton<ClienteStore>();
        sc.AddScoped<SpettacoloService>();
        sc.AddSingleton<SpettacoloStore>();
        
        var sp = sc.BuildServiceProvider();
        var menuController = sp.GetService<MenuController>();
    }
}