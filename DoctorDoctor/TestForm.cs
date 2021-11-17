using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorDoctor
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string testPath = Helper.GetFolderPath();
            //Helper.RoundTripConform(testPath);
            //bool validate = ProjNet.Validate(testPath);
            //Debug.WriteLine("Validation: " + validate.ToString());
            List<string> validPaths = Helper.ValidProjNetFiles(testPath);
            foreach (string validPath in validPaths)
            {
                MessageBox.Show(validPath);
            }
        }
    }
}
