using Infragistics.Themes;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using PrismOutlook.Core;
using System.Windows;


namespace PrismOutlook.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : XamRibbonWindow
{
    private readonly IApplicationCommands _applicationCommands;

    public MainWindow(IApplicationCommands applicationCommands)
    {
        InitializeComponent();
        ThemeManager.ApplicationTheme = new Office2013Theme();
        _applicationCommands = applicationCommands;
    }

    private void XamOutlookBar_SelectedGroupChanged(object sender, RoutedEventArgs e)
    {
        var outlookBarGroup = ((XamOutlookBar)sender).SelectedGroup;
        if (outlookBarGroup is IOutlookBarGroup group)
        {
            _applicationCommands.NavigateCommand.Execute(group.DefaultNavigationPath);
        }
    }
}
