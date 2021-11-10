using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDoctor
{
    internal class ProjNet
    {
        public DrChecks drChecks { get; set; }
        public List<Comment> comments { get; set; }

        public ProjNet()
        {
            //TODO: determine appropriate way to initialize ProjNet from XML import
            drChecks = new DrChecks();
            comments = new List<Comment>();
        }

    }
}
