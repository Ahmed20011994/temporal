using Temporalio.Workflows;

namespace Bravo
{
    public interface IHelloWorldWorkflow
    {
        [WorkflowRun]
        Task<string> RunAsync(string name);
    }
}
