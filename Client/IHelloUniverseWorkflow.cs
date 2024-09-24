using Temporalio.Workflows;

namespace Client
{
    [Workflow]
    public interface IHelloUniverseWorkflow
    {
        [WorkflowRun]
        Task<string> RunAsync(string name);
    }
}
