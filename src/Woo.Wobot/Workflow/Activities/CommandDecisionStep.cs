using Elsa.Activities.ControlFlow;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Builders;
using Elsa.Models;
using Elsa.Services;
using Elsa.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Woo.Wobot.Consts;

namespace Woo.Wobot.Workflow.Activities;
[Action(Outcomes = new[] { CommandNameConsts.Wobot, CommandNameConsts.Custom })]
public class CommandDecisionStep : CompositeActivity
{
    public override void Build(ICompositeActivityBuilder builder)
    {
        builder
            //.SetVariable<string>("Command",(context)=>context.GetInput<string>())
            .Then((context) =>
        {
            var command = context.GetVariable<string>("Command")
            //.GetInput<string>()
            ;
            if (command.StartsWith(CommandNameConsts.Wobot)) {
                context.SetVariable("CommandType", CommandNameConsts.Wobot);
            }
            else { 
            context.SetVariable("CommandType", CommandNameConsts.Custom);
            }
        });
    }
}
