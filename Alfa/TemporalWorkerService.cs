using Temporalio.Client;
using Temporalio.Worker;

namespace Alfa
{
    // Hosted service for the Temporal worker
    public class TemporalWorkerService(IServiceProvider serviceProvider) : IHostedService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        public required TemporalWorker _worker;
        public required CancellationTokenSource _tokenSource;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _tokenSource = new CancellationTokenSource();

            // Create a new scope for resolving scoped services like Activities
            using var scope = _serviceProvider.CreateScope();
            var scopedProvider = scope.ServiceProvider;

            // Resolve Temporal client and activities
            var client = await scopedProvider.GetRequiredService<Task<TemporalClient>>();
            var activities = scopedProvider.GetRequiredService<Activities>();

            // Create and configure the worker
            _worker = new TemporalWorker(
                client,
                new TemporalWorkerOptions("Alfa-task-queue")
                    .AddActivity(activities.SayHelloWorld)
                    .AddActivity(activities.SayHelloUniverse)
                    .AddWorkflow<HelloWorldWorkflow>()
                    .AddWorkflow<HelloUniverseWorkflow>());

            // Run the worker
            Console.WriteLine("Running worker");
            _ = Task.Run(async () =>
            {
                try
                {
                    await _worker.ExecuteAsync(_tokenSource.Token);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Worker cancelled");
                }
            }, _tokenSource.Token);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _tokenSource.Cancel();
            _worker.Dispose();
            Console.WriteLine("Worker stopped");
            return Task.CompletedTask;
        }
    }
}
