using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Modules.Contacts.Menus;
using System.Windows.Controls;

namespace PrismOutlook.Modules.Contacts.Views;

/// <summary>
/// ViewA.xaml 的交互逻辑
/// </summary>
[DependentView(RegionNames.RibbonRegion, typeof(HomeTab))]
public partial class ViewA : UserControl, IRegionMemberLifetime
{
    public ViewA()
    {
        InitializeComponent();
    }

    public bool KeepAlive => false;
}
