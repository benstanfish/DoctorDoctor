using System.Xml.Serialization;
using System.Diagnostics;
using System.Text;

namespace DoctorDoctor
{
    public partial class DoctorForm : Form
    {
        
        public ProjNet pn = ProjNet.ReadFromFile(@"C:\Users\benst\Desktop\_XML Tests\projnet.xml");




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
            propertyGrid1.HorizontalScroll.Enabled = true;


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
                if(cmt.Status.ToLower() != "open")
                    node.ForeColor = Color.Gray;

                foreach (Evaluation evaluation in cmt.Evaluations)
                {
                    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes.Add(evaluation.Id.ToString(), evaluation.Name);
                    if(evaluation.Status.ToLower() == "concur")
                        treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes[evaluation.Id.ToString()].BackColor = Color.LightCyan;
                }
                foreach (Backcheck backcheck in cmt.Backchecks)
                {
                    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes.Add(backcheck.Id.ToString(), backcheck.Name);
                    if (backcheck.Status.ToLower() == "concur")
                        treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes[backcheck.Id.ToString()].BackColor = Color.LightCyan;
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



        private void button3_Click(object sender, EventArgs e)
        {
            //TODO: Create expand all at certain level
            treeView1.ExpandAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

    }
}