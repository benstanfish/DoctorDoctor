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
    public partial class InstructionsForm : Form
    {
        public InstructionsForm()
        {
            InitializeComponent();
            label3.Text = "After logging into your ProjNet account and selecting the appropriate\n" +
                "project, nagivate to and select the \"RPT\" that you wish to download.";
            label5.Text = "Next select the hyperlink for the XML under \"All Comments\" in for\n" +
                "either the \"Submitter\" or \"Evaluator\" Reports --- they produce the same \n" +
                "XML file, so either is acceptable.";
            label7.Text = "Next click the hyperlink for \"Save This File\" to your computer. You will see a Save As dialog window open.";
            label8.Text = "It's recommended to save all XMLs for a project in the same folder. That way DoctorDoctor can see them\n" +
                "all simultaneously. When you save multiple different XML reports, it helps if you add descriptor to the title\n" +
                "of the file. This isn't required as the program doesn't use the file name, it only digests and presents\n" +
                "the contents of the XML inside the file.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
