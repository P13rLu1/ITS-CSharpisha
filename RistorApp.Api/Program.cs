using RistorApp.DataLayer.Services;
using RistorApp.DataLayer.Stores;

namespace RistorApp.Api
{
    public abstract class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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