using Elsa.Models;
using Elsa.Services;
using Elsa.Services.Workflows;
using System;
using System.Threading.Tasks;
using System.Windows;
using Woo.Wobot.ViewModel;
using Woo.Wobot.Workflow;

namespace Woo.Wobot;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel vm)
    {
        DataContext = vm;

        InitializeComponent();
    }
   
}
