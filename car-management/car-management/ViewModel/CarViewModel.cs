using System.Collections.ObjectModel;
using car_management.Common;
using GalaSoft.MvvmLight;

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