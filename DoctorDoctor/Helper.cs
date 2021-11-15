using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DoctorDoctor
{
    public static class Helper
    {

        /// <summary>
        /// Returns the path of a selected folder
        /// </summary>
        /// <returns></returns>
        public static string GetFolderPath()
        {
            var folderPath = string.Empty;
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                string usersDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //fd.InitialDirectory = usersDesktop + "\\Project Serialize\\";
                

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    folderPath = fbd.SelectedPath;
                }
            }
            return folderPath;
        }

        public static List<string> ValidProjNetFiles(string folderPath)
        {
            string[] allFiles = Directory.GetFiles(folderPath);
            List<string> validFiles = new List<string>();
            foreach(string file in allFiles)
            {
                if (ProjNet.Validate(file))
                {
                    validFiles.Add(file);
                }
            }

            return validFiles;
        }


        /// <summary>
        /// Uses an OpenFileDialog to get a file path selected by the user.
        /// </summary>
        /// <returns>Returns the file path as a string.</returns>
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


        /// <summary>
        /// Reads a file line by line.
        /// </summary>
        /// <param name="filePath">Provide a file path as a string</param>
        /// <returns>Returns a string[] with all the lines of text</returns>
        public static string[] ConsumeFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }


        /// <summary>
        /// Processes through a string array, looking for keywords and numbers in the attributes to update.
        /// </summary>
        /// <param name="lines">raw string array from XML file</param>
        /// <param name="searchWord">e.g. "backcheck" or "evaluator"</param>
        /// <returns></returns>
        public static string[] XMLConformer(string[] lines, string searchWord)
        {
            string openTest = @"\<(" + searchWord + @")\>";
            string openTestWithNumbers = @"\<(" + searchWord + @"\d+)\>";
            string closeTestWithNumbers = @"\</(" + searchWord + @"\d+)\>";
            string numbers = @"\d+";
            string insideEvaluation = @"<evaluation>\d+</evaluation>";

            Regex rxOpen = new Regex(openTest);
            Regex rxOpenNum = new Regex(openTestWithNumbers);
            Regex rxCloseNum = new Regex(closeTestWithNumbers);
            Regex rxIsInsideEval = new Regex(insideEvaluation);

            int times = 8;
            if (searchWord == "evaluation")
            {
                times = 9;
            }
            string indenter = string.Concat(Enumerable.Repeat("\t", times));

            for (int i = 0; i < lines.Length; i++)
            {
                if (rxOpenNum.IsMatch(lines[i]) & !rxIsInsideEval.IsMatch(lines[i]))        // Case if there is a numbered member, e.g. backcheck1.
                {
                    string oldInnerText = Regex.Match(lines[i], openTestWithNumbers).Value.ToString();
                    oldInnerText = Regex.Replace(oldInnerText, @"\<", "");
                    oldInnerText = Regex.Replace(oldInnerText, @"\>", "");
                    lines[i] = indenter + @"<" + searchWord + " name=\"" + oldInnerText + "\">";
                }
                else if (rxOpen.IsMatch(lines[i]) & !rxIsInsideEval.IsMatch(lines[i]))      // Case if the member is not numbered, e.g. backcheck.
                {

                    lines[i] = indenter + @"<" + searchWord + " name=\"" + searchWord + "\">";
                }
                else if (rxCloseNum.IsMatch(lines[i]))                                      // De-numbers the closing tag.
                {
                    string currentValue = lines[i];
                    string newValue = Regex.Replace(currentValue, numbers, "").ToString();
                    lines[i] = indenter + newValue;
                }
            }
            return lines;
        }


        public static string[] ReplaceXMLLineBreaks(string[] lines)
        {
            //TODO: This function may not be that helpful - consider deletion.
            string findMe = "&lt;br /&gt;";
            Regex rx = new Regex(findMe);
            for (int i = 0; i < lines.Length; i++)
            {
                if (rx.IsMatch(lines[i]))
                {
                    lines[i] = Regex.Replace(lines[i], findMe, " ");
                }
            }
            return lines;
        }


        /// <summary>
        /// Function to write the contents of a string array back to the file where it came from.
        /// </summary>
        /// <param name="lines">string array of the text</param>
        /// <param name="filePath">Original filepath of the consumed file</param>
        public static void WriteToFile(string[] lines, string filePath)
        {
            using (FileStream fileStream = new FileStream(
                filePath, FileMode.Create, FileAccess.Write,
                FileShare.None))
            {
                StreamWriter writer = new StreamWriter(fileStream);
                writer.Write(string.Join("\n",lines));
                writer.Close();
            }
        }
    

        /// <summary>
        /// Roundtrip conforming XML file.
        /// </summary>
        public static void RoundTripConform()
        {
            //TODO: Delete debugs
            string filePath = GetFilePath();
            //Debug.WriteLine("File consumed");
            string[] lines = ConsumeFile(filePath);
            lines = XMLConformer(lines, "evaluation");
            //Debug.WriteLine("\"evaluation\" comformed");
            lines = XMLConformer(lines, "backcheck");
            //Debug.WriteLine("\"backcheck\" comformed");
            //lines = ReplaceXMLLineBreaks(lines);
            WriteToFile(lines, filePath);
            //Debug.WriteLine("File write completed.");
        }


        /// <summary>
        /// Test function for sanitizing File
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="searchWord"></param>
        public static void TestSanitizeFile(string filePath, string searchWord)
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


        /// <summary>
        /// A test method for testing regex.
        /// </summary>
        public static void TestRegex()
        {
            //TODO: Delete when done.
            string openTestNoNumbers = "<backcheck>";
            string openTestNumbers = "<backcheck1>";
            string closedTestNoNumbers = "</backcheck>";
            string closedTestNumbers = "</backcheck2>";
            string selfClosedNoNumbers = "<backcheck />";
            string selfClosedNumbers = "<backcheck3 />";

            string searchWord = "backcheck";
            string generalPattern = @"\</?(" + searchWord + @"\d?\s?/?)\>";

            string startPatternIfNumbers = @"\<(" + searchWord + @"\d?)\>";
            string startPatternOnlyNumbers = @"\<(" + searchWord + @"\d)\>";
            string endPatternIfNumbers = @"\</(" + searchWord + @"\d?)\>";
            string endPatternOnlyNumbers = @"\</(" + searchWord + @"\d)\>";
            string selfClosedPatternIfNumbers = @"\<(" + searchWord + @"\d?\s?/)\>";
            string selfClosedPatternOnlyNumbers = @"\<(" + searchWord + @"\d\s?/)\>";

            string numPattern = @"(\d+)";

            Regex r_startPatternIfNumbers = new Regex(startPatternIfNumbers);
            Regex r_startPatternOnlyNumbers = new Regex(startPatternOnlyNumbers);
            Regex r_endPatternIfNumbers = new Regex(endPatternIfNumbers);
            Regex r_endPatternOnlyNumbers = new Regex(endPatternOnlyNumbers);
            Regex r_selfClosedPatternIfNumbers = new Regex(selfClosedPatternIfNumbers);
            Regex r_selfClosedPatternOnlyNumbers = new Regex(selfClosedPatternOnlyNumbers);
            Regex num = new Regex(numPattern);

            Debug.WriteLine(r_startPatternIfNumbers.IsMatch(openTestNoNumbers));
            Debug.WriteLine(r_startPatternOnlyNumbers.IsMatch(openTestNumbers) + "\t" + num.Match(openTestNumbers).Value);
            Debug.WriteLine(r_endPatternIfNumbers.IsMatch(closedTestNoNumbers));
            Debug.WriteLine(r_endPatternOnlyNumbers.IsMatch(closedTestNumbers) + "\t" + num.Match(closedTestNumbers).Value);
            Debug.WriteLine(r_selfClosedPatternIfNumbers.IsMatch(selfClosedNoNumbers));
            Debug.WriteLine(r_selfClosedPatternOnlyNumbers.IsMatch(selfClosedNumbers) + "\t" + num.Match(selfClosedNumbers).Value);
        }


        /// <summary>
        /// A test method for replacing substrings with regex.
        /// </summary>
        public static void TestReplace()
        {
            //TODO: Delete when done.
            string searchWord = "backcheck";
            string[] tests = new string[7];
            Random rand = new Random();

            int trialNumber = rand.Next(1, 500);

            tests[0] = "<" + searchWord + ">";
            tests[1] = "<" + searchWord + trialNumber.ToString() + ">";
            tests[2] = "</" + searchWord + ">";
            tests[3] = "</" + searchWord + trialNumber.ToString() + ">";
            tests[4] = "<control>";
            tests[5] = "</control>";
            tests[6] = "<control />";

            for (int i = 0; i < tests.Length; i++)
            {
                Debug.WriteLine(i + ": " + tests[i]);
            }

            string openTest = @"\<(" + searchWord + @")\>";
            string openTestWithNumbers = @"\<(" + searchWord + @"\d+)\>";
            string closeTest = @"\</(" + searchWord + @"\d+?)\>";
            string closeTestWithNumbers = @"\</(" + searchWord + @"\d+)\>";
            string numbers = @"\d+";
            Regex rxOpen = new Regex(openTest);
            Regex rxClose = new Regex(closeTest);
            Regex rxOpenNum = new Regex(openTestWithNumbers);
            Regex rxCloseNum = new Regex(closeTestWithNumbers);
            Regex rxNumber = new Regex(numbers);

            //MessageBox.Show(trialNumber.ToString());

            for(int i = 0; i < tests.Length; i++)   
            {
                //Debug.WriteLine("Run: " + i + "\t" + tests[i]);
                //if (rxOpenNum.IsMatch(tests[i]))
                //    Debug.WriteLine($"Success at {tests[i]}");
                //else
                //    Debug.WriteLine($"Fail at {tests[i]}");

                if (rxOpenNum.IsMatch(tests[i]))
                {
                    string numVal = Regex.Match(tests[i], numbers).Value.ToString();
                    string commentType = @"<commentType>" + searchWord + numVal + @"</commentType>";
                    string iteration = @"<iteration>" + numVal + @"</iteration>";
                    string newValue = Regex.Replace(tests[i], numbers, "").ToString();
                    Debug.WriteLine(newValue + "\n\t" + iteration + "\n\t" + commentType);
                }
                else if (rxOpen.IsMatch(tests[i]))
                {
                    string commentType = @"<commentType>" + searchWord + @"</commentType>";
                    string iteration = @"<iteration>1</iteration>";
                    Debug.WriteLine(tests[i] + "\n\t" + iteration + "\n\t" + commentType);
                }
                else if (rxCloseNum.IsMatch(tests[i]))
                {
                    string newValue = Regex.Replace(tests[i], numbers, "").ToString();
                    Debug.WriteLine(newValue);
                }

            }

        }


        /// <summary>
        /// TEST Processes through a string array, looking for keywords and numbers in the attributes to update.
        /// </summary>
        /// <param name="lines">raw string array from XML file</param>
        /// <param name="searchWord">e.g. "backcheck" or "evaluator"</param>
        /// <returns></returns>
        public static string[] Test_XMLConformer(string[] lines, string searchWord)
        {
            //TODO: Delete this code when finished.
            string openTest = @"\<(" + searchWord + @")\>";
            string openTestWithNumbers = @"\<(" + searchWord + @"\d+)\>";
            string closeTest = @"\</(" + searchWord + @"\d+?)\>";
            string closeTestWithNumbers = @"\</(" + searchWord + @"\d+)\>";
            string numbers = @"\d+";
            string insideEvaluation = @"<evaluation>\d+</evaluation>";
            //string findIteration = @"<" + searchWord + @">\s+?\n?\t+?<iteration>\s+?\n?\t+?<id>";
            //string findCommentType = @"<" + searchWord + @">\s+?\n?\t+?<iteration>\s+?\n?\t+?<commentType>\s+?\n?\t+?<id>";

            Regex rxOpen = new Regex(openTest);
            Regex rxOpenNum = new Regex(openTestWithNumbers);
            Regex rxCloseNum = new Regex(closeTestWithNumbers);
            Regex rxIsInsideEval = new Regex(insideEvaluation);
            //Regex rxFindIteration = new Regex(findIteration);
            //Regex rxFindCommentType = new Regex(findCommentType);

            int times = 8;
            if (searchWord == "evaluation")
            {
                times = 9;
            }
            string indenter = "\n" + string.Concat(Enumerable.Repeat("\t", times));

            for (int i = 0; i < lines.Length; i++)
            {
                //if (rxFindIteration.IsMatch(lines[i]) | rxFindCommentType.IsMatch(lines[i]))
                //{
                //    Debug.WriteLine("Alright Here");
                //}
                if (rxOpenNum.IsMatch(lines[i]) & !rxIsInsideEval.IsMatch(lines[i]))
                {
                    string numVal = Regex.Match(lines[i], numbers).Value.ToString();
                    string commentType = @"<commentType>" + searchWord + numVal + @"</commentType>";
                    string iteration = @"<iteration>" + numVal + @"</iteration>";
                    string newValue = Regex.Replace(lines[i], numbers, "").ToString();
                    lines[i] = newValue + indenter + iteration + indenter + commentType;
                }
                //else if (rxOpen.IsMatch(lines[i]) & !rxIsInsideEval.IsMatch(lines[i]))
                //{
                //    string currentValue = lines[i];
                //    string commentType = @"<commentType>" + searchWord + @"</commentType>";
                //    string iteration = @"<iteration>1</iteration>";
                //    lines[i] = currentValue + indenter + iteration + indenter + commentType;
                //}
                else if (rxCloseNum.IsMatch(lines[i]))
                {
                    string currentValue = lines[i];
                    string newValue = Regex.Replace(currentValue, numbers, "").ToString();
                    lines[i] = newValue;
                }
            }

            return lines;
        }


    }



    
}
