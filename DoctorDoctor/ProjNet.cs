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

        public void WriteToFile(string filePath)
        {
            var xml = new XmlSerializer(typeof(ProjNet));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static ProjNet ReadFromFile(string filePath)
        {
            try
            {
                var xml = new XmlSerializer(typeof(ProjNet));
                using (var reader = new StreamReader(filePath))
                {
                    return (ProjNet)xml.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(text: "File type not recognized.", caption: "File Type Error");
                return new ProjNet();
            }
            
        }

        public override string ToString()
        {
            string docChecks = $"----- ProjNet Object -----\n" + this.DoctorChecks.ToString();
            return docChecks + "\nComment Count: " + CommentCount() + "\n";
        }

        public List<string> GetDisciplines()
        {
            //TODO: Use GetDisciplines to create discipline parent nodes in Treeview list

            List<string> NonUnique = new List<string>();
            List<string> Disciplines = new List<string>();
            foreach (var comment in Comments)
            {
                NonUnique.Add(comment.Discipline);
            }
            Disciplines = NonUnique.Distinct().ToList();    
            Disciplines.Sort();                                 //HACK: Alphabetize disciplines
            return Disciplines;
        }

    }
}
