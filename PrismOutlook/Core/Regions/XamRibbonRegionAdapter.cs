using Infragistics.Windows.Ribbon;
using Prism.Regions;
using System;
using System.Collections.Specialized;

namespace PrismOutlook.Core.Regions;

public class XamRibbonRegionAdapter : RegionAdapterBase<XamRibbon>
{
    public XamRibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
    {
    }

    protected override void Adapt(IRegion region, XamRibbon regionTarget)
    {
        if (region == null)
            throw new ArgumentNullException(nameof(region));

        if (regionTarget == null)
            throw new ArgumentNullException(nameof(regionTarget));

        region.Views.CollectionChanged += (s, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var view in e.NewItems)
                {
                    AddViewToRegion(view, regionTarget);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var view in e.OldItems)
                {
                    RemoveViewFromRegion(view, regionTarget);
                }
            }
        };
    }

    private void RemoveViewFromRegion(object view, XamRibbon xamRibbon)
    {
        if (view is RibbonTabItem ribbonTabItem)
        {
            xamRibbon.Tabs.Remove(ribbonTabItem);
        }
    }

    private void AddViewToRegion(object view, XamRibbon xamRibbon)
    {
        if (view is RibbonTabItem ribbonTabItem)
        {
            xamRibbon.Tabs.Add(ribbonTabItem);
        }
    }

    protected override IRegion CreateRegion()
    {
        return new SingleActiveRegion();
    }
}
