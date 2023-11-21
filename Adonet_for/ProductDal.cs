using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet_for
{
    internal class ProductDal
    {
        SqlConnection _conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=ETrade;integrated security = true");


        public List<Product> GetAll()
        {
            ConnectionControle();
            SqlCommand command = new SqlCommand("select * from Products" , _conn);


            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while(reader.Read())
            {
                Product product = new Product { 
                    
                    
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = Convert.ToString(reader["Name"]),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                    
                 
            
                };

                products.Add(product);
            }
           
            reader.Close();
            _conn.Close();
            return products;
        }
        
        public void ConnectionControle()
        {
            if(_conn.State == ConnectionState.Closed)
            { _conn.Open(); }
        }
        public void Add(Product product)
        {
            ConnectionControle();
            SqlCommand commend = new SqlCommand("Insert into Products Values(@Name , @UnitPrice , @StockAmount)",_conn);
            commend.Parameters.AddWithValue("@Name", product.Name);
            commend.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            commend.Parameters.AddWithValue("@StockAmount", product.StockAmount);
            commend.ExecuteNonQuery();

            _conn.Close();
        }
        public void Update(Product product)
        {
            ConnectionControle();
            SqlCommand commend = new SqlCommand(
                "Update Products set Name = @Name , UnitPrice = @UnitPrice , @StockAmount = @StockAmount where ID = @id"
                , _conn);
            commend.Parameters.AddWithValue("@Name", product.Name);
            commend.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            commend.Parameters.AddWithValue("@StockAmount", product.StockAmount);
            commend.Parameters.AddWithValue("@id", product.Id);
            commend.ExecuteNonQuery();

            _conn.Close();
        }
        public void Delete(int id)
        {
            ConnectionControle();
            SqlCommand commend = new SqlCommand(
                "Delete from Products where ID = @id"
                , _conn);
            commend.Parameters.AddWithValue("@id", id);
            commend.ExecuteNonQuery();

            _conn.Close();
        }


    }
}
