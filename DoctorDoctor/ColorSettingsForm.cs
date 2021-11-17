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
    public partial class ColorSettingsForm : Form
    {
        public ColorSettings ColorSettingProperties { get; set; }

        public ColorSettingsForm()
        {
            InitializeComponent();

        }

        public void Repaint()
        {
            buttonOpen.ForeColor = ColorSettingProperties.OpenColor;
            buttonClosed.ForeColor = ColorSettingProperties.ClosedColor;
            buttonConcur.ForeColor = ColorSettingProperties.ConcurColor;
            buttonInfo.ForeColor = ColorSettingProperties.ForInformationOnlyColor;
            buttonNonconcur.ForeColor = ColorSettingProperties.NonConcurColor;
            buttonCheck.ForeColor = ColorSettingProperties.CheckAndResolveColor;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorSettingProperties.OpenColor = colorDialog1.Color;
                this.Repaint();
            }
        }

        private void buttonClosed_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                ColorSettingProperties.ClosedColor = colorDialog2.Color;
                this.Repaint();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void buttonConcur_Click(object sender, EventArgs e)
        {
            if (colorDialog3.ShowDialog() == DialogResult.OK)
            {
                ColorSettingProperties.ConcurColor = colorDialog3.Color;
                this.Repaint();
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (colorDialog4.ShowDialog() == DialogResult.OK)
            {
                ColorSettingProperties.ForInformationOnlyColor = colorDialog4.Color;
                this.Repaint();
            }
        }

        private void buttonNonconcur_Click(object sender, EventArgs e)
        {
            if (colorDialog5.ShowDialog() == DialogResult.OK)
            {
                ColorSettingProperties.NonConcurColor = colorDialog5.Color;
                this.Repaint();
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (colorDialog6.ShowDialog() == DialogResult.OK)
            {
                ColorSettingProperties.CheckAndResolveColor = colorDialog6.Color;
                this.Repaint();
            }
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            ColorSettingProperties = new ColorSettings();
            this.Repaint();
        }
    }
}
