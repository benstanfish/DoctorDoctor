using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDoctor
{
    public class ColorSettings
    {

        public Color openComment { get; set; } = Color.Red;
        public Color closedComment { get; set; } = Color.Gray;
        public Color concur { get; set; } = Color.LightCyan;
        public Color forInformationOnly { get; set; } = Color.LightGreen;
        public Color nonConcur { get; set; } = Color.Yellow;
        public Color checkAndResolve { get; set;} = Color.LightPink;

        public ColorSettings()
        {
        }

    }
}
