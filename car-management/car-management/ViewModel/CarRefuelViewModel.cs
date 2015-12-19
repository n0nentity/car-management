using System;
using System.Globalization;
using car_management.Common;
using OxyPlot;
using OxyPlot.Axes;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace car_management.ViewModel
{
    public class CarRefuelViewModel : ViewModelBase
    {
        public CarRefuelViewModel()
        {
            if (!IsInDesignMode)
                throw new Exception("this ctro is for designtime only");
        }

        public CarRefuel CarRefuel { get; set; }

        public CarRefuelViewModel(CarRefuel refuel)
        {
            CarRefuel = refuel;
        }

        public string DateString
        {
            get
            {
                if (IsInDesignMode)
                    return "01.01.1990";

                return CarRefuel.Date.ToShortDateString();
            }
            set
            {
                //todo
            }
        }
        public DateTime Date
        {
            get
            {
                if (IsInDesignMode)
                    return DateTime.Today;

                return CarRefuel.Date;
            }
            set
            {
                CarRefuel.Date = value;
            }
        }


        //static int ctor = 0;
        public DataPoint Point
        {
            get
            {
                return new DataPoint(DateTimeAxis.ToDouble(Date), CarRefuel.CostPerLiter);
            }
        }

        public string Liters
        {
            get
            {
                if (IsInDesignMode)
                    return "55,36 l";

                return CarRefuel.Liter.ToString() + " l";
            }
            set
            {
                double result = 0;
                if (double.TryParse(value, out result))
                {
                    CarRefuel.Liter = result;
                }
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
            set
            {
                double result = 0;
                if (double.TryParse(value, out result))
                {
                    CarRefuel.CostPerLiter = result;
                }
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
            set
            {
                UInt64 result = 0;
                if (UInt64.TryParse(value, out result))
                {
                    CarRefuel.Kilometers = result;
                }
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