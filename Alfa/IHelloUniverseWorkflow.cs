using Temporalio.Workflows;

namespace Alfa
{
    public interface IHelloUniverseWorkflow
    {
        [WorkflowRun]
        Task<string> RunAsync(string name);
    }
}
