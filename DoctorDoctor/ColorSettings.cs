using System;
using System.Collections.Generic;
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
        public Color CheckAndResolveColor { get; set;}
        [XmlElement]
        public string ColorNameInstructions { get; set; }
        [XmlElement]
        public string OpenComments { get; set; }
        [XmlElement]
        public string ClosedComments { get; set; }
        [XmlElement]
        public string ConcurComments { get; set; }
        [XmlElement]
        public string NonConcurComments { get; set; } 
        [XmlElement]
        public string ForInformationOnlyComments { get; set; }
        [XmlElement]
        public string CheckAndResolveComments { get; set; }


        public ColorSettings()
        {
            ColorNameInstructions = @"Color names can be found at https://docs.microsoft.com/en-us/dotnet/api/system.drawing.color?view=net-5.0. These are standard 'Web Colors' and can be observed at https://developer.mozilla.org/en-US/docs/Web/CSS/color_value. When entering names in the XML file manually, make sure there are no spaces and ProperCase is used as per the MSFT link above.";
            OpenColor = Color.FromName(OpenComments);
            ClosedColor = Color.FromName(ClosedComments);
            ConcurColor = Color.FromName(ConcurComments);
            ForInformationOnlyColor = Color.FromName(ForInformationOnlyComments);
            NonConcurColor = Color.FromName(NonConcurComments);
            CheckAndResolveColor = Color.FromName(CheckAndResolveComments);
        }

        public ColorSettings(string openComments, string closedComments, string concurComments, string nonConcurComments,
            string forInformationOnlyComments, string checkAndResolveComments)
        {
            OpenComments = openComments;
            ClosedComments = closedComments;
            ConcurComments = concurComments;
            NonConcurComments = nonConcurComments;
            ForInformationOnlyComments = forInformationOnlyComments;
            CheckAndResolveComments = checkAndResolveComments;
            OpenColor = Color.FromName(OpenComments);
            ClosedColor = Color.FromName(ClosedComments);
            ConcurColor = Color.FromName(ConcurComments);
            ForInformationOnlyColor = Color.FromName(ForInformationOnlyComments);
            NonConcurColor = Color.FromName(NonConcurComments);
            CheckAndResolveColor = Color.FromName(CheckAndResolveComments);
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
            if (File.Exists(configPath))
            {
                return ColorSettings.ReadFromFile(configPath);
            }
            return new ColorSettings();
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

        public static ColorSettings ReadFromFile(string filePath)
        {
            var xml = new XmlSerializer(typeof(ColorSettings));
            using (var reader = new StreamReader(filePath))
            {
                return (ColorSettings)xml.Deserialize(reader);
            }
        }
    }
}
