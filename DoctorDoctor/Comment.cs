using System.ComponentModel;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    [XmlRoot(ElementName ="comment")]
    public class Comment
    {
        [Category("ID")]
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [Category("Reference")]
        [XmlElement(ElementName = "spec")]
        public string Spec { get; set; }
        [Category("Reference")]
        [XmlElement(ElementName = "sheet")]
        public string Sheet { get; set; }
        [Category("Reference")]
        [XmlElement(ElementName = "detail")]
        public string Detail { get; set; }
        [Category("Status")]
        [XmlElement(ElementName = "critical")]
        public string Critical { get; set; }
        [Category("Content")]
        [XmlElement(ElementName = "commentText")]
        public string CommentText { get; set; }
        [Category("Content")]
        [XmlElement(ElementName = "attachment")]
        public string Attachment { get; set; }
        [Category("Reference")]
        [XmlElement(ElementName = "DocRef")]
        public string DocRef { get; set; }
        [Category("Authorship")]
        [XmlElement(ElementName = "createdBy")]
        public string CreatedBy { get; set; }
        [Category("Authorship")]
        [XmlElement(ElementName ="createdOn")]
        public string CreatedOn { get; set; }
        [Category("ID")]
        [XmlElement(ElementName = "Discipline")]
        public string Discipline { get; set; }
        [Category("Status")]
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [Browsable(false)]
        [XmlArray(ElementName ="evaluations")]
        [XmlArrayItem("evaluation")]
        public List<Evaluation> Evaluations { get; set; }
        [Browsable(false)]
        [XmlArray(ElementName = "backchecks")]
        [XmlArrayItem("backcheck")]
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

        public void WriteToFile(string filePath)
        {
            var xml = new XmlSerializer(typeof(Comment));
            if (File.Exists(filePath))
                File.Delete(filePath);
            var writer = new StreamWriter(filePath);
            xml.Serialize(writer, this);
            writer.Close();
        }

        public static Comment ReadFromFile(string filePath)
        {
            var xml = new XmlSerializer(typeof(Comment));
            using (var reader = new StreamReader(filePath))
            {
                return (Comment)xml.Deserialize(reader);
            }
        }

        public override string ToString()
        {
            return this.Id.ToString();
            //return $"----- Comment Object -----\n" +

            //$"Id: {Id}\n" +
            //$"Spec: {Spec}\n" +
            //$"Sheet: {Sheet}\n" +
            //$"Detail: {Detail}\n" +
            //$"Critical: {Critical}\n" +
            //$"CommentText: {CommentText}\n" +
            //$"Attachment: {Attachment}\n" +
            //$"DocRef: {DocRef}\n" +
            //$"CreatedBy: {CreatedBy}\n" +
            //$"CreatedOn: {CreatedOn}\n" +
            //$"Status: {Status}\n" +
            //$"Discipline: {Discipline}\n" +
            //$"Evaluations: {EvaluationCount()}\n" +
            //$"Backchecks: {BackcheckCount()}\n"
            //;
        }
    }
}
