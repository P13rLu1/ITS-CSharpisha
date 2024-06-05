using System.Reflection;
using RistorApp.DataLayer.Services;
using RistorApp.DataLayer.Stores;

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
            builder.Services.AddSingleton<ClienteStore>();
            builder.Services.AddScoped<TavoloService>();
            builder.Services.AddSingleton<TavoloStore>();
            builder.Services.AddScoped<PrenotazioneService>();
            builder.Services.AddSingleton<PrenotazioneStore>();

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
        }
    }
}