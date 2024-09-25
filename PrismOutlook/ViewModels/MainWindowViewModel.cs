using Prism.Commands;
using Prism.Regions;
using PrismOutlook.Core;
using System;

namespace PrismOutlook.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IRegionManager _regionManager;

    private string _title = "Prism Application";
    public string Title
    {
        get { return _title; }
        set { SetProperty(ref _title, value); }
    }

    private DelegateCommand<string> _navigateCommand;
    public DelegateCommand<string> NavigateCommand =>
        _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExecuteNavigateCommand));

    public MainWindowViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands)
    {
        _regionManager = regionManager;
        applicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
    }

    private void ExecuteNavigateCommand(string navigationPath)
    {
        if (string.IsNullOrEmpty(navigationPath))
            throw new ArgumentNullException();

        _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
    }
}
