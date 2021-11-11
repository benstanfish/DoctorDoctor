using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDoctor
{
    internal class Evaluation
    {
        public int iteration { get; set; }
        public string commentType { get; set; }         // Corresponds to evaluation1, evaluation2, etc., in original XML
        public int id { get; set; }                     
        public int comment { get; set; }                // Corresponding Comment ID
        public string status { get; set; }
        public string impactScope { get; set; }
        public string impactCost { get; set; }
        public string impactTime { get; set; }
        public string evaluationText { get; set; }
        public string? attachment { get; set; }
        public string createdBy { get; set; }
        public DateTime createdOn { get; set; }

        public Evaluation()
        {
            //TODO: Determine if Evaluation default ctor should be error constructor, or used for typical import
            iteration = 1;
            commentType = "evaluation";
            id = -1;
            comment = -1;
            status = "closed";
            impactScope = "none";
            impactCost = "none";
            impactTime = "none";
            evaluationText = "<default constructor used>";
            attachment = null;
            createdBy = "none";
            createdOn = DateTime.Now;
        }

        //TODO: Create additional ctors
    }
}
