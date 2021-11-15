using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Diagnostics;

namespace DoctorDoctor
{
    [XmlRoot("ProjNet")]
    public class ProjNet
    {
        [XmlElement(ElementName ="DrChecks")]
        public DrChecks DoctorChecks { get; set; }

        [XmlIgnore]
        [Category("FilePath")]
        public static string ThisPath {get; set;}

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
            if(ProjNet.Validate(filePath))
            {
                var xml = new XmlSerializer(typeof(ProjNet));
                using (var reader = new StreamReader(filePath))
                {
                    ThisPath = filePath;
                    return (ProjNet)xml.Deserialize(reader);
                }
            }
            else
            {
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


        public static bool Validate(string filePath)
        {
            try
            {
                var xml = new XmlSerializer(typeof(ProjNet));
                using (var reader = new StreamReader(filePath))
                {
                    ProjNet projNet = (ProjNet)xml.Deserialize(reader);
                    if (projNet != null)
                    {
                        Debug.WriteLine("Point A");
                        return true;
                    }
                    else
                    {
                        Debug.WriteLine("Point B");
                        return false;
                    }
                     
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Point C");
                return false;
            }
        }


        public string GetPath()
        {
            return ThisPath;
        }


    }
}
