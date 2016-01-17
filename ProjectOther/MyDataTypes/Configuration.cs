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
        [XmlElement]
        public int inputDelay;
        [XmlElement]
        public String start;
        [XmlElement]
        public String select;
        [XmlElement]
        public String forward;
        [XmlElement]
        public String backward;
        [XmlElement]
        public String up;
        [XmlElement]
        public String down;
        [XmlElement]
        public String left;
        [XmlElement]
        public String right;
        [XmlElement]
        public String sp1;
        [XmlElement]
        public String sp2;
        [XmlElement]
        public String fpsToggle;
    }
}
