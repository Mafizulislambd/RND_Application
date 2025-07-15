namespace SelfManagementTest
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private int coutCharacter()
        {
            int count = 0;
            using (StreamReader reader= new StreamReader("C:\\Users\\mafiz\\OneDrive\\Desktop\\Other\\Data.txt"))
            {
                string content=reader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(5000); // Simulate a delay for testing purposes

            }              
            return count;
        }
        private async void btnProcessfile_click(object sender, EventArgs e)
        { Task<int> task=new Task<int>(coutCharacter);
            task.Start();
            lblCount.Text = "Processing file...Please Wait";
            int count =await task;
            lblCount.Text = "Total Characters: " + count.ToString();
        }
    }
}
