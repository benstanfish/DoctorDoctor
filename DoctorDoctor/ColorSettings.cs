using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    [XmlRoot]
    public class ColorSettings
    {

        [XmlIgnore]
        public Color OpenColor { get; set; }
        [XmlIgnore]
        public Color ClosedColor { get; set; }
        [XmlIgnore]
        public Color ConcurColor { get; set; }
        [XmlIgnore]
        public Color ForInformationOnlyColor { get; set; }
        [XmlIgnore]
        public Color NonConcurColor { get; set; }
        [XmlIgnore]
        public Color CheckAndResolveColor { get; set; }

        [Category("Description")]
        [XmlElement("Description")]
        public string ColorNameInstructions { get; set; } = @"Color names can be found at https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color?view=net-5.0. These are standard 'Web Colors' and can be observed at https://developer.mozilla.org/en-US/docs/Web/CSS/color_value. When entering names in the XML file manually, make sure there are no spaces and ProperCase is used as per the MSFT link above.";
        [XmlElement("Open")]
        public string Open
        {
            get { return this.OpenColor.ToString(); }
            set { this.OpenColor = Color.FromName(value); } 
        }
        [XmlElement("Closed")]
        public string Closed
        {
            get { return this.ClosedColor.ToString(); }
            set { this.ClosedColor = Color.FromName(value); }
        }
        [XmlElement("Concur")]
        public string Concur
        {
            get { return this.ConcurColor.ToString(); }
            set { this.ConcurColor = Color.FromName(value); }
        }
        [XmlElement("Nonconcur")]
        public string NonConcur
        {
            get { return this.NonConcurColor.ToString(); }
            set { this.NonConcurColor = Color.FromName(value); }
        }
        [XmlElement("ForInformationOnly")]
        public string Information
        {
            get { return this.ForInformationOnlyColor.ToString(); }
            set { this.ForInformationOnlyColor = Color.FromName(value); }
        }
        [XmlElement("CheckAndResolve")]
        public string Check
        {
            get { return this.CheckAndResolveColor.ToString(); }
            set { this.CheckAndResolveColor = Color.FromName(value); }
        }


        public ColorSettings()
        {
        }

        public ColorSettings(string open, string closed, 
            string concur, string nonConcur, string information, 
            string check)
        {
            Open = open;
            Closed = closed;
            Concur = concur;
            NonConcur = nonConcur;
            Information = information;
            Check = check;
        }

        public void SaveColorSettings()
        {
            string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DoctorDoctor\";
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }
            WriteToFile(appFolder + @"colorconfig.xml");
        }

        public static ColorSettings GetColorSettings()
        {
            string configPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DoctorDoctor\colorconfig.xml";
            ColorSettings cs = new ColorSettings();
            if (File.Exists(configPath))
            {
                cs.ReadFromFile(configPath);
            }
            else
            {
                cs.WriteToFile(configPath);
            }
            return cs;
        }

        public void WriteToFile(string filePath)
        {
            var xml = new XmlSerializer(typeof(ColorSettings));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public ColorSettings ReadFromFile(string filePath)
        {
            var xml = new XmlSerializer(typeof(ColorSettings));
            using (var reader = new StreamReader(filePath))
            {
                return (ColorSettings)xml.Deserialize(reader);
            }
        }
    }
}
