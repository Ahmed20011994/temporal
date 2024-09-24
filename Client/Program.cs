using Client;
using Temporalio.Client;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Use an async lambda for MapGet to call the async HelloWorld method
app.MapGet("/", async () => await HelloWorld());

app.Run();

async Task<string> HelloWorld()
{
    // Create client connected to server at the given address and namespace
    var client = await TemporalClient.ConnectAsync(new()
    {
        TargetHost = "temporal:7233"
    });

    // Start a workflow
    //var handle = await client.StartWorkflowAsync(
    //    (IHelloWorldWorkflow wf) => wf.RunAsync("John"),
    //    new() { Id = "John's-workflow-id", TaskQueue = "Alfa-task-queue", });

    var handle = await client.StartWorkflowAsync(
        (IHelloUniverseWorkflow wf) => wf.RunAsync("John"),
        new() { Id = "John's-workflow-id", TaskQueue = "Alfa-task-queue", });

    // Wait for a result
    var result = await handle.GetResultAsync();

    return "Hello World!";
}
