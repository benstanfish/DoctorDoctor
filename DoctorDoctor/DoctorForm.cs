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
            string myPath = ResourceGetter.GetFilePath();
            MessageBox.Show(myPath);
        }
    }
}