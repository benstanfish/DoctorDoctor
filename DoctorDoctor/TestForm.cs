﻿using System;
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

            string testPath = Helper.GetFilePath();
            bool validate = ProjNet.Validate(testPath);
            Debug.WriteLine(validate);

        }
    }
}
