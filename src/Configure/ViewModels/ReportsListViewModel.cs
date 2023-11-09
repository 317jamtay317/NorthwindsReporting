using System.Collections.ObjectModel;
using System.Windows.Input;
using DAL.Repositories.Reports;
using Models;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using Shared.Mvvm;

namespace Configure.ViewModels
{
    internal class ReportsListViewModel : LoadedViewModelBase
    {

        public ReportsListViewModel(IReportsRepository reportsRepository,
            IRegionManager regionManager,
            IDialogService dialogService)
        {
            _reportsRepository = reportsRepository;
            _regionManager = regionManager;
            _dialogService = dialogService;
            CreateCommand = new DelegateCommand(CreateExecute);
            DeleteCommand = new DelegateCommand(DeleteExecute, ()=> SelectedReport != null);
            GoToCommand = new DelegateCommand(GoToExecute, () => SelectedReport != null);
        }

        /// <summary>
        /// List of all the saved reports
        /// </summary>
        public ObservableCollection<Report> Reports { get; } = new();

        /// <summary>
        /// Command to ask the user what type of report
        /// they want and navigate to the builder
        /// </summary>
        public ICommand CreateCommand { get; }

        /// <summary>
        /// Deletes the report from the database
        /// </summary>
        public ICommand DeleteCommand { get; }

        /// <summary>
        /// Navigates to the selected report in the correct
        /// report builder
        /// </summary>
        public ICommand GoToCommand { get; }

        /// <summary>
        /// The selected report
        /// </summary>
        public Report? SelectedReport
        {
            get => GetValue<Report>();
            set => SetValue(value);
        }

        protected override async void LoadedExecute()
        {
            var reports = await _reportsRepository.GetAll();
            Reports.Clear();
            Reports.AddRange(reports);
        }

        private void DeleteExecute()
        {
            _dialogService.ShowDialog();
        }

        private void CreateExecute()
        {
            throw new NotImplementedException();
        }

        private void GoToExecute()
        {
            throw new NotImplementedException();
        }

        private readonly IReportsRepository _reportsRepository;
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
    }
}
