using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    [XmlRoot(ElementName ="evaluation")]
    public class Evaluation
    {
    
        [XmlAttribute]
        public string name { get; set; }    // Corresponds to evaluation1, evaluation2, etc., in original XML
        [XmlElement]
        public int id { get; set; }
        [XmlElement(ElementName ="comment")]
        public int commentId { get; set; } // Corresponding Comment ID
        public string status { get; set; }
        public string impactScope { get; set; }
        public string impactCost { get; set; }
        public string impactTime { get; set; }
        public string evaluationText { get; set; }
        public string attachment { get; set; }
        public string createdBy { get; set; }
        public string createdOn { get; set; }

        public Evaluation()
        {
        }

        public Evaluation(string Name, int ID, int Comment, string Status, string ImpactScope, string ImpactCost,
            string ImpactTime, string EvaluationText, string Attachment, string CreatedBy, string CreatedOn)
        {
            name = Name;
            id = ID;
            commentId = Comment;
            status = Status;
            impactScope = ImpactScope;
            impactCost = ImpactCost;
            impactTime = ImpactTime;
            evaluationText = EvaluationText;
            attachment = Attachment;
            createdBy = CreatedBy;
            createdOn = CreatedOn;
        }

        public void Write(string filePath)
        {
            var xml = new XmlSerializer(typeof(Evaluation));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static Evaluation Read(string filePath)
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
            $"Name: {name}\n" +
            $"Id: {id}\n" +
            $"CommentId: {commentId}\n" +
            $"Status: {status}\n" +
            $"ImpactScope: {impactScope}\n" +
            $"ImpactCost: {impactCost}\n" +
            $"ImpactTime: {impactTime}\n" +
            $"EvaluationText: {evaluationText}\n" +
            $"Attachment: {attachment}\n" +
            $"CreatedBy: {createdBy}\n" +
            $"CreatedOn: {createdOn}\n" + $"-------------------------"
            ;
        }


    }
}
