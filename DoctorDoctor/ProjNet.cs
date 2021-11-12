using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    [XmlRoot("ProjNet")]
    public class ProjNet
    {
        [XmlElement(ElementName ="DrChecks")]
        public DrChecks DoctorChecks { get; set; }
        
        [XmlArray("Comments")]
        [XmlArrayItem("comment")]
        public List<Comment> Comments { get; set; }

        public ProjNet()
        {
        }

        public ProjNet(DrChecks dc, List<Comment> comments)
        {
            DoctorChecks = dc;
            Comments = comments;
        }

        public int CommentCount()
        {
            return Comments.Count;
        }

        public void Write(string filePath)
        {
            var xml = new XmlSerializer(typeof(ProjNet));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static ProjNet Read(string filePath)
        {
            var xml = new XmlSerializer(typeof(ProjNet));
            using (var reader = new StreamReader(filePath))
            {
                return (ProjNet)xml.Deserialize(reader);
            }
        }

        public override string ToString()
        {
            string docChecks = $"---- ProjNet Object ----\n" + this.DoctorChecks.ToString();
            return docChecks + "\nComment Count: " + CommentCount() + "\n";
        }
    }
}
