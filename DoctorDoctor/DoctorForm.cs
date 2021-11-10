namespace DoctorDoctor
{
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO: This button is a test method.
            string myPath = FileProcessingTools.GetFilePath();
            MessageBox.Show(myPath);
        }
    }
}