using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using Prism.Regions;

namespace Northwinds.Core.Prism;

public class TabControlAdapter : RegionAdapterBase<TabControl>
{
    public TabControlAdapter(IRegionBehaviorFactory regionBehaviorFactory) 
        : base(regionBehaviorFactory)
    {
    }

    protected override void Adapt(IRegion region, TabControl regionTarget)
    {
        region.Views.CollectionChanged += (s, e) =>
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var content in e.NewItems)
                {
                    regionTarget.Items.Add(new TabItem() { Header = content, Content = content });
                }
            }
            else if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var tabContent in e.OldItems)
                {
                    var tabToDelete = regionTarget
                        .Items
                        .OfType<TabItem>()
                        .FirstOrDefault(x => x.Content.Equals(tabContent) || ReferenceEquals(x.Content, tabContent));
                    regionTarget.Items.Remove(tabToDelete);
                }
            }
        };
    }

    protected override IRegion CreateRegion()
    {
        return new SingleActiveRegion();
    }
}