using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDoctor
{
    internal class DrChecks
    {
        public int ProjectID { get; set; }
        public string? ProjectControlNbr { get; set; }
        public string? ProjectName { get; set; }
        public int ReviewID { get; set; }       
        public string? ReviewName { get; set; }  // This generally corresponds to the project "phase"

        public DrChecks()
        {
            //TODO: Determine if this is the best ctor for import
            ProjectID = -1;
            ProjectControlNbr = null;
            ProjectName = null;
            ReviewID = -1;
            ReviewName = null;
        }
    }
}
