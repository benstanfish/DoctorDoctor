using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    [XmlRoot(ElementName ="evaluations")]
    public class Evaluations
    {
        [XmlArray(ElementName = "evaluations")]
        public List<Evaluation> EvaluationsList { get; set; }

        public Evaluations()
        {
        }

        public Evaluations(List<Evaluation> evaluations)
        {
            EvaluationsList = evaluations;
        }

        public void Write(string filePath)
        {
            var xml = new XmlSerializer(typeof(Evaluations));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static Evaluations Read(string filePath)
        {
            var xml = new XmlSerializer(typeof(Evaluations));
            using (var reader = new StreamReader(filePath))
            {
                return (Evaluations)xml.Deserialize(reader);
            }
        }

    }
}
