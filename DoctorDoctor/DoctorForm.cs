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

                foreach (Evaluation evaluation in cmt.Evaluations)
                {
                    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes.Add(evaluation.Id.ToString(), evaluation.Name);
                }
                foreach (Backcheck backcheck in cmt.Backchecks)
                {
                    treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes[treeView1.Nodes[Disciplines.IndexOf(cmt.Discipline.ToString())].Nodes.IndexOf(node)].Nodes.Add(backcheck.Id.ToString(), backcheck.Name);
                }
            }

            //Debug.WriteLine(treeView1.Nodes.IndexOfKey("Electrical"));



            //foreach (Comment comment in pn.Comments)
            //{
            //    treeView1.Nodes.Add(new TreeNode(comment.ToString()));
            //    if (comment.Status.ToLower() == "open")
            //    {
            //        treeView1.Nodes[pn.Comments.IndexOf(comment)].ForeColor = Color.Red;
            //        treeView1.Nodes[pn.Comments.IndexOf(comment)].Expand();
            //    }

            //    foreach(Evaluation evaluation in comment.Evaluations)
            //    {
            //        treeView1.Nodes[pn.Comments.IndexOf(comment)].Nodes.Add(new TreeNode(evaluation.Name));
            //    }
            //    foreach (Backcheck backcheck in comment.Backchecks)
            //    {
            //        treeView1.Nodes[pn.Comments.IndexOf(comment)].Nodes.Add(new TreeNode(backcheck.Name));
            //    }
            //}

            //int l = 0;
            //treeView2.Nodes.Clear();
            //for(int i = 0; i < 2; i++)
            //{
            //    treeView2.Nodes.Add(l.ToString());
            //    l++;
            //    for(int j = 0; j < 2; j++)
            //    {
            //        treeView2.Nodes[i].Nodes.Add(l.ToString());
            //        l++;
            //        for(int k = 0; k < 2; k++)
            //        {
            //            treeView2.Nodes[i].Nodes[j].Nodes.Add(l.ToString());
            //            l++;
            //        }
            //    }
            //}

            //treeView2.ExpandAll();


        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            //TODO: This button is a test method.
            this.Close();  
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //propertyGrid2.SelectedObject = pn.Comments[treeView1.SelectedNode.Index];
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
                                    }
                                }
                                foreach(Backcheck bc in c.Backchecks)
                                {
                                    if(bc.Name == fullAddy[2].ToString())
                                    {
                                        propertyGrid2.SelectedObject = bc;
                                    }
                                }
                            }
                        }

                        break;
                    default:
                        break;
                }
            }
            else
            {
                propertyGrid2.SelectedObject = null;
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //int nodeIndex = treeView2.SelectedNode.Index;
            //string parentIndex = "null";
            //if (treeView2.SelectedNode.Parent != null)
            //{
            //    parentIndex = treeView2.SelectedNode.Parent.Index.ToString();
            //}
            //string report = $"Node at index of: {nodeIndex}\n" +
            //                $"Node levels is: {treeView2.SelectedNode.Level.ToString()}\n" +
            //                $"Parent node at index of: {parentIndex}";
            //Debug.WriteLine(report);
            //Debug.WriteLine(GetFamilyTree(treeView2.SelectedNode));
            Debug.WriteLine(treeView2.SelectedNode.FullPath);
        }

        public static string GetFamilyTree(TreeNode n)
        {
            int index = n.Index;
            int level = n.Level;
            string s = string.Empty;
            return s;

            //switch (level)
            //{
            //    case 0:
            //        s = $"Node index {index} at level {level}.\n";
            //        break;
            //    case 1:
            //        s = $"Node index {index} at level {level}.\n" +
            //            $"Parent index {n.Parent.Index} at level {n.Parent.Level}\n";
            //        break;
            //    default:
            //        s = $"Node index {index} at level {level}.\n" +
            //            $"Parent index {n.Parent.Index} at level {n.Parent.Level}\n" +
            //            $"Grandparent index {n.Parent.Parent.Index} at level {n.Parent.Parent.Level}\n";
            //        break;
            //}

            //string r = string.Empty;
            //string[] heritage = new string[n.Level];
            //for(int j = n.Level; j > 0; j--)
            //{
            //    r += ".Parent";
            //    string getIndex = "n" + r + ".Index";
            //    heritage[j] = $"{getIndex}";
            //}


            //return r = string.Join(",", heritage);


            //return s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string disc = string.Join("\n", pn.GetDisciplines());
            MessageBox.Show(disc);
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