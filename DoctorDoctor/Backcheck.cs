using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDoctor
{
    internal class Backcheck
    {
        public int iteration { get; set; }              // Corresponds to backcheck1, backcheck2, etc., in original XML
        public int id { get; set; }
        public int comment { get; set; }    // Corresponding Comment ID
        public int evaluation { get; set; } // corresponding Evaluation ID
        public string status { get; set; }
        public string backcheckText { get; set; }
        public string? attachment { get; set; }
        public string createdBy { get; set; }
        public DateTime createdOn { get; set; }

        public Backcheck()
        {
            //TODO: Determine if Backcheck default ctor should be error constructor, or used for typical import
            iteration = 0;
            id = -1;
            comment = -1;
            evaluation = -1;
            status = "closed";
            backcheckText = "<default constructor used>";
            attachment = null;
            createdBy = "none";
            createdOn = DateTime.Now;
        }

        //TODO: Create additional ctors
    }
}
