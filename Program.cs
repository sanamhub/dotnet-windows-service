await Host.CreateDefaultBuilder(args)
    .UseWindowsService(config => config.ServiceName = "Folder Cleaner Service")
    .ConfigureServices(services => services.AddHostedService<Worker>())
    .RunConsoleAsync();
