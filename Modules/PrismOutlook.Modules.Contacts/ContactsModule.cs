using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Modules.Contacts.Menus;
using PrismOutlook.Modules.Contacts.ViewModels;
using PrismOutlook.Modules.Contacts.Views;

namespace PrismOutlook.Modules.Contacts;

public class ContactsModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(ContactsGroup));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
    }
}