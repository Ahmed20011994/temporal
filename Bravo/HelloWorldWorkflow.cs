﻿using Temporalio.Workflows;

namespace Bravo
{
    [Workflow]
    public class HelloWorldWorkflow : IHelloWorldWorkflow
    {
        [WorkflowRun]
        public async Task<string> RunAsync(string name)
        {
            // This workflow just runs a simple activity to completion.
            // StartActivityAsync could be used to just start and there are many
            // other things that you can do inside a workflow.
            return await Workflow.ExecuteActivityAsync(
                // This is a lambda expression where the instance is typed. If this
                // were static, you wouldn't need a parameter.
                (Activities act) => act.SayHello(name),
                new() { ScheduleToCloseTimeout = TimeSpan.FromMinutes(5) });
        }
    }
}
