using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

namespace PrismOutlook.Core.Regions;

public class DependentViewRegionBehavior : RegionBehavior
{
    public const string BehaviorKey = "DependentViewRegionBehavior";
    private readonly IContainerExtension _container;
    private Dictionary<object, List<DependentViewInfo>> _dependentViewCache = new Dictionary<object, List<DependentViewInfo>>();

    public DependentViewRegionBehavior(IContainerExtension container)
    {
        _container = container;
    }

    protected override void OnAttach()
    {
        Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
    }

    private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            foreach (var newView in e.NewItems)
            {
                var dependentViews = new List<DependentViewInfo>();

                if (_dependentViewCache.ContainsKey(newView))
                {
                    dependentViews = _dependentViewCache[newView];
                }
                else
                {
                    // 获取attribute
                    var atts = GetCustomeAttributes<DependentViewAttribute>(newView.GetType());
                    foreach (var att in atts)
                    {
                        // 根据attribute创建DependentViewInfo对象, 关联View和Region
                        var info = CreateDependentViewInfo(att);
                        dependentViews.Add(info);

                        if (info.View is ISupportDataContext infoDC && newView is ISupportDataContext newViewDC)
                            infoDC.DataContext = newViewDC.DataContext;
                    }
                    _dependentViewCache.Add(newView, dependentViews);
                }

                // 将View注入到Region中
                foreach (var item in dependentViews)
                {
                    Region.RegionManager.Regions[item.Region].Add(item.View);
                }
            }
        }
        else if (e.Action == NotifyCollectionChangedAction.Remove)
        {
            foreach(var oldView in e.OldItems)
            {
                if (_dependentViewCache.ContainsKey(oldView))
                {
                    var dependentView = _dependentViewCache[oldView];
                    foreach (var item in dependentView)
                    {
                        Region.RegionManager.Regions[item.Region].Remove(item.View);
                    }

                    if (!ShouldKeepAlive(oldView))
                    {
                        _dependentViewCache.Remove(oldView);
                    }
                }
            }
        }
    }

    private bool ShouldKeepAlive(object oldView)
    {
        var lifetime = GetViewOrDataContextLifeTime(oldView);
        if (lifetime != null)
            return lifetime.KeepAlive;

        return true;
    }

    private IRegionMemberLifetime GetViewOrDataContextLifeTime(object view)
    {
        if (view is IRegionMemberLifetime lifetime)
            return lifetime;

        if (view is FrameworkElement fe)
            return fe.DataContext as IRegionMemberLifetime;

        return null;
    }

    private DependentViewInfo CreateDependentViewInfo(DependentViewAttribute attribute)
    {
        var info = new DependentViewInfo();
        info.Region = attribute.Region;
        info.View = _container.Resolve(attribute.Type);
        return info;
    }

    private static IEnumerable<T> GetCustomeAttributes<T>(Type type)
    {
        return type.GetCustomAttributes(typeof(T), true).OfType<T>();
    }
}

public class DependentViewInfo
{
    public object View { get; set; }
    public string Region { get; set; }
}
