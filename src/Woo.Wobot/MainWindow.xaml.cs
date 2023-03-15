using Elsa.Models;
using Elsa.Services;
using Elsa.Services.Workflows;
using System;
using System.Threading.Tasks;
using System.Windows;
using Woo.Wobot.Workflow;

namespace Woo.Wobot;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly HelloWorldService _helloWorldService;
    private readonly IBuildsAndStartsWorkflow _workflowRunner;
    public MainWindow(HelloWorldService helloWorldService, IBuildsAndStartsWorkflow workflowRunner)
    {
        _helloWorldService = helloWorldService;
        _workflowRunner = workflowRunner;

        InitializeComponent();
    }

    protected override void OnContentRendered(EventArgs e)
    {
        //HelloLabel.Content = _helloWorldService.SayHello();
    }

    private async void CommandBtn_Click(object sender, RoutedEventArgs e)
    {
        var result = await _workflowRunner.BuildAndStartWorkflowAsync<StartWorkflow>(input: new WorkflowInput(CommandInput.Text));
        if (result.Executed)
        {
            CommandInput.Text = "Executed";
        }
    }
}
