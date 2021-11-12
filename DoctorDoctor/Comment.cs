using System.Xml.Serialization;

namespace DoctorDoctor
{
    internal class Comment
    {
        [XmlElement(ElementName = "id")]
        public int ID { get; set; }
        [XmlElement(ElementName = "status")]
        public string status { get; set; }
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
        public string DocRef { get; set; }
        [XmlElement(ElementName = "createdBy")]
        public string CreatedBy { get; set; }
        [XmlElement(ElementName ="createdOn")]
        public DateTime CreatedOn { get; set; }
        public string Discipline { get; set; }
        [XmlArray("evaluations")]
        public List<Evaluation> Evaluations { get; set; }
        [XmlArray("backchecks")]
        public List<Backcheck> Backchecks { get; set; }

        public Comment()
        {
            //TODO: determine if this ctor is the most appropriate for import
            ID = -1;
            status = "closed";
            Spec = null;
            Sheet = null;
            Detail = null;
            Critical = "No";
            CommentText = "<default constructor used>";
            Attachment = null;
            DocRef = null;
            CreatedBy = "none";
            CreatedOn = DateTime.Now;
            Discipline = null;
            Evaluations = new List<Evaluation>();
            Backchecks = new List<Backcheck>();
        }



        //TODO: Add load from file


    }
}
