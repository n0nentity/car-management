using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using car_management.Common;

namespace car_management.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class NameWindowModel : ViewModelBase
    {
        private List<string> notValid { get; set; }

        /// <summary>
        /// Initializes a new instance of the NameWindowModel class.
        /// </summary>
        public NameWindowModel()
        {

        }

        public NameWindowModel(List<string> NotValid, string startName)
        {
            notValid = NotValid;
            name = startName;
        }

        public string Name
        {
            get
            {
                if (IsInDesignMode)
                    return "Name";
                return name;
            }
            set
            {
                name = value;
            }
        }
        private string name
        {
            get
            {
                return displayedname;
            }
            set
            {
                displayedname = value;
                if (displayedname == "")
                {
                    ErrorMessage = "Please enter a name!";
                }
                else if (notValid == null || !notValid.Contains(displayedname))
                {
                    savedname = displayedname;
                    ErrorMessage = null;
                }
                else
                {
                    ErrorMessage = "car name exists already";
                }
                RaisePropertyChanged("ErrorMessage");
                RaisePropertyChanged(() => Name);
            }
        }
        private string displayedname = "";
        private string savedname = "";

        public string ErrorMessage { get; set; }
    }
}