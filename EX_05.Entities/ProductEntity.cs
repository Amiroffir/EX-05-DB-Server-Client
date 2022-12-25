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


         
        public Product GetProductByID(int id)
        {
            return MainManager.Instance.ProductsList[id];
        }

        public void GetProductsFromDB()
        {
            Data.Sql.ProductSQL productSQL = new Data.Sql.ProductSQL();
            MainManager.Instance.ProductsList = productSQL.getProductsFromDB();

        }

    }
}
