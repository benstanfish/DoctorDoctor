using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    [XmlRoot(ElementName ="evaluations")]
    public class WEvaluations
    {
        [XmlArray(ElementName = "evaluations")]
        public List<Evaluation> EvaluationsList { get; set; }

        public WEvaluations()
        {
        }

        public WEvaluations(List<Evaluation> evaluations)
        {
            EvaluationsList = evaluations;
        }

        public void Write(string filePath)
        {
            var xml = new XmlSerializer(typeof(WEvaluations));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static WEvaluations Read(string filePath)
        {
            var xml = new XmlSerializer(typeof(WEvaluations));
            using (var reader = new StreamReader(filePath))
            {
                return (WEvaluations)xml.Deserialize(reader);
            }
        }

    }
}
