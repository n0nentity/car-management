using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using car_management.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace car_management.ViewModel
{
    class CreateProjectViewModel : ViewModelBase
    {
        public ICommand CreateProjectCommand
        {
            get
            {
                return new RelayCommand(createNewProject);
            }
        }

        public ICommand LoadProjectCommand
        {
            get
            {
                return new RelayCommand(loadProject);
            }
        }

        private void createNewProject()
        {
            var fileDialog = new SaveFileDialog();
            // Set filter options and filter index.
            fileDialog.Filter = "CXML Files (.cxml)|*.cxml|All Files (*.*)|*.*";
            fileDialog.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box.
            var userClickedOk = fileDialog.ShowDialog();
            // Process input if the user clicked OK.
            if (userClickedOk == true)
            {
                FileInfo file = new FileInfo(fileDialog.FileName);
                 using (FileStream fs = file.Create()){}
                Project project = DataManager.Instance.LoadProject();
                project.XmlDatabaseFilePath = file.FullName;
                DataManager.Instance.SaveProject(project);
                DataManager.Instance.LoadCars();
                MainViewModel.Instance.NavigateToCarSelection();
            }           
        }

        private void loadProject()
        {
            string filePath = DataManager.Instance.GetXmlDataFilePath();
            if (!string.IsNullOrEmpty(filePath))
            {
                Project project = DataManager.Instance.LoadProject();
                project.XmlDatabaseFilePath = filePath;
                DataManager.Instance.SaveProject(project);
                DataManager.Instance.LoadCars();
                 MainViewModel.Instance.NavigateToCarSelection();
            }
        }
    }
}
