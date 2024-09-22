using Infragistics.Windows.OutlookBar;
using Prism.Regions;
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
        region.Views.CollectionChanged += (s, e) =>
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (OutlookBarGroup group in e.NewItems)
                        {
                            regionTarget.Groups.Add(group);
                            if (regionTarget.Groups[0] == group)
                            {
                                regionTarget.SelectedGroup = group;
                            }
                        }
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (OutlookBarGroup group in e.OldItems)
                        {
                            regionTarget.Groups.Remove(group);
                        }
                        break;
                    }
            }
        };
    }

    protected override IRegion CreateRegion()
    {
        return new SingleActiveRegion();
    }
}
