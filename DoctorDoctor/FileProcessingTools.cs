﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDoctor
{
    public static class FileProcessingTools
    {
       

        public static string GetFilePath()
        {
            var filePath = string.Empty;
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                string usersDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //fd.InitialDirectory = usersDesktop + "\\Project Serialize\\";
                fd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                fd.FilterIndex = 2;
                fd.RestoreDirectory = true;

                if (fd.ShowDialog() == DialogResult.OK)
                { 
                    filePath = fd.FileName; 
                }
            }
            return filePath;
        }

        public static void  ConsumeFile(string filePath)
        {
            string fileText = File.ReadAllText(filePath);
        }

    }



    
}
