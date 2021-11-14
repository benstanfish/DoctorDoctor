namespace DoctorDoctor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            
            Application.Run(new DoctorForm());
            



        }
    }

    //Version 0 TODO List:
    //----------------------------------
    //TODO: File Dialog Function
    //TODO: Consume and verify XML file
    //TODO: Create Evaluation Class
    //TODO: Create Backcheck Class
    //TODO: Create ProjNet Class
    //TODO: Create DrChecks Class
    //TODO: Create Comment Class
    //TODO: Process XML to move Evaluation and Backcheck iterators inside objects before deserialization
    //TODO: Serialize and deserialize XML
    //----------------------------------
}