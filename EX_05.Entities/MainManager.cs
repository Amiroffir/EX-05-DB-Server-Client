using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_05.Entities
{
    public class MainManager
    {
        // singelton 
        private static readonly MainManager _instance = new MainManager();
        private MainManager() {
            ProductsList = new Dictionary<int, Model.Product>();
            products = new ProductEntity();
            contactUs = new ContactUsEntity();

        }
        public static MainManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public ContactUsEntity contactUs;
        public ProductEntity products;
        public Dictionary<int,Model.Product> ProductsList;
       
        


    }
}

