﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using car_management.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

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
                    ObservableCollection<CarViewModel> cars = new ObservableCollection<CarViewModel>();
                    DataManager.Instance.Cars.Cars.ForEach(c => cars.Add(new CarViewModel(c)));
                    return cars;
                }
            }
        }

        public ICommand LoadCarsCommand
        {
            get
            {
                return new RelayCommand(LoadCars);
            }
        }

        void LoadCars()
        {
            string filePath = DataManager.Instance.GetXmlDataFilePath();
            if (!string.IsNullOrEmpty(filePath))
            {
                Project project = DataManager.Instance.LoadProject();
                project.XmlDatabaseFilePath = filePath;
                DataManager.Instance.SaveProject(project);
                DataManager.Instance.LoadCars();
            }

        }

        public ICommand AddCarCommand
        {
            get
            {
                return new RelayCommand(AddCar);
            }
        }

        void AddCar()
        {
            DataManager.Instance.Cars.Cars.Add(new Car(){Name = "newCar"});
            RaisePropertyChanged(() => CarViewModels);


        }


    }
}
