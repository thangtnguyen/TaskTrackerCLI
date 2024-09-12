// See https://aka.ms/new-console-template for more information

using BusinessManager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using task_cli;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<FileDataSourceOptions>(context.Configuration.GetSection(nameof(FileDataSourceOptions)));
        services.AddBusinessManagerService();
        services.AddSingleton<IApplication, Application>();
    }).Build(); 

var app = host.Services.GetService<IApplication>();
app!.HandleBusiness(args);