using Infragistics.Windows.OutlookBar;
using Prism.Regions;
using System;
using System.Collections.Specialized;

namespace PrismOutlook.Core.Regions;

// 区域适配器
public class XamOutlookBarRegionAdapter : RegionAdapterBase<XamOutlookBar>
{
    public XamOutlookBarRegionAdapter(IRegionBehaviorFactory factory) : base(factory)
    {
    }

    protected override void Adapt(IRegion region, XamOutlookBar regionTarget)
    {
        if (region == null)
            throw new ArgumentNullException(nameof(region));

        if (regionTarget == null)
            throw new ArgumentNullException(nameof(regionTarget));

        region.Views.CollectionChanged += (s, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (OutlookBarGroup group in e.NewItems)
                {
                    regionTarget.Groups.Add(group);
                    if (regionTarget.Groups[0] == group)
                    {
                        regionTarget.SelectedGroup = group;
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (OutlookBarGroup group in e.OldItems)
                {
                    regionTarget.Groups.Remove(group);
                }
            }
        };
    }

    protected override IRegion CreateRegion()
    {
        return new SingleActiveRegion();
    }
}
