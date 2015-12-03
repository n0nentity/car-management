using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using car_management.Common;

namespace car_management.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

         public static MainViewModel Instance
        {
            get { return _instance; }
        }
        private static MainViewModel _instance;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _instance = this;
            CarSelectionViewModel = new CarSelectionViewModel();

            if (IsInDesignMode)
            {
                ActiveViewModel = new CarViewModel(null,null);
            }
            else
            {

            Project project = DataManager.Instance.LoadProject();
            if (project != null && !String.IsNullOrEmpty(project.XmlDatabaseFilePath))
            {
                DataManager.Instance.LoadCars();
                NavigateToCarSelection();
            }
            else
            {
                ActiveViewModel = new CreateProjectViewModel();
                RaisePropertyChanged(() => ActiveViewModel);
            }

            }
        }

        public ObservableObject ActiveViewModel { get; set; }

        public ObservableObject CarSelectionViewModel { get; set; }

        public void NavigateToCarSelection()
        {
            ActiveViewModel = CarSelectionViewModel;
            RaisePropertyChanged(() => ActiveViewModel);
        }

        public void NavigateToCar(CarViewModel carViewModel)
        {
            ActiveViewModel = carViewModel;
            RaisePropertyChanged(()=>ActiveViewModel);
        }

  
    }
}