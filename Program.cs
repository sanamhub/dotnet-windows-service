var serviceName = "Folder Cleaner Service";

await Host
    .CreateDefaultBuilder(args)
    .UseWindowsService(config => config.ServiceName = serviceName)
    .ConfigureServices(services => services.AddHostedService<Worker>())
    .RunConsoleAsync();
