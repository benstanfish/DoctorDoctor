﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public static string[] ConsumeFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }

        public static void SanitizeFile(string filePath, string searchWord)
        {
            string[] lines = File.ReadAllLines(filePath);
            string pattern = @"\</?(" + searchWord + @"\d?\s?/?)\>";
            Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
            foreach (string line in lines)
            {
                Match match = rx.Match(line);
                if (rx.IsMatch(line))
                    Debug.WriteLine(match.Value);
            }
        }

    }



    
}
