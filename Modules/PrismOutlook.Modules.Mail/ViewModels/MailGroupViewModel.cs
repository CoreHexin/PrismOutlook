using Prism.Commands;
using PrismOutlook.Business;
using PrismOutlook.Core;
using System.Collections.ObjectModel;

namespace PrismOutlook.Modules.Mail.ViewModels;

public class MailGroupViewModel : ViewModelBase
{
    private ObservableCollection<NavigationItem> _items;
    public ObservableCollection<NavigationItem> Items
    {
        get { return _items; }
        set { SetProperty(ref _items, value); }
    }

    private DelegateCommand<NavigationItem> _selectedCommand;
    private readonly IApplicationCommands _applicationCommands;

    public DelegateCommand<NavigationItem> SelectedCommand =>
        _selectedCommand ?? (_selectedCommand = new DelegateCommand<NavigationItem>(ExecuteSelectedCommand));

    public MailGroupViewModel(IApplicationCommands applicationCommands)
    {
        GenerateMenu();
        _applicationCommands = applicationCommands;
    }

    void ExecuteSelectedCommand(NavigationItem navigationItem)
    {
        _applicationCommands.NavigateCommand.Execute(navigationItem.NavigationPath);
    }

    private void GenerateMenu()
    {
        Items = new ObservableCollection<NavigationItem>();

        var root = new NavigationItem() { Caption = "Person Folder", NavigationPath = "MailList?id=Default" };
        root.Items.Add(new NavigationItem() { Caption = "收件箱", NavigationPath = "MailList?id=Inbox" });
        root.Items.Add(new NavigationItem() { Caption = "已发送", NavigationPath = "MailList?id=Send" });
        root.Items.Add(new NavigationItem() { Caption = "已删除", NavigationPath = "MailList?id=Deleted" });

        Items.Add(root);
    }
}
