using car_management.Common;
using GalaSoft.MvvmLight;

namespace car_management.ViewModel
{
    public class CarMaintainanceViewModel:ViewModelBase
    {
        public CarMaintainance CarMaintainance { get; set; }

        public CarMaintainanceViewModel(CarMaintainance maintainance)
        {
            CarMaintainance = maintainance;
        }
    }
}