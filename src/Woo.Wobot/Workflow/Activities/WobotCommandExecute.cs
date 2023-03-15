using Elsa.Activities.ControlFlow;
using Elsa.Builders;
using Elsa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woo.Wobot.Workflow.Activities;

namespace Woo.Wobot.Workflow;
public class WobotCommandExecute : CompositeActivity
{
    public void Build(IWorkflowBuilder builder)
    {
        builder
           .SetVariable<string>("Command", (context) =>
           {

               var c = context.GetInput<string>();
               return context.GetInput<string>();
               })
           .Switch(cases =>
           {
               cases.Add(context =>
               {
               var command = context.GetVariable<string>("Command");
               return command == "$setting";
                   
               },@case=>@case.Then<OpenSetting>());
           });
    }
}
