using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Woo.Wobot.ViewModel
{
    public  partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ExecuteCommand))]
        public string commandStr = "dd";

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
               await Task.Delay(5_00);
                CommandStr += "Executed";
            }
            catch (TaskCanceledException ex)
            {
                CommandStr += "x";
            }
        }
    }
}