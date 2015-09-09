using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Xml.Serialization;

namespace car_management.Common
{
    public class Car
    {
        private List<CarMaintainance> _carMaintainanceList;
        private List<CarRefuel> _refuleList;

        [XmlElement("CarMaintainance")]
        public List<CarMaintainance> CarMaintainanceList
        {
            get { return _carMaintainanceList ?? (_carMaintainanceList = new List<CarMaintainance>()); }
            set { _carMaintainanceList = value; }
        }
        [XmlElement("Refuel")]
        public List<CarRefuel> RefuelList
        {
            get { return _refuleList ?? (_refuleList = new List<CarRefuel>()); }
            set { _refuleList = value; }
        }
    }
}