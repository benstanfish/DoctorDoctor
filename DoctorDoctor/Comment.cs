using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDoctor
{
    internal class Comment
    {
        public int id { get; set; }
        public string status { get; set; }
        public string? spec { get; set; }
        public string? sheet { get; set; }
        public string? detail { get; set; }
        public string critical { get; set; }
        public string commentText { get; set; }
        public string? attachment { get; set; }
        public string? DocRef { get; set; }
        public string createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public string? Discipline { get; set; }
        public List<Evaluation> evaluations { get; set; }
        public List<Backcheck> backchecks { get; set; }

        public Comment()
        {
            //TODO: determine if this ctor is the most appropriate for import
            id = -1;
            status = "closed";
            spec = null;
            sheet = null;
            detail = null;
            critical = "No";
            commentText = "<default constructor used>";
            attachment = null;
            DocRef = null;
            createdBy = "none";
            createdOn = DateTime.Now;
            Discipline = null;
            evaluations = new List<Evaluation>();
            backchecks = new List<Backcheck>();
        }

    }
}
