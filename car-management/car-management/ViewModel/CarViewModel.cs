using System.Collections.ObjectModel;
using System.Windows.Input;
using car_management.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace car_management.ViewModel
{
    public class CarViewModel : ViewModelBase
    {
        private ObservableCollection<CarRefuelViewModel> _carRefuelViewModels;
        private ObservableCollection<CarMaintainanceViewModel> _carMaintainanceViewModels;
        public Car Car { get; set; }

        public CarViewModel(Car car)
        {
            Car = car;
        }

        public string Name
        {
            get
            {
                if (IsInDesignMode)
                {
                    return "SCHUBIDU";
                }
                else
                {
                    return _name;
                }
            }
            set { _name = value; }
        }
        private string _name;

        public ICommand BackCommand
        {
            get
            {
                return new RelayCommand(()=>MainViewModel.Instance.NavigateToCarSelection());
            }
        }

        public ObservableCollection<CarRefuelViewModel> CarRefuelViewModels
        {
            get { return _carRefuelViewModels ; }
            set { _carRefuelViewModels = value; }
        }

        public ObservableCollection<CarMaintainanceViewModel> CarMaintainanceViewModels
        {
            get { return _carMaintainanceViewModels; }
            set { _carMaintainanceViewModels = value; }
        }
    }
}