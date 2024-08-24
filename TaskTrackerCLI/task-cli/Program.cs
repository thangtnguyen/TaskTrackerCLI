// See https://aka.ms/new-console-template for more information

using BusinessManager;
using Microsoft.Extensions.DependencyInjection;
using task_cli;

// 1. Create the service collection.
var services = new ServiceCollection();

// 2. Register (add and configure) the services.
services.AddBusinessManagerService();
services.AddSingleton<IApplication>(new Application(args));

// 3. Build the service provider from the service collection.
var serviceProvider = services.BuildServiceProvider();

IApplication app = serviceProvider.GetRequiredService<IApplication>();
app.HandleBusiness();