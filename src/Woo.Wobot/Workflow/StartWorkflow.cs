using Elsa.Activities.Console;
using Elsa.Activities.ControlFlow;
using Elsa.Activities.Primitives;
using Elsa.Activities.Workflows;
using Elsa.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woo.Wobot.Consts;
using Woo.Wobot.Workflow.Activities;
using static Elsa.Activities.Workflows.RunWorkflow;

namespace Woo.Wobot.Workflow;
public class StartWorkflow : IWorkflow
{
    public void Build(IWorkflowBuilder builder)
    {
        builder
            .SetVariable("Command", context =>
            {
                var c = context.GetInput<string>();
                return context.GetInput<string>();
            }).Then<CommandDecisionStep>()
            .Switch(
            cases => cases
            .Add(context => context.GetVariable<string>("CommandType") == CommandNameConsts.Wobot, @case =>
            {
                @case.Then<WobotCommandExecute>();
            })
            );
        //    .Then<CommandDecisionStep>((command) =>
        //    {
        //        command.When(CommandNameConsts.Wobot).Then<RunWorkflow>((c) => { c.RunWorkflow<WobotWorkflow>(RunWorkflowMode.FireAndForget); });
        //    //command.When(CommandNameConsts.Wobot).Then<Fork>(fork => {
        //    //    fork.RunWorkflow<WobotWorkflow>(RunWorkflowMode.FireAndForget);
        //    //});
        //    //command.When(CommandNameConsts.Custom).Then<Fork>(fork =>
        //    //{
        //    //    fork.RunWorkflow<WobotWorkflow>(RunWorkflowMode.FireAndForget);
        //    //});
        //});
        //builder.SetVariable("",);
    }
}
