using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using Prism.Regions;

namespace Shared.Mvvm
{
    public abstract class TabItemViewModelBase : LoadedViewModelBase, ITabItem
    {
        protected IRegionManager RegionManager { get; }

        protected TabItemViewModelBase(IRegionManager regionManager)
        {
            RegionManager = regionManager;
            RemoveCommand = new DelegateCommand<ITabItem>(RemoveExecute);
        }

        /// <summary>
        /// The caption that is displayed in the tab header
        /// </summary>
        public string? Header
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        
        /// <summary>
        /// Removes the tab from the tabs region
        /// </summary>
        public ICommand RemoveCommand { get; }

        private void RemoveExecute(ITabItem obj)
        {
            var view = RegionManager
                .Regions[Regions.TabRegion]
                .Views
                .Cast<ContentControl>()
                .FirstOrDefault(view=> ReferenceEquals(view.DataContext, obj));
            RegionManager.Regions[Regions.TabRegion].Remove(view);
        }
    }
}
