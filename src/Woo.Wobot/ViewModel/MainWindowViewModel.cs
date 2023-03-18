using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Elsa.Models;
using Elsa.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Volo.Abp.DependencyInjection;
using Woo.Wobot.Workflow;

namespace Woo.Wobot.ViewModel
{
    public  partial class MainWindowViewModel : ObservableObject,ITransientDependency
    {
        private readonly IBuildsAndStartsWorkflow _workflowRunner;

        public MainWindowViewModel(IBuildsAndStartsWorkflow workflowRunner)
        {
            _workflowRunner = workflowRunner;
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ExecuteCommand))]
        public string commandStr = "";

        //public IRelayCommand ExecuteCommand { get; }


        //public MainWindowViewModel()
        //{
        //    ExecuteCommand = new RelayCommand(OnClick,CanClick);
        //}

        //private bool CanClick()
        //{
        //    return !string.IsNullOrWhiteSpace(CommandStr);
        //}
        [RelayCommand(AllowConcurrentExecutions =true)]
        private async Task Execute()
        {
            try { 
                var result = await _workflowRunner.BuildAndStartWorkflowAsync<StartWorkflow>(input: new WorkflowInput(CommandStr));

                CommandStr += "Executed";
            }
            catch (TaskCanceledException ex)
            {
                CommandStr += "x";
            }
        }
    }
}