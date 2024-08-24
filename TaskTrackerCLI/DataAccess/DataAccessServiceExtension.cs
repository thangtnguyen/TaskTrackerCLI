using Microsoft.Extensions.DependencyInjection;
using Models.Interfaces;

namespace DataAccess
{
    public static class DataAccessServiceExtension
    {
        public static IServiceCollection AddDataAccessService(this IServiceCollection services)
        {
            services.AddScoped<ITaskDataAccess, TaskDataAccess>();

            return services;
        }
    }
}
