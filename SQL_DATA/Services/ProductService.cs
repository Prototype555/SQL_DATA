using SQL_DATA.Models;
using System.Data.SqlClient;

namespace SQL_DATA.Services
{
    public class ProductService
    {
        private static string db_source = "appserversh.database.windows.net";
        private static string db_user = "SuhasGH";
        private static string db_password = "Sgh@8762731559";
        private static string db_database = "Appdb";

        private SqlConnection GetConnection()
        {
            var _builder= new SqlConnectionStringBuilder();
            _builder.DataSource= db_source;
            _builder.UserID= db_user;
            _builder.Password= db_password;
            _builder.InitialCatalog= db_database;
            return new SqlConnection(_builder.ConnectionString);
        }
        public List<Product> GetProducts()
        {
            SqlConnection connection = GetConnection();

            List<Product> _product_lst =new List<Product>();
            string statement = "SELECT ProductID,ProductName,Quantity from Products";
            connection.Open();
            SqlCommand cmd = new SqlCommand(statement, connection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    _product_lst.Add(product);
                }
            }
            connection.Close();
            return _product_lst;

        }
    }
}
