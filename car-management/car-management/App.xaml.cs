using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using car_management.Common;

namespace car_management
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //TODO: show startup gui

            DataManager dataManager = DataManager.Instance;
            dataManager.LoadProject();

            base.OnStartup(e);
        }
    }
}
