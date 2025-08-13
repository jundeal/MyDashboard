using FileWatcherService;
using System.Runtime;
using Serilog;
using Serilog.Sinks.SystemConsole;
using Serilog.Sinks.File;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger());

builder.Services.Configure<DataFolders>(builder.Configuration.GetSection("DataFolders"));
builder.Services.Configure<DataFolders>(builder.Configuration.GetSection("AISettings"));

builder.Services.AddSingleton<IFileProcessor, FileProcessor>();
builder.Services.AddSingleton<IFileWatcher, FileWatcher>();

builder.Services.AddHostedService<Worker>();


var host = builder.Build();
host.Run();
