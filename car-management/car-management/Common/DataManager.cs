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

        private List<Car> _cars;

        private DataManager()
        {
        }

        public static DataManager Instance
        {
            get { return lazy.Value; }
        }

        public Project Project { get; set; }

        public List<Car> Cars
        {
            get { return _cars ?? (_cars = new List<Car>()); }
            set { _cars = value; }
        }

        public string GetXmlDataFilePath()
        {
            var fileDialog = new OpenFileDialog();

            // Set filter options and filter index.
            fileDialog.Filter = "XML Files (.xml)|*.xml|All Files (*.*)|*.*";
            fileDialog.FilterIndex = 1;

            fileDialog.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            var userClickedOk = fileDialog.ShowDialog();
            var filePath = "";
            // Process input if the user clicked OK.
            if (userClickedOk == true)
            {
                // Open the selected file to read.
                var fileStream = fileDialog.OpenFile();

                using (var reader = new StreamReader(fileStream))
                {
                    // Read the first line from the file and write it the textbox.
                    filePath = reader.ReadLine();
                }
                fileStream.Close();
            }
            return filePath;
        }

        public void SaveProject(Project project)
        {
            var serializer = new XmlSerializer(typeof (Project));
            using (TextWriter writer = new StreamWriter(GetAppDataProjectFilePath()))
            {
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
                    var loadProject = obj as Project;
                    return loadProject;
                }
            }
            return null;
        }

        public string GetAppDataPath()
        {
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appDataProjectDirectory = Path.Combine(appdata, "Broselge");
            Directory.CreateDirectory(appDataProjectDirectory);
            return appDataProjectDirectory;
        }

        public string GetAppDataProjectFilePath()
        {
            return Path.Combine(GetAppDataPath() + "project.xml");
        }
    }
}