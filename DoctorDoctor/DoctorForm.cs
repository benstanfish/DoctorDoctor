using System.Xml.Serialization;
using System.Diagnostics;

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

            //string myPath = FileProcessingTools.GetFilePath();
            //string[] lines = FileProcessingTools.ConsumeFile(myPath);
            //MessageBox.Show(myPath);
            //FileProcessingTools.SanitizeFile(myPath,"evaluation");

            //FileProcessingTools.TestRegex();
            //FileProcessingTools.TestReplace();

            //Helper.RoundTripConform();




            //Evaluation evaluation = Evaluation.Load(@"C:\Users\benst\Desktop\_XML Tests\evaluation.xml");
            //Evaluation evaluation = new Evaluation();

            //Evaluation evaluation = null;
            //evaluation = Helper.XmlDeserialize(typeof(Evaluation), @"C:\Users\benst\Desktop\_XML Tests\evaluation.xml");
            //Debug.WriteLine(evaluation.ToString());

            //if (evaluation != null)
            //    Debug.WriteLine(evaluation.ToString());
            //else
            //    Debug.WriteLine("There was an error!");
            //this.Close();

            //Wingding ben = new Wingding("Ben","Blue",3);
            //Wingding green = new Wingding("Green", "Red", 1);
            //Wingding balloon = new Wingding("Balloon", "Honeybear", 4);

            //Helper.XMLSerialize(typeof(Wingding), ben, @"C:\Users\benst\Desktop\_XML Tests\wingding.xml");

            //var xml = new XmlSerializer(typeof(Wingding));
            //StreamReader rdr = new StreamReader(@"C:\Users\benst\Desktop\_XML Tests\wingding.xml");
            //Wingding newBen = (Wingding)xml.Deserialize(rdr);

            //ben.Write(@"C:\Users\benst\Desktop\_XML Tests\wingding.xml");

            //Wingding newBen = Wingding.Read(@"C:\Users\benst\Desktop\_XML Tests\wingding.xml");
            //Debug.WriteLine(newBen.ToString()); 

            //Evaluation eval = new Evaluation("evaluation1",1,1,"status","impactscope","impactcost","impacttime","evaltext","attachment","ben fisher",DateTime.Now);
            //eval.Write(@"C:\Users\benst\Desktop\_XML Tests\eval.xml");

            //Evaluation newEval = Evaluation.Read(@"C:\Users\benst\Desktop\_XML Tests\eval3.xml");
            //Debug.WriteLine(newEval.ToString()); 




        }



    }
}