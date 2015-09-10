using System.Globalization;
using car_management.Common;
using GalaSoft.MvvmLight;

namespace car_management.ViewModel
{
    public class CarRefuelViewModel : ViewModelBase
    {
        public CarRefuel CarRefuel { get; set; }

        public CarRefuelViewModel(CarRefuel refuel)
        {
            CarRefuel = refuel;
        }

        public string Date
        {
            get
            {
                if (IsInDesignMode)
                    return "01.01.1990";

                return CarRefuel.Date.ToShortDateString();
            }
        }

        public string Liters
        {
            get
            {
                if(IsInDesignMode)
                    return "55,36 l";

                return CarRefuel.Liter.ToString()+" l";
            }
        }

        public string CostPerLiter
        {
            get
            {
                if (IsInDesignMode)
                    return "1,10 €";

                return CarRefuel.CostPerLiter.ToString() + "€";
            }
        }

        public string KmCtr
        {
            get
            {
                if (IsInDesignMode)
                    return "10534";

                return CarRefuel.Kilometers.ToString() + " km";
            }
        }

        public string KmDif
        {
            get
            {
                if (IsInDesignMode)
                    return "123";

                //TODO: need parent with whole list!
                return CarRefuel.Kilometers.ToString() + " km";
            }
        }

    }
}