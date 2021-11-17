using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorDoctor
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {

            InitializeComponent();
            label1.Text = "Version " + Assembly.GetEntryAssembly().GetName().Version;
            textBoxAbout.Text = "Created by Ben Fisher, November 2021\r\n\r\nThis app was created as a read-only viewer that will rapidly digest Dr. Checks (ProjNet) XML reports and present their data in a more condensed, color-coded, heirarchical format.";
            label2.Text = "Upcoming Development";
            textBoxFuture.Text = "- Color Selection Menus \r\n- Filter tree node list \r\n- Print to report \r\n- Data Grid View";
            label3.Text = "Known Issues";
            textBoxIssues.Text = "- Working on persistence of colors and project folders.\r\n- Persistence of recent project file on load.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}