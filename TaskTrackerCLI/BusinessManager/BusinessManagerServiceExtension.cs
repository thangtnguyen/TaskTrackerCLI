﻿using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Interfaces;

namespace BusinessManager
{
    public static class BusinessManagerServiceExtension
    {
        public static IServiceCollection AddBusinessManagerService(this IServiceCollection services)
        {
            services.AddDataAccessService();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskBusinessManager, TaskBusinessManager>();

            return services;
        }
    }
}
