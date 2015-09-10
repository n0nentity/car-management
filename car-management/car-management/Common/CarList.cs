using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace car_management.Common
{
    [XmlRoot("Cars")]
    public class CarList
    {
        private List<Car> _cars= new List<Car>();

        [XmlElement("Car")]
        public List<Car> Cars
        {
            get { return _cars; }
            set { _cars = value; }
        }
    }
}
