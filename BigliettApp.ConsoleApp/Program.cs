using System;
using BigliettApp.ConsoleApp.Controllers;
using BigliettApp.DataLayer;
using BigliettApp.DataLayer.Services;
using BigliettApp.DataLayer.Stores;
using BigliettApp.DataLayer.Stores.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BigliettApp.ConsoleApp;

public class Program
{
    public static void Main()
    {
        var sc = new ServiceCollection();

        sc.AddScoped<MenuController>();
        sc.AddScoped<ClienteService>();
        sc.AddScoped<SpettacoloService>();
        
        bool useDb = true;
        if (useDb)
        {
            sc.AddScoped<IClienteStore, ClienteDbStore>();
            sc.AddScoped<ISpettacoloStore, SpettacoloDbStore>();
            sc.AddScoped<IPrenotazioneStore, PrenotazioneDbStore>();
                
        }
        else
        {
            sc.AddSingleton<IClienteStore, ClienteStore>();
            sc.AddSingleton<ISpettacoloStore, SpettacoloStore>();
            sc.AddSingleton<IPrenotazioneStore, PrenotazioneStore>();
        }
        
        sc.AddDbContext<BiglietteriaDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql("server=localhost;port=3306;user=root;password=admin;database=bigliettapp", 
                    new MySqlServerVersion(new Version(8, 0, 37)))
        );
        
        var sp = sc.BuildServiceProvider();
        var menuController = sp.GetService<MenuController>();
        menuController?.Menu();
    }
}