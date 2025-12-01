using GarageBL.intarfaces;
using GarageBL.servers;
using GarageDB.EF.Contexts;
using GarageDB.intarfaces;
using GarageDB.servers;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Reflection;

namespace GarageApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // --- Configure Serilog early ---
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Starting up");

                var builder = WebApplication.CreateBuilder(args);

                // --- Use Serilog ---
                builder.Host.UseSerilog();

                // --- Controllers & Swagger ---
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                // --- AutoMapper ---
                builder.Services.AddAutoMapper(typeof(MapperManager));

                // --- HttpClient ---
                builder.Services.AddHttpClient();

                // --- DbContext ---
                builder.Services.AddDbContext<GarageContext>(options =>
                {
                    var connectionString = builder.Configuration.GetConnectionString("GarageDb");
                    options.UseSqlServer(connectionString);
                });

                // --- Dependency Injection ---
                builder.Services.AddScoped<IGaradeBll, GaradeBll>();
                builder.Services.AddScoped<IGarageDb, GarageDb>();

                var app = builder.Build();

                // --- Middleware ---
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();
                app.UseAuthorization();

                // --- Catch ReflectionTypeLoadException explicitly ---
                try
                {
                    app.MapControllers();
                }
                catch (ReflectionTypeLoadException ex)
                {
                    foreach (var loaderEx in ex.LoaderExceptions)
                    {
                        Log.Error(loaderEx, "Loader exception: {Message}", loaderEx.Message);
                    }
                    throw; // אפשר גם להשאיר כדי שהאפליקציה תיפסק
                }

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
