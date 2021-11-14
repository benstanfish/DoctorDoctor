using System.Xml.Serialization;
using System.Diagnostics;

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

            foreach (Comment comment in pn.Comments)
            {
                treeView1.Nodes.Add(new TreeNode(comment.ToString()));
                if (comment.Status.ToLower() == "open")
                {
                    treeView1.Nodes[pn.Comments.IndexOf(comment)].ForeColor = Color.Red;  
                }

                foreach(Evaluation evaluation in comment.Evaluations)
                {
                    treeView1.Nodes[pn.Comments.IndexOf(comment)].Nodes.Add(new TreeNode(evaluation.Name));
                }
                foreach (Backcheck backcheck in comment.Backchecks)
                {
                    treeView1.Nodes[pn.Comments.IndexOf(comment)].Nodes.Add(new TreeNode(backcheck.Name));
                }
            }

            int l = 0;
            treeView2.Nodes.Clear();
            for(int i = 0; i < 2; i++)
            {
                treeView2.Nodes.Add(l.ToString());
                l++;
                for(int j = 0; j < 2; j++)
                {
                    treeView2.Nodes[i].Nodes.Add(l.ToString());
                    l++;
                    for(int k = 0; k < 2; k++)
                    {
                        treeView2.Nodes[i].Nodes[j].Nodes.Add(l.ToString());
                        l++;
                    }
                }
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: This button is a test method.
            this.Close();  
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            propertyGrid2.SelectedObject = pn.Comments[treeView1.SelectedNode.Index];
           
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int nodeIndex = treeView2.SelectedNode.Index;
            string parentIndex = "null";
            if (treeView2.SelectedNode.Parent != null)
            {
                parentIndex = treeView2.SelectedNode.Parent.Index.ToString();
            }
            string report = $"Node at index of: {nodeIndex}\n" +
                            $"Node levels is: {treeView2.SelectedNode.Level.ToString()}\n" +
                            $"Parent node at index of: {parentIndex}";
            Debug.WriteLine(report);
        }

        



    }
}