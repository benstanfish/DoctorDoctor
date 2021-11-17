using System.Xml.Serialization;
using System.Diagnostics;
using System.Text;

namespace DoctorDoctor
{
    public partial class DoctorForm : Form
    {

        //C:\Users\benst\Desktop\_XML Tests\projnet.xml

        //public ProjNet pn = ProjNet.ReadFromFile(@"C:\Users\benst\Desktop\_XML Tests\projnet.xml");
        public ProjNet pn = new ProjNet();
        public List<ProjNet> pnList = new List<ProjNet>();
        public ColorSettings cs = ColorSettings.GetColorSettings();
        public string path = string.Empty;

        public DoctorForm()
        {
            InitializeComponent();
        }




        private void InjectTreeView()
        {
            treeView1.Nodes.Clear();
            List<string> Disciplines = pn.GetDisciplines();
            foreach (string str in Disciplines)
            {
                //Load treeview with Disciplines as root nodes
                treeView1.Nodes.Add(str, str);      //HACK: It's important to load these nodes with the Discipline name as the Key and the Text!
            }

            foreach (Comment cmt in pn.Comments)
            {
                //Load treeview with comments as children to discipline nodes
                TreeNode node = new TreeNode(cmt.Id.ToString());
                treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.Add(node);
                //if(cmt.Status.ToLower() != "open")
                //    node.ForeColor = cs.openComment;
                switch (cmt.Status.ToLower())
                {
                    case "closed":
                        node.ForeColor = cs.ClosedColor;
                        break;
                    default:
                        node.ForeColor = cs.OpenColor;
                        break;
                }

                foreach (Evaluation evaluation in cmt.Evaluations)
                {
                    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes.Add(evaluation.Id.ToString(), evaluation.Name);
                    //if(evaluation.Status.ToLower() == "concur")
                    //    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes[evaluation.Id.ToString()].BackColor = cs.concur;
                    Color temp = Color.Empty;
                    switch (evaluation.Status.ToLower())
                    {
                        case "concur":
                            temp = cs.ConcurColor;
                            break;
                        case "for information only":
                            temp = cs.ForInformationOnlyColor;
                            break;
                        case "non-concur":
                            temp = cs.NonConcurColor;
                            break;
                        default:
                            temp = cs.CheckAndResolveColor;
                            break;
                    }
                    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes[evaluation.Id.ToString()].ForeColor = temp;
                }
                foreach (Backcheck backcheck in cmt.Backchecks)
                {
                    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes.Add(backcheck.Id.ToString(), backcheck.Name);
                    //if (backcheck.Status.ToLower() == "concur")
                    //    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes[backcheck.Id.ToString()].BackColor = cs.concur;
                    Color temp = Color.Empty;
                    switch (backcheck.Status.ToLower())
                    {
                        case "concur":
                            temp = cs.ConcurColor;
                            break;
                        case "for information only":
                            temp = cs.ForInformationOnlyColor;
                            break;
                        case "non-concur":
                            temp = cs.NonConcurColor;
                            break;
                        default:
                            temp = cs.CheckAndResolveColor;
                            break;
                    }
                    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes[backcheck.Id.ToString()].ForeColor = temp;
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                propertyGrid1.SelectedObject = pn.DoctorChecks;

                int level = treeView1.SelectedNode.Level;
                string[] fullAddy = treeView1.SelectedNode.FullPath.Split(@"\");

                switch (level)
                {
                    case 1:
                        foreach(Comment c in pn.Comments)
                        {
                            if(c.Id.ToString() == fullAddy[1].ToString())
                            {
                                propertyGrid2.SelectedObject = c;
                                textBoxComments.Text = c.CommentText;
                            }
                        }
                        break;
                    case 2:
                        foreach (Comment c in pn.Comments)
                        {
                            if (c.Id.ToString() == fullAddy[1].ToString())
                            {
                                foreach(Evaluation eval in c.Evaluations)
                                {
                                    if(eval.Name == fullAddy[2].ToString())
                                    {
                                        propertyGrid2.SelectedObject = eval;
                                        textBoxComments.Text = eval.EvaluationText;
                                    }
                                }
                                foreach(Backcheck bc in c.Backchecks)
                                {
                                    if(bc.Name == fullAddy[2].ToString())
                                    {
                                        propertyGrid2.SelectedObject = bc;
                                        textBoxComments.Text = bc.BackcheckText;
                                    }
                                }
                            }
                        }

                        break;
                    default:
                        propertyGrid2.SelectedObject=null;
                        break;
                }
            }
            else
            {
                propertyGrid2.SelectedObject = null;
            }
        }

        public static void LoadProject()
        {   

            try
            {
                string path = Helper.GetFilePath();
                
            }
            catch (Exception)
            {
                
                
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //TODO: Create expand all at certain level
            treeView1.ExpandAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            e.Node.Expand();
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This function gets a project folder and sets the projectFolder string,
            // then it cycles through the XML files in that folder, conforming ones that
            // are validated via ProjNet.Validate(), finally injecting the List<ProjNet>
            // to the listBoxProjects.

            string testPath = Helper.GetFolderPath();
            List<string> validPaths = Helper.ValidProjNetFiles(testPath);
            List<ProjNet> loadPNs = new List<ProjNet>();
            foreach(string st in validPaths)
            {
                loadPNs.Add(ProjNet.ReadFromFile(st));
            }
            pnList = loadPNs;
            listBoxProjects.DataSource = pnList;
            listBoxProjects.Refresh();
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorSettingsForm csm = new ColorSettingsForm();
            csm.ColorSettingProperties = cs;
            csm.Show();
            cs = csm.ColorSettingProperties;
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm(); 
            aboutForm.Show();   
        }



        private void listBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            pn = pnList[listBoxProjects.SelectedIndex];
            propertyGrid1.SelectedObject = pn.DoctorChecks;
            InjectTreeView();
        }


        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            
            path = Helper.GetFilePath();
            if (path != null & ProjNet.Validate(path))
            {
                
                Helper.RoundTripConform(path);
                ProjNet newPN = ProjNet.ReadFromFile(path);

                pn = newPN;
                pnList.Clear();
                pnList.Add(newPN);
                propertyGrid1.SelectedObject = pn.DoctorChecks;
                listBoxProjects.DataSource = new List<ProjNet> { pn };

                InjectTreeView();
               
                
            }
            listBoxProjects.Refresh();
        }

        private void importFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstructionsForm instructionsForm = new InstructionsForm();
            instructionsForm.Show();
        }

        private void colorCodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorSettingsForm csm = new ColorSettingsForm();
            csm.ColorSettingProperties = cs;
            csm.Repaint();
            csm.Show();
            cs = csm.ColorSettingProperties;
            
        }
    }
}