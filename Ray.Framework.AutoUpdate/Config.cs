using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Ray.Framework.AutoUpdate
{
    public class Config
    {
        public bool Enabled { get; set; }

        public string ServerUrl { get; set; }

        public UpdateFileList UpdateFileList { get; set; }

        public static Config LoadConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            StreamReader sr = new StreamReader(file);
            Config config = xs.Deserialize(sr) as Config;
            sr.Close();

            return config;
        }

        public void SaveConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            StreamWriter sw = new StreamWriter(file);
            xs.Serialize(sw, this);
            sw.Close();
        }
    }

    public class UpdateFileList : List<LocalFile>
    {
    }
}
