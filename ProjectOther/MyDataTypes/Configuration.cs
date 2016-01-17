using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyDataTypes
{
    [XmlRoot()]
    [Serializable]
    public class Configuration
    {
        [XmlElement]
        public int fps;
        [XmlElement]
        public int resolutionLevel;
    }
}
