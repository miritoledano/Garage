using GarageApi;
using GarageBL.intarfaces;
using GarageBL.servers;
using GarageDB.EF.Contexts;
using GarageDB.intarfaces;
using GarageDB.servers;
using Microsoft.EntityFrameworkCore;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  
              .AllowAnyHeader()                       
              .AllowAnyMethod();                      
    });
});

// הגדרת Serilog ללוגים 
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()                   
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day) // שמירה לקובץ יומי
    .CreateLogger();

builder.Host.UseSerilog(); 


builder.Services.AddControllers();          
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();           

builder.Services.AddAutoMapper(typeof(MapperManager)); // מיפוי בין ה DTO ל ENTITIY


builder.Services.AddHttpClient();

// הגדרת החיבור למסד
builder.Services.AddDbContext<GarageContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("GarageDb");
    options.UseSqlServer(connectionString);
});

// --- Dependency Injection 
builder.Services.AddScoped<IGaradeBll, GaradeBll>();
builder.Services.AddScoped<IGarageDb, GarageDb>();

var app = builder.Build();

app.UseCors("AllowAngular");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Garage API V1");
        c.RoutePrefix = string.Empty; 
    });
}
//סתם לנוחות

app.MapGet("/", () => "Garage API is running. Check /swagger for all endpoints.");

app.Run();
