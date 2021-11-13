using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IUploadService, UploadService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddDbContext<DataContext>(option =>
            {
                option.UseMySQL(config.GetConnectionString("Default"));
                //option.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}