using MyDataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectOther.Util
{
    /// <summary>
    /// Class containing common functions for use throughout other parts of the code.
    /// </summary>
    class Utils
    {
        public static Configuration loadConfig()
        {
            //Load settings from file.
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            StreamReader reader = new StreamReader("Content/config.xml");
            Configuration config = (Configuration)serializer.Deserialize(reader);
            reader.Close();
            return config;
        }

        public void drawMenu()
        {

        }
    }
}
