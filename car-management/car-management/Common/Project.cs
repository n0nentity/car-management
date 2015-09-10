using System;
using System.Xml.Serialization;

namespace car_management.Common
{
    public class Project
    {
        [XmlElement("Filepath")]
        public string XmlDatabaseFilePath;
        [XmlElement("SaveDateTime")]
        public string Date
        {
            get { return DateTime.Now.ToString("yyyy_MM_dd_HH_mm"); }
        }
    }
}