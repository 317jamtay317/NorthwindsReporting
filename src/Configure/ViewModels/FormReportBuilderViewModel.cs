using System.Collections.ObjectModel;
using DAL.Repositories.StoredQueries;
using Models;
using Shared.Mvvm;

namespace Configure.ViewModels
{
    internal class FormReportBuilderViewModel : LoadedViewModelBase
    {
        public FormReportBuilderViewModel(IStoredQueryRepository storedQueryRepository)
        {
            _storedQueryRepository = storedQueryRepository;
        }
        public ObservableCollection<StoredQuery> Queries { get; } = new();

        public int QueryId
        {
            get => GetValue<int>();
            set => SetValue(value);
        }

        protected override async void LoadedExecute()
        {
            var queries = await _storedQueryRepository.GetAll();
            Queries.AddRange(queries);
        }

        private readonly IStoredQueryRepository _storedQueryRepository;

    }
}
