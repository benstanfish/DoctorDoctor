using System.Xml.Serialization;
using System.Diagnostics;

namespace DoctorDoctor
{
    public partial class DoctorForm : Form
    {

        public DoctorForm()
        {
            InitializeComponent();

            string EvaluationPath = @"C:\Users\benst\Desktop\_XML Tests\evaluation.xml";
            string BackcheckPath = @"C:\Users\benst\Desktop\_XML Tests\backcheck.xml";
            string CommentPath = @"C:\Users\benst\Desktop\_XML Tests\comment.xml";
            string ProjNetPath = @"C:\Users\benst\Desktop\_XML Tests\projnet.xml";

            Evaluation eval = Evaluation.ReadFromFile(EvaluationPath);
            Backcheck bc = Backcheck.ReadFromFile(BackcheckPath);
            Comment cmt = Comment.ReadFromFile(CommentPath);
            ProjNet projNet = ProjNet.ReadFromFile(ProjNetPath);

            //propertyGrid1.SelectedObject = eval;

            //foreach(Comment comment in projNet.Comments)
            //{
            //    //listBox1.Items.Add(comment.ToString());

            //}

            //foreach(Comment comment in projNet.Comments)
            //{

            //}

            treeView1.Nodes.Clear();

            foreach (Comment comment in projNet.Comments)
            {
                treeView1.Nodes.Add(new TreeNode(comment.ToString()));
                if (comment.Status.ToLower() == "open")
                {
                    treeView1.Nodes[projNet.Comments.IndexOf(comment)].ForeColor = Color.Red;  
                }

                foreach(Evaluation evaluation in comment.Evaluations)
                {
                    treeView1.Nodes[projNet.Comments.IndexOf(comment)].Nodes.Add(new TreeNode(evaluation.Name));
                }
                foreach (Backcheck backcheck in comment.Backchecks)
                {
                    treeView1.Nodes[projNet.Comments.IndexOf(comment)].Nodes.Add(new TreeNode(backcheck.Name));
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
            MessageBox.Show(treeView1.SelectedNode.ToString());
        }
    }
}