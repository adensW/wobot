using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woo.Wobot.Workflow.Activities;
public class OpenSetting : Activity
{
    private readonly SettingWindow _settingWindow;

    public OpenSetting(SettingWindow settingWindow)
    {
        _settingWindow = settingWindow;
    }

    protected override ValueTask<IActivityExecutionResult> OnExecuteAsync(ActivityExecutionContext context)
    {
        _settingWindow.Show();
        return base.ExecuteAsync(context);
    }
}
