using Temporalio.Workflows;

namespace Client
{

    [Workflow]
    public interface IHelloWorldWorkflow
    {
        [WorkflowRun]
        Task<string> RunAsync(string name);
    }
}
