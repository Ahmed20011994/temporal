using Temporalio.Workflows;

namespace Alfa
{
    public interface IHelloWorldWorkflow
    {
        [WorkflowRun]
        Task<string> RunAsync(string name);
    }
}
