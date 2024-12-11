using googleSheetsAPI.Helpers;
using googleSheetsAPI.Services;

namespace googleSheetsAPI.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(GoogleSheetsHelper));
            services.AddSingleton<IGoogleSheetsService, GoogleSheetsService>();
            services.AddCors(options =>
            {
                options.AddPolicy("Allow4200",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            return services;
        }
    }
}
