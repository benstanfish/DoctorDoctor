using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorDoctor
{
    public partial class ColorSettingsMenu : Form
    {
        public ColorSettings cs = new ColorSettings();
        
        public ColorSettingsMenu()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog () == DialogResult.OK)
            {
                cs.OpenColor =colorDialog1.Color;
            }
        }

        private void buttonClosed_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                cs.ClosedColor = colorDialog1.Color;
            }
        }
    }
}
