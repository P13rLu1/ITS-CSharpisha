using Microsoft.Extensions.DependencyInjection;
using RistorApp.ConsoleApp.Controllers;
using RistorApp.DataLayer.Services;
using RistorApp.DataLayer.Stores;

namespace RistorApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sc = new ServiceCollection();
             
            sc.AddScoped<MenuController>();
            sc.AddScoped<ClienteService>();
            sc.AddSingleton<ClienteStore>();
            sc.AddScoped<TavoloService>();
            sc.AddSingleton<TavoloStore>();

            var sp = sc.BuildServiceProvider();

            var menuController = sp.GetService<MenuController>();
            menuController?.Menu();
        }
    }
}