using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Woo.Wobot.Workflow;
using Woo.Wobot.Workflow.Activities;

namespace Woo.Wobot;

[DependsOn(typeof(AbpAutofacModule))]
public class WobotModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton<MainWindow>();
        context.Services.AddSingleton<SettingWindow>();
        context.Services.AddElsa(options => options
                    .AddConsoleActivities()
                    .AddActivitiesFrom<CommandDecisionStep>()
                    .AddWorkflowsFrom<StartWorkflow>()
                    )
            .BuildServiceProvider();
    }
}
