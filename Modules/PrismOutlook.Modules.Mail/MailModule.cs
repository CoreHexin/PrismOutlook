using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Modules.Mail.Menus;
using PrismOutlook.Modules.Mail.Views;

namespace PrismOutlook.Modules.Mail;

public class MailModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ViewA));  // todo: 待删除
        regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(HomeTab));
        regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(MailGroup));
    } 

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }
}