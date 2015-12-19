using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using car_management.Common;
using car_management.View;
using car_management.Tools;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
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
            if (!IsInDesignMode)
                throw new Exception();
        }

        public CarSelectionViewModel Parent { get; set; }

        public CarViewModel(Car car, CarSelectionViewModel parent)
        {
            Car = car;
            Parent = parent;
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
                return new RelayCommand(() => MainViewModel.Instance.NavigateToCar(this));
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(deleteCar);
            }
        }

        private void deleteCar()
        {
            DataManager.Instance.Cars.Cars.Remove(Car);
            Parent.RaisePropertyChanged();
        }

        public ICommand RenameCommand
        {
            get
            {
                return new RelayCommand(renameCar);
            }
        }

        private void renameCar()
        {
            NameWindow window = new NameWindow();
            List<string> notvalid = DataManager.Instance.Cars.Cars.Select(c => c.Name).ToList();
            NameWindowModel nameVM = new NameWindowModel(notvalid, Name);
            window.DataContext = nameVM;
            if ((bool)window.ShowDialog())
            {
                Car.Name = nameVM.Name;
                RaisePropertyChanged(() => Name);
                DataManager.Instance.SaveCars();
            }
            Parent.RaisePropertyChanged();
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
                    return new ObservableCollection<CarRefuelViewModel>() { new CarRefuelViewModel(null), new CarRefuelViewModel(null) };
                }
                else
                {
                    if (_carRefuelViewModels == null)
                    {
                        _carRefuelViewModels = new ObservableCollection<CarRefuelViewModel>();
                    }
                    _carRefuelViewModels.Maintain(Car.RefuelList.Select(r => new CarRefuelViewModel(r)));
                }
                return _carRefuelViewModels;
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
                else
                {
                    if (_carMaintainanceViewModels == null)
                    {
                        _carMaintainanceViewModels = new ObservableCollection<CarMaintainanceViewModel>();
                    }
                    _carMaintainanceViewModels.Maintain(Car.CarMaintainanceList.Select(r => new CarMaintainanceViewModel(r)));
                }
                return _carMaintainanceViewModels;
            }
            set { _carMaintainanceViewModels = value; }
        }

        /// <summary>
        /// Gets the plot model.
        /// </summary>
        public PlotModel GraphModel
        {
            get
            {
                if (IsInDesignMode)
                {
                    // Create the plot model
                    PlotModel _graphModel = new PlotModel() { Title = "Verbrauchsdaten", Subtitle = "Autoname" };
                    //axes
                    _graphModel.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        StringFormat = "dd/MM/yyyy",
                        Title = "Datum",
                        //MinorIntervalType = DateTimeIntervalType.Months,
                        IntervalType = DateTimeIntervalType.Days,
                        //MajorGridlineStyle = LineStyle.Dash,
                        MinorGridlineStyle = LineStyle.Solid,
                    });

                    // Create two line series (markers are hidden by default)
                    var series1 = new LineSeries { Title = "Series 1", MarkerType = MarkerType.Circle };
                    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now), 0));
                    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(5)), 18));
                    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(12)), 12));
                    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(23)), 8));
                    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(49)), 15));


                    //var series2 = new LineSeries { Title = "Series 2", MarkerType = MarkerType.Square };
                    //series2.Points.Add(new DataPoint(0, 4));
                    //series2.Points.Add(new DataPoint(10, 12));
                    //series2.Points.Add(new DataPoint(20, 16));
                    //series2.Points.Add(new DataPoint(30, 25));
                    //series2.Points.Add(new DataPoint(40, 5));

                    // Add the series to the plot model
                    _graphModel.Series.Add(series1);
                    //_graphModel.Series.Add(series2);

                    return _graphModel;
                }
                else
                {
                    // Create the plot model
                    PlotModel _graphModel = new PlotModel() { Title = "Verbrauchsdaten", Subtitle = Name };
                    //axes
                    _graphModel.Axes.Add(new DateTimeAxis
                    {
                        Position = AxisPosition.Bottom,
                        StringFormat = "dd/MM/yyyy",
                        Title = "Datum",
                        //MinorIntervalType = DateTimeIntervalType.Months,
                        IntervalType = DateTimeIntervalType.Days,
                        //MajorGridlineStyle = LineStyle.Dash,
                        MinorGridlineStyle = LineStyle.Solid,
                    });

                    // Create two line series (markers are hidden by default)
                    var series1 = new LineSeries { Title = "Verbrauch", MarkerType = MarkerType.Circle };
                    foreach (CarRefuelViewModel crvm in CarRefuelViewModels)
                    {
                        series1.Points.Add(crvm.Point);
                    }
                    // Add the series to the plot model
                    _graphModel.Series.Add(series1);


                    return _graphModel;
                }

            }
        }

        public ICommand AddCarRefuelCommand
        {
            get
            {
                return new RelayCommand(addCarRefuel);
            }
        }

        private void addCarRefuel()
        {
            NewCarRefuelWindow window = new NewCarRefuelWindow();
            window.Owner = Application.Current.MainWindow;
            CarRefuel refuel = new CarRefuel();
            refuel.Date = DateTime.Today;
            CarRefuelViewModel refuelVM = new CarRefuelViewModel(refuel);
            window.DataContext = refuelVM;
            if ((bool)window.ShowDialog())
            {
                Car.RefuelList.Add(refuel);
                DataManager.Instance.SaveCars();
                RaisePropertyChanged(() => CarRefuelViewModels);
                RaisePropertyChanged(() => GraphModel);
            }
        }

    }
}