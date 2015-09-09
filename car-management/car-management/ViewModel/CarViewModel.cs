using car_management.Common;
using GalaSoft.MvvmLight;

namespace car_management.ViewModel
{
    public class CarViewModel : ViewModelBase
    {
        public Car Car { get; set; }

        public CarViewModel(Car car)
        {
            Car = car;
        }
    }
}