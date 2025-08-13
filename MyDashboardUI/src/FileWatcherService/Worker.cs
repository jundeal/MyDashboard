namespace FileWatcherService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IFileWatcher _fileWatcher;

        public Worker(IFileWatcher fileWatcher, ILogger<Worker> logger)
        {
            _logger = logger;
            _fileWatcher = fileWatcher ?? throw new ArgumentNullException(nameof(fileWatcher));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                _fileWatcher.ProcessFiles(_logger);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
