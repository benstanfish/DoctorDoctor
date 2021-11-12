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
        public string Name { get; set; }            // Corresponds to backcheck1, backcheck2, etc., in original XML
        [XmlElement]
        public int id { get; set; }
        [XmlElement(ElementName ="comment")]
        public int commentId { get; set; }            // Corresponding Comment ID
        [XmlElement(ElementName ="evaluation")]
        public int evaluationId { get; set; }         // corresponding Evaluation ID
        [XmlElement]
        public string status { get; set; }
        public string backcheckText { get; set; }
        public string attachment { get; set; }
        public string createdBy { get; set; }
        public string createdOn { get; set; }

        public Backcheck()
        {
        }

        public Backcheck(string name, int ID, int CommentId, int EvaluationId, string Status, string BackcheckText, string Attachment, string CreatedBy, string CreatedOn)
        {
            Name = name;
            id = ID;
            commentId = CommentId;
            evaluationId = EvaluationId;
            status = Status;
            backcheckText = BackcheckText;
            attachment = Attachment;
            createdBy = CreatedBy;
            createdOn = CreatedOn;
        }



        public void Write(string filePath)
        {
            var xml = new XmlSerializer(typeof(Backcheck));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static Backcheck Read(string filePath)
        {
            var xml = new XmlSerializer(typeof(Backcheck));
            using (var reader = new StreamReader(filePath))
            {
                return (Backcheck)xml.Deserialize(reader);
            }
        }

        public override string ToString()
        {
            return $"--- Backcheck Object ---\n" +
            $"Name: {Name}\n" +
            $"Id: {id}\n" +
            $"CommentId: {commentId}\n" +
            $"EvaluationId: {evaluationId}\n" +
            $"Status: {status}\n" +
            $"BackcheckText: {backcheckText}\n" +
            $"Attachment: {attachment}\n" +
            $"CreatedBy: {createdBy}\n" +
            $"CreatedOn: {createdOn}\n" + $"-------------------------";
        }
    }
}
