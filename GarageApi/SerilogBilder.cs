using Serilog;

namespace GarageApi
{
    public static class SerilogBilder
    {
        // מחלקה סטטית שמטרתה להוסיף הרחבה לוואב 

        public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
        {
            builder
                .Host
                .UseSerilog((
                    hostingContext,
                    loggerConfiguration) =>
                {
                    loggerConfiguration
                    .ReadFrom
                  .Configuration(hostingContext.Configuration);   //טעינת ההגדרות מהוקבץ של appsetting
                });

            return builder;
        }
    }
}
