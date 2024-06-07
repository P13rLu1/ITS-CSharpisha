using RistorApp.DataLayer.Services;
using RistorApp.DataLayer.Stores;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RistorApp.DataLayer;
using RistorApp.DataLayer.Stores.Interfaces;

namespace RistorApp.Api
{
    /// <summary>
    /// Classe principale dell'applicazione
    /// </summary>
    public abstract class Program
    {
        /// <summary>
        /// Funzione principale dell'applicazione
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<TavoloService>();
            builder.Services.AddScoped<PrenotazioneService>();

            bool useDb = true;
            if (useDb)
            {
                builder.Services.AddScoped<IClienteStore, ClienteDbStore>();
                builder.Services.AddScoped<ITavoloStore, TavoloDbStore>();
                builder.Services.AddScoped<IPrenotazioneStore, PrenotazioneDbStore>();
                
            }
            else
            {
                builder.Services.AddSingleton<IClienteStore, ClienteStore>();
                builder.Services.AddSingleton<ITavoloStore, TavoloStore>();
                builder.Services.AddSingleton<IPrenotazioneStore, PrenotazioneStore>();
            }
            
            builder.Services.AddDbContext<RistoranteDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql("server=localhost;port=3306;user=root;password=admin;database=ristorapp", 
                        new MySqlServerVersion(new Version(8, 0, 37)))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            
            
            // dotnet tool install --global dotnet-ef 

            // dotnet ef --startup-project ../<PersorsoProjectApi>/ migrations add <NomeMigration>
            // dotnet ef --startup-project ../RistorApp.Api/ migrations add CreateCliente

            // dotnet ef --startup-project ../<PersorsoProjectApi>/ database update
            // dotnet ef --startup-project ../RistorApp.Api/ database update
        }
    }
}