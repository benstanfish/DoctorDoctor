using System.Xml.Serialization;
using System.Diagnostics;
using System.Text;

namespace DoctorDoctor
{
    public partial class DoctorForm : Form
    {

        public ProjNet pn = ProjNet.ReadFromFile(@"C:\Users\benst\Desktop\_XML Tests\projnet.xml");
        public ColorSettings cs = new ColorSettings();
        


        public DoctorForm()
        {
            InitializeComponent();

            //string EvaluationPath = @"C:\Users\benst\Desktop\_XML Tests\evaluation.xml";
            //string BackcheckPath = @"C:\Users\benst\Desktop\_XML Tests\backcheck.xml";
            //string CommentPath = @"C:\Users\benst\Desktop\_XML Tests\comment.xml";
            //string ProjNetPath = @"C:\Users\benst\Desktop\_XML Tests\projnet.xml";

            //Evaluation eval = Evaluation.ReadFromFile(EvaluationPath);
            //Backcheck bc = Backcheck.ReadFromFile(BackcheckPath);
            //Comment cmt = Comment.ReadFromFile(CommentPath);
            //ProjNet projNet = ProjNet.ReadFromFile(ProjNetPath);

            propertyGrid1.SelectedObject = pn.DoctorChecks;

            treeView1.Nodes.Clear();
            List<string> Disciplines = pn.GetDisciplines();
            foreach(string str in Disciplines)
            {
                //Load treeview with Disciplines as root nodes
                treeView1.Nodes.Add(str, str);      //HACK: It's important to load these nodes with the Discipline name as the Key and the Text!
            }

            foreach(Comment cmt in pn.Comments)
            {
                //Load treeview with comments as children to discipline nodes
                TreeNode node = new TreeNode(cmt.Id.ToString());
                treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.Add(node);
                //if(cmt.Status.ToLower() != "open")
                //    node.ForeColor = cs.openComment;
                switch (cmt.Status.ToLower())
                {
                    case "closed":
                        node.ForeColor = cs.closedComment;
                        break;
                    default:
                        node.ForeColor = cs.openComment;
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
                            temp = cs.concur;
                            break;
                        case "for information only":
                            temp = cs.forInformationOnly;
                            break;
                        case "non-concur":
                            temp = cs.nonConcur;
                            break;
                        default:
                            temp = cs.checkAndResolve;
                            break;
                    }
                    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes[evaluation.Id.ToString()].BackColor = temp;
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
                            temp = cs.concur;
                            break;
                        case "for information only":
                            temp = cs.forInformationOnly;
                            break;
                        case "non-concur":
                            temp = cs.nonConcur;
                            break;
                        default:
                            temp = cs.checkAndResolve;
                            break;
                    }
                    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes[backcheck.Id.ToString()].BackColor = temp;
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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helper.RoundTripConform();
        }

        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorSettings newCs = new ColorSettings();
            ColorSettingsMenu csm = new ColorSettingsMenu();
            csm.cs = newCs;
            csm.Show();
            cs = newCs;
        }
    }
}