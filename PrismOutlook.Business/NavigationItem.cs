using System.Collections.ObjectModel;

namespace PrismOutlook.Business;

public class NavigationItem
{
    public string Caption { get; set; } = string.Empty;
    public string NavigationPath { get; set; } = string.Empty;
    public bool IsExpanded { get; set; }
    public ObservableCollection<NavigationItem> Items { get; set; }

    public NavigationItem()
    {
        Items = new ObservableCollection<NavigationItem>();
    }
}
