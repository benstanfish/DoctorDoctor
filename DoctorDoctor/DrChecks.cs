using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    [XmlRoot("DrChecks")]
    public class DrChecks
    {
        [XmlElement(elementName:"ProjectID")]
        public int ProjectId { get; set; }
        [XmlElement(elementName: "ProjectControlNbr")]
        public string ProjectControlNbr { get; set; }
        [XmlElement(elementName: "ProjectName")]
        public string ProjectName { get; set; }
        [XmlElement(elementName: "ReviewID")]
        public int ReviewId { get; set; }
        [XmlElement(elementName: "ReviewName")]
        public string ReviewName { get; set; }

        public DrChecks()
        {
        }

        public DrChecks(int projectId, string projectControlNbr, string projectName,
            int reviewId, string reviewName)
        {
            ProjectId = projectId;
            ProjectControlNbr = projectControlNbr;
            ProjectName = projectName;
            ReviewId = reviewId;
            ReviewName = reviewName;
        }

        public void Write(string filePath)
        {
            var xml = new XmlSerializer(typeof(DrChecks));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static DrChecks Read(string filePath)
        {
            var xml = new XmlSerializer(typeof(DrChecks));
            using (var reader = new StreamReader(filePath))
            {
                return (DrChecks)xml.Deserialize(reader);
            }
        }

        public override string ToString()
        {
            return $"--- DrChecks Object ---\n" +
            $"ProjectID: {ProjectId}\n" +
            $"ProjectControlNbr: {ProjectControlNbr}\n" +
            $"ProjectName: {ProjectName}\n" +
            $"ReviewID: {ReviewId}\n" +
            $"ReviewName: {ReviewName}\n"
            ;
        }
    }
}
