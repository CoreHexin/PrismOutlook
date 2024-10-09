using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Modules.Mail.Menus;
using PrismOutlook.Modules.Mail.ViewModels;
using PrismOutlook.Modules.Mail.Views;
using PrismOutlook.Services;
using PrismOutlook.Services.Interfaces;

namespace PrismOutlook.Modules.Mail;

public class MailModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(MailGroup));
    } 

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        ViewModelLocationProvider.Register<MailGroup, MailGroupViewModel>();
        containerRegistry.RegisterForNavigation<MailList, MailListViewModel>();

        // 因为邮件服务只在Mail模块中使用, 所以放在这里注册。
        containerRegistry.RegisterSingleton<IMailService, MailService>();
    }
}