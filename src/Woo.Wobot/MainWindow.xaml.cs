using System;
using System.Windows;
using Woo.Wobot.ViewModel;

namespace Woo.Wobot;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly HelloWorldService _helloWorldService;

    public MainWindow(HelloWorldService helloWorldService)
    {
        _helloWorldService = helloWorldService;
        DataContext = new MainWindowViewModel();
        InitializeComponent();
    }
   
}
