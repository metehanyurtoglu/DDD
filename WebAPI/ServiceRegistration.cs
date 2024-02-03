using Mapster;
using MapsterMapper;
using System.Reflection;

namespace WebAPI
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddWebAPI(this IServiceCollection services)
        {
            //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            #region Mapster Configuration
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            #endregion

            return services;
        }
    }
}
