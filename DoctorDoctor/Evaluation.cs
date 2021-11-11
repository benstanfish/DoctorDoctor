using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    internal class Evaluation
    {
           
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }                // Corresponds to evaluation1, evaluation2, etc., in original XML
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "comment")]
        public int Comment { get; set; }                // Corresponding Comment ID
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "impactScope")]
        public string ImpactScope { get; set; }
        [XmlElement(ElementName = "impactCost")]
        public string ImpactCost { get; set; }
        [XmlElement(ElementName = "impactTime")]
        public string ImpactTime { get; set; }
        [XmlElement(ElementName = "evaluationText")]
        public string EvaluationText { get; set; }
        [XmlElement(ElementName = "attachment")]
        public string? Attachment { get; set; }
        [XmlElement(ElementName = "createdBy")]
        public string CreatedBy { get; set; }
        [XmlElement(ElementName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        public Evaluation()
        {
            //TODO: Determine if Evaluation default ctor should be error constructor, or used for typical import
            Name = "evaluation";
            Id = -1;
            Comment = -1;
            Status = "closed";
            ImpactScope = "none";
            ImpactCost = "none";
            ImpactTime = "none";
            EvaluationText = "<default constructor used>";
            Attachment = null;
            CreatedBy = "none";
            CreatedOn = DateTime.Now;
        }

        //TODO: Create additional ctors

              
        public static Evaluation Load(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(Evaluation));
                return (Evaluation)XML.Deserialize(stream);
            }
        }
    }
}
