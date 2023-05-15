
using Hangfire;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace HangFireBackgroundServiceClass
{
    public class HelloWorldBackgroundService : BackgroundService
    {
        private readonly IRecurringJobManager _recurringJobManager;

        public HelloWorldBackgroundService(IRecurringJobManager recurringJobManager)
        {
            _recurringJobManager = recurringJobManager;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _recurringJobManager.AddOrUpdate(
                "HelloWorldJob",
                () => Console.WriteLine("Hello, World!"),
                "*/1 * * * *" // Run every 5 seconds
            );

            return Task.CompletedTask;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Your background service logic (if any)
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _recurringJobManager.RemoveIfExists("HelloWorldJob");

            return Task.CompletedTask;
        }
    }

}
