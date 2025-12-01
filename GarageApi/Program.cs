using GarageBL.intarfaces;
using GarageBL.servers;
using GarageDB.EF.Contexts;
using GarageDB.intarfaces;
using GarageDB.servers;

using Microsoft.EntityFrameworkCore;


namespace GarageApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            // כאן נופל כשיש בעיית DI או בעיית קונסטרקטור
            app.MapControllers();

            app.Run();
        }
    }
}
