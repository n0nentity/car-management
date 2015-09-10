using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace car_management.ViewModel
{
    class CarSelectionViewModel : ViewModelBase
    {

        public CarSelectionViewModel()
        {
            if (IsInDesignMode)
            {

            }
            else
            {
                
            }
        }

        public ObservableCollection<CarViewModel> CarViewModels
        {
            get
            {
                if (IsInDesignMode)
                {
                    return new ObservableCollection<CarViewModel>() { new CarViewModel(null), new CarViewModel(null) };
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
