using System;
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

        public CarViewModel()
        {
            if(!IsInDesignMode)
                throw new Exception();
        }

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
                    return Car.Name;
                }
            }
        }

        public ICommand CarSelectedCommand
        {
            get
            {
                return new RelayCommand(()=>MainViewModel.Instance.NavigateToCar(this));
            }
        }

        public ICommand BackCommand
        {
            get
            {
                return new RelayCommand(() => MainViewModel.Instance.NavigateToCarSelection());
            }
        }


        public ObservableCollection<CarRefuelViewModel> CarRefuelViewModels
        {
            get 
            {
                if (IsInDesignMode)
                {
                    return new ObservableCollection<CarRefuelViewModel>(){new CarRefuelViewModel(null), new CarRefuelViewModel(null)};
                }
                return _carRefuelViewModels ; 
            }
            set { _carRefuelViewModels = value; }
        }

        public ObservableCollection<CarMaintainanceViewModel> CarMaintainanceViewModels
        {
            get
            {
                if (IsInDesignMode)
                {
                    return new ObservableCollection<CarMaintainanceViewModel>() { new CarMaintainanceViewModel(null), new CarMaintainanceViewModel(null) };
                }
                return _carMaintainanceViewModels;
            }
            set { _carMaintainanceViewModels = value; }
        }
    }
}