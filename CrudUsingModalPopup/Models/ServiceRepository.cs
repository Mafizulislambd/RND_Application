using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
namespace CrudUsingModalPopup.Models
{
    public class ServiceRepository : IServiceRepository<Product>
    {
        SqlConnection? _conection = null;
        SqlCommand? _command = null;
        public string ConnString { get; set; }
        public static IConfiguration? Configuration { get; set; }
        public  void SdbConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            ConnString= Configuration.GetConnectionString("TestCon");
        }
        public int SaveData(Product data)
        {
            string strConString = @"Data Source=Mafizul-Islam\MSSQLSERVER01;Initial Catalog=TestPDB;User ID=mytest;Password=mytest;Encrypt=False";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into Product (Product_Name, Price, Quantity) values(@Product_Name, @Price, @Quantity)";
                SqlCommand cmd = new SqlCommand();
                cmd= con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Product_Name", data.Product_Name);
                cmd.Parameters.AddWithValue("@Price", data.Price);
                cmd.Parameters.AddWithValue("@Quantity", data.Quantity);
                return cmd.ExecuteNonQuery();
            }
        }
        public List<Product> GetProducts()
        {
            string strConString = @"Data Source=Mafizul-Islam\MSSQLSERVER01;Initial Catalog=TestPDB;User ID=mytest;Password=mytest;Encrypt=False";

            // DataTable dt = new DataTable();
            List<Product> products = new List<Product>();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                var vQuery = "Select * from Product";              
                
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = vQuery;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Product pro = new Product();
                    pro.Product_ID =Convert.ToInt32( dr["Product_ID"]);
                    pro.Product_Name = dr["Product_Name"].ToString();
                    pro.Price = Convert.ToDouble(dr["Price"]);
                    pro.Quantity = Convert.ToInt32(dr["Quantity"]);
                    products.Add(pro);

                }               
                //SqlCommand cmd = new SqlCommand("Select * from Product", con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //pro.Product_ID = Convert.ToInt32(da["Product_ID"]);
                //pro.Product_Name = da["Product_ID"].ToString();
                //da.Fill(dt);
                //products = da.Fill(dt);
                con.Close();
            }
            return products;
        }

        public int UpdateData(Product data)
        {
            string strConString = @"Data Source=Mafizul-Islam\MSSQLSERVER01;Initial Catalog=TestPDB;User ID=mytest;Password=mytest;Encrypt=False";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Update Product SET Product_Name=@Product_Name, Price=@Price, Quantity=@Quantity where Product_ID=@Product_ID";
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Product_ID", data.Product_ID);
                cmd.Parameters.AddWithValue("@Product_Name", data.Product_Name);
                cmd.Parameters.AddWithValue("@Price", data.Price);
                cmd.Parameters.AddWithValue("@Quantity", data.Quantity);
                return cmd.ExecuteNonQuery();
            }
            
        }

        public int DeleteData(int id)
        {
            string strConString = @"Data Source=Mafizul-Islam\MSSQLSERVER01;Initial Catalog=TestPDB;User ID=mytest;Password=mytest;Encrypt=False";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete from Product where Product_ID=@Product_ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Product_ID", id);
                return cmd.ExecuteNonQuery();
            }
        }

        public Product GetProductById(int id)
        {
            string strConString = @"Data Source=Mafizul-Islam\MSSQLSERVER01;Initial Catalog=TestPDB;User ID=mytest;Password=mytest;Encrypt=False";

            // DataTable dt = new DataTable();
            // List<Product> products = new List<Product>();
            Product products = new Product();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                var vQuery = "Select * from Product where Product_ID=@Product_ID ";

                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = vQuery;
                cmd.Parameters.AddWithValue("@Product_ID", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   
                    products.Product_ID = Convert.ToInt32(dr["Product_ID"]);
                    products.Product_Name = dr["Product_Name"].ToString();
                    products.Price = Convert.ToDouble(dr["Price"]);
                    products.Quantity = Convert.ToInt32(dr["Quantity"]);
                    //products.Add(pro);

                }
                //SqlCommand cmd = new SqlCommand("Select * from Product", con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //pro.Product_ID = Convert.ToInt32(da["Product_ID"]);
                //pro.Product_Name = da["Product_ID"].ToString();
                //da.Fill(dt);
                //products = da.Fill(dt);
                con.Close();
            }
            return products;
        }
    }
}
