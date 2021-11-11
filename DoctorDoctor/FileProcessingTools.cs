using System;
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

            string startPattern = @"\<(" + searchWord + @"\d?)\>";
            string endPattern = @"\</(" + searchWord + @"\d?)\>";
            string selfClosedPattern = @"\<(" + searchWord + @"\d?\s?/)\>";

            string numPattern = @"(\d+)";

            Regex rx = new Regex(startPattern, RegexOptions.IgnoreCase);
            Regex rxNum = new Regex(numPattern, RegexOptions.IgnoreCase);
            foreach (string line in lines)
            {
                Match match = rx.Match(line);
                Match numMatch = rxNum.Match(line);
                if (match.Success !& numMatch.Success)
                        Debug.WriteLine(match.Value + ", " + numMatch.Value);
                else if(match.Success && numMatch.Success)
                        Debug.WriteLine(match.Value);
                //if (match.Success && numMatch.Success)
                //    Debug.WriteLine(line + "\t" + Regex.Replace(line, numPattern, ""));
            }
        }

    }



    
}
