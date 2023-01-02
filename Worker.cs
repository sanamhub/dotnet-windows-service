public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;

    public Worker(ILogger<Worker> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int delayInMilliseconds = _configuration.GetValue<int>("Service:DelayInMillisecond");
        double createdMinToDelete = _configuration.GetValue<double>("Service:DeleteFileCreatedBeforeWhatMin");
        string? folderToWatch = _configuration.GetValue<string>("Service:WatchDirectory");

        if (!Directory.Exists(folderToWatch)) Directory.CreateDirectory(folderToWatch);

        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (var file in Directory.GetFiles(folderToWatch))
            {
                var fileInfo = new FileInfo(file);
                if (fileInfo.CreationTime < DateTime.Now.AddMinutes(-createdMinToDelete))
                {
                    _logger.LogInformation($"Deleting {fileInfo.Name}");
                    fileInfo.Delete();
                }
            }

            await Task.Delay(delayInMilliseconds, stoppingToken);
        }
    }
}
