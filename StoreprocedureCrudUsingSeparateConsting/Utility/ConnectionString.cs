namespace StoreprocedureCrudUsingSeparateConsting.Utility
{
    public class ConnectionString
    {
        private static string cName = "Data Source=Mafizul-Islam\\MSSQLSERVER01;Initial Catalog=StudentManagement;Integrated Security=True;Encrypt=False";
        public static string CName
        {
            get => cName;
        }
    }
}
