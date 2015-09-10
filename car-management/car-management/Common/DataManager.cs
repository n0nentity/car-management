using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace car_management.Common
{
    public sealed class DataManager
    {
        private static readonly Lazy<DataManager> lazy =
            new Lazy<DataManager>(() => new DataManager());

        private DataManager()
        {
        }

        public static DataManager Instance
        {
            get { return lazy.Value; }
        }

        public Project Project { get; set; }

        public CarList Cars
        {
            get { return _cars ?? (_cars = new CarList()); }
            set { _cars = value; }
        }
        private CarList _cars;

        public string GetXmlDataFilePath()
        {
            var fileDialog = new OpenFileDialog();

            // Set filter options and filter index.
            fileDialog.Filter = "CXML Files (.cxml)|*.cxml|All Files (*.*)|*.*";
            fileDialog.FilterIndex = 1;

            fileDialog.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            var userClickedOk = fileDialog.ShowDialog();
            var filePath = "";
            // Process input if the user clicked OK.
            if (userClickedOk == true)
            {
                //// Open the selected file to read.
                //var fileStream = fileDialog.OpenFile();

                //using (var reader = new StreamReader(fileStream))
                //{
                //    // Read the first line from the file and write it the textbox.
                //    filePath = reader.ReadLine();
                //}
                //fileStream.Close();

                filePath = fileDialog.FileName;
            }
            return filePath;
        }

        public void SaveProject(Project project)
        {
            var serializer = new XmlSerializer(typeof (Project));
            using (TextWriter writer = new StreamWriter(GetAppDataProjectFilePath()))
            {
                //TODO: isn't saving the time!
                serializer.Serialize(writer, project);
            }
        }

        public Project LoadProject()
        {
            if (File.Exists(GetAppDataProjectFilePath()))
            {
                using (TextReader reader = new StreamReader(GetAppDataProjectFilePath()))
                {
                    var deserializer = new XmlSerializer(typeof (Project));
                    var obj = deserializer.Deserialize(reader);
                    _project = obj as Project;
                    return _project;
                }
            }
            _project = new Project();
            return _project;
        }
        private Project _project;

        public string GetAppDataPath()
        {
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appDataProjectDirectory = Path.Combine(appdata, "CarManagement");
            Directory.CreateDirectory(appDataProjectDirectory);
            return appDataProjectDirectory;
        }

        public string GetAppDataProjectFilePath()
        {
            return Path.Combine(GetAppDataPath(),"project.xml");
        }

        public void SaveCars()
        {
            Project loadProject = LoadProject();
            if (loadProject != null && !String.IsNullOrEmpty(loadProject.XmlDatabaseFilePath))
            {
                var serializer = new XmlSerializer(typeof(CarList));
                using (TextWriter writer = new StreamWriter(loadProject.XmlDatabaseFilePath))
                {
                    serializer.Serialize(writer, _cars);
                }
            }
        }

        public void LoadCars()
        {
            Project loadProject = LoadProject();
            if (loadProject != null && !String.IsNullOrEmpty(loadProject.XmlDatabaseFilePath))
            {
                using (TextReader reader = new StreamReader(loadProject.XmlDatabaseFilePath))
                {
                    var deserializer = new XmlSerializer(typeof(CarList));
                    var obj = deserializer.Deserialize(reader);
                    _cars = obj as CarList;
                }
            }
        }

    }
}