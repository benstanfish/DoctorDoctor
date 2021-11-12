using System.Xml.Serialization;

namespace DoctorDoctor
{
    [XmlRoot(ElementName ="comment")]
    public class Comment
    {   
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "spec")]
        public string Spec { get; set; }
        [XmlElement(ElementName = "sheet")]
        public string Sheet { get; set; }
        [XmlElement(ElementName = "detail")]
        public string Detail { get; set; }
        [XmlElement(ElementName = "critical")]
        public string Critical { get; set; }
        [XmlElement(ElementName = "commentText")]
        public string CommentText { get; set; }
        [XmlElement(ElementName = "attachment")]
        public string Attachment { get; set; }
        [XmlElement(ElementName = "DocRef")]
        public string DocRef { get; set; }
        [XmlElement(ElementName = "createdBy")]
        public string CreatedBy { get; set; }
        [XmlElement(ElementName ="createdOn")]
        public string CreatedOn { get; set; }
        [XmlElement(ElementName = "Discipline")]
        public string Discipline { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [XmlElement(ElementName ="evaluations")]
        public List<Evaluation> Evaluations { get; set; }
        [XmlElement(ElementName = "backchecks")]
        public List<Backcheck> Backchecks { get; set; }

        public Comment()
        {
        }

        public Comment(int id, string spec, string sheet, string detail, 
            string critical, string commentText, string attachment, string docRef,
            string createdBy, string createdOn, string discipline, string status, 
            List<Evaluation> evaluations, List<Backcheck> backchecks)
        {
            Id = id;
            Spec = spec;
            Sheet = sheet;
            Detail = detail;
            Critical = critical;
            CommentText = commentText;
            Attachment = attachment;
            DocRef = docRef;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            Discipline = discipline;
            Status = status;
            Evaluations = evaluations;
            Backchecks = backchecks;
        }

        public int EvaluationCount()
        {
            return Evaluations.Count;
        }
        public int BackcheckCount()
        {
            return Backchecks.Count;
        }

        public void Write(string filePath)
        {
            var xml = new XmlSerializer(typeof(Comment));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static Comment Read(string filePath)
        {
            var xml = new XmlSerializer(typeof(Comment));
            using (var reader = new StreamReader(filePath))
            {
                return (Comment)xml.Deserialize(reader);
            }
        }

        public override string ToString()
        {
            return $"----- Comment Object -----\n" +

            $"Id: {Id}\n" +
            $"Spec: {Spec}\n" +
            $"Sheet: {Sheet}\n" +
            $"Detail: {Detail}\n" +
            $"Critical: {Critical}\n" +
            $"CommentText: {CommentText}\n" +
            $"Attachment: {Attachment}\n" +
            $"DocRef: {DocRef}\n" +
            $"CreatedBy: {CreatedBy}\n" +
            $"CreatedOn: {CreatedOn}\n" +
            $"Status: {Status}\n" +
            $"Discipline: {Discipline}\n" +
            $"Evaluations: {EvaluationCount()}\n" +
            $"Backchecks: {BackcheckCount()}\n" +
            $"-------------------------"
            ;
        }
    }
}
