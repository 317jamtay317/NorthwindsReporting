using System.Collections.ObjectModel;
using System.Windows.Input;
using DAL.Repositories.Reports;
using DAL.Repositories.StoredQueries;
using Models;
using Prism.Commands;
using Prism.Regions;
using Shared;
using Shared.Mvvm;

namespace Configure.ViewModels
{
    internal class FormReportBuilderViewModel : LoadedViewModelBase
    {
        public FormReportBuilderViewModel(IStoredQueryRepository storedQueryRepository,
            IRegionManager regionManager,
            IReportsRepository reportsRepository)
        {
            _storedQueryRepository = storedQueryRepository;
            _regionManager = regionManager;
            NavigateCommand =
                new DelegateCommand<string>((view) => _regionManager.RequestNavigate(Regions.ConfigureRegion, view));
        }
        public ObservableCollection<StoredQuery> Queries { get; } = new();
        public ObservableCollection<StoredQuery> Reports { get; } = new();

        public ICommand NavigateCommand { get; }

        public int QueryId
        {
            get => GetValue<int>();
            set => SetValue(value);
        }

        protected override async void LoadedExecute()
        {
            Queries.Clear();
            var queries = await _storedQueryRepository.GetAll();
            Queries.AddRange(queries);

            Queries.Add(new StoredQuery() { Id = 1, Name = "All Customers", Sql = "SELECT * FROM Customers"});
            Queries.Add(new StoredQuery() { Id = 1, Name = "Current Orders", Sql = "SELECT * FROM Orders where ShippedDate is NULL" });

        }

        private readonly IStoredQueryRepository _storedQueryRepository;
        private readonly IRegionManager _regionManager;
    }
}
