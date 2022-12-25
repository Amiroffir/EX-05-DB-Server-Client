using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EX_05.Model;

namespace EX_05.Entities
{
    public class ProductEntity
    {


         public void GetProductsFromDB()
        {
            MainManager.Instance.ProductsList.Clear();
            DAL.SQLQuery.runCommand("SELECT * FROM [dbo].[Products]", GetProducts);
        }
        public Product GetProductByID(int id)
        {
            return MainManager.Instance.ProductsList[id];
        }


        private void  GetProducts (SqlDataReader reader)
        {
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
      
               MainManager.Instance.ProductsList.Add(product.ProductID, product);
            }
        }
    }
}
