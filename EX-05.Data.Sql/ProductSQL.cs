using EX_05.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_05.Data.Sql
{
    // This class is responsible for all the SQL queries
    public class ProductSQL
    {
        Dictionary<int, Product> productsList = new Dictionary<int, Product>();
        public Dictionary<int, Product> getProductsFromDB()
        {
           
            DAL.SQLQuery.runCommand("SELECT * FROM [dbo].[Products]", GetProducts);
            return productsList;
        }
        private void GetProducts(SqlDataReader reader)
        {
            productsList.Clear();
            while (reader.Read())
            {

                Product product = new Product();
                product.ProductID = reader.GetInt32(0);
                product.ProductName = reader.GetString(1);
                product.SupplierID = reader.GetInt32(2);
                product.CategoryID = reader.GetInt32(3);
                product.QuantityPerUnit = reader.GetString(4);
                product.UnitPrice = reader.GetDecimal(5);
                product.UnitsInStock = reader.GetInt16(6);
                product.UnitsOnOrder = reader.GetInt16(7);
                product.ReorderLevel = reader.GetInt16(8);
                product.Discontinued = reader.GetBoolean(9);

               productsList.Add(product.ProductID, product);
            }
        }

    }
}
