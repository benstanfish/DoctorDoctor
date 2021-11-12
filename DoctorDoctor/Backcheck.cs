using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    [XmlRoot(ElementName ="backcheck")]
    public class Backcheck
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; } 
        [XmlElement(ElementName ="id")]
        public int Id { get; set; }
        [XmlElement(ElementName ="comment")]
        public int CommentId { get; set; } 
        [XmlElement(ElementName ="evaluation")]
        public int EvaluationID { get; set; }    
        [XmlElement(ElementName ="status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "backcheckText")]
        public string BackcheckText { get; set; }
        [XmlElement(ElementName = "attachment")]
        public string Attachment { get; set; }
        [XmlElement(ElementName = "createdBy")]
        public string CreatedBy { get; set; }
        [XmlElement(ElementName = "createdOn")]
        public string CreatedOn { get; set; }

        public Backcheck()
        {
        }

        public Backcheck(string name, int id, int commentId, int evaluationId, string status, string backcheckText, string attachment, string createdBy, string createdOn)
        {
            Name = name;
            Id = id;
            CommentId = commentId;
            EvaluationID = evaluationId;
            Status = status;
            BackcheckText = backcheckText;
            Attachment = attachment;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
        }



        public void WriteToFile(string filePath)
        {
            var xml = new XmlSerializer(typeof(Backcheck));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static Backcheck ReadFromFile(string filePath)
        {
            var xml = new XmlSerializer(typeof(Backcheck));
            using (var reader = new StreamReader(filePath))
            {
                return (Backcheck)xml.Deserialize(reader);
            }
        }

        public override string ToString()
        {
            return $"---- Backcheck Object ----\n" +
            $"Name: {Name}\n" +
            $"Id: {Id}\n" +
            $"CommentId: {CommentId}\n" +
            $"EvaluationId: {EvaluationID}\n" +
            $"Status: {Status}\n" +
            $"BackcheckText: {BackcheckText}\n" +
            $"Attachment: {Attachment}\n" +
            $"CreatedBy: {CreatedBy}\n" +
            $"CreatedOn: {CreatedOn}\n";
        }
    }
}
