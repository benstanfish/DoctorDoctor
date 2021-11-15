using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    [XmlRoot(ElementName ="evaluation")]
    public class Evaluation
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [Category("ID")]
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [Category("ID")]
        [XmlElement(ElementName = "comment")]
        public int CommentId { get; set; }
        [Category("Status")]
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [Category("Impact")]
        [XmlElement(ElementName = "impactScope")]
        public string ImpactScope { get; set; }
        [Category("Impact")]
        [XmlElement(ElementName = "impactCost")]
        public string ImpactCost { get; set; }
        [Category("Impact")]
        [XmlElement(ElementName = "impactTime")]
        public string ImpactTime { get; set; }
        [Category("Content")]
        [XmlElement(ElementName ="evaluationText")]
        public string EvaluationText { get; set; }
        [Category("Content")]
        [XmlElement(ElementName = "attachment")]
        public string Attachment { get; set; }
        [Category("Authorship")]
        [XmlElement(ElementName = "createdBy")]
        public string CreatedBy { get; set; }
        [Category("Authorship")]
        [XmlElement(ElementName = "createdOn")]
        public string CreatedOn { get; set; }

        public Evaluation()
        {
        }

        public Evaluation(string name, int id, int comment, string status, string impactScope, string impactCost,
            string impactTime, string evaluationText, string attachment, string createdBy, string createdOn)
        {
            Name = name;
            Id = id;
            CommentId = comment;
            Status = status;
            ImpactScope = impactScope;
            ImpactCost = impactCost;
            ImpactTime = impactTime;
            EvaluationText = evaluationText;
            Attachment = attachment;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
        }

        public void WriteToFile(string filePath)
        {
            var xml = new XmlSerializer(typeof(Evaluation));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static Evaluation ReadFromFile(string filePath)
        {
            var xml = new XmlSerializer(typeof(Evaluation));
            using (var reader = new StreamReader(filePath))
            {
                return (Evaluation)xml.Deserialize(reader);
            }
        }

        public override string ToString()
        {
            return $"--- Evaluation Object ---\n" +
            $"Name: {Name}\n" +
            $"Id: {Id}\n" +
            $"CommentId: {CommentId}\n" +
            $"Status: {Status}\n" +
            $"ImpactScope: {ImpactScope}\n" +
            $"ImpactCost: {ImpactCost}\n" +
            $"ImpactTime: {ImpactTime}\n" +
            $"EvaluationText: {EvaluationText}\n" +
            $"Attachment: {Attachment}\n" +
            $"CreatedBy: {CreatedBy}\n" +
            $"CreatedOn: {CreatedOn}\n"
            ;
        }


    }
}
