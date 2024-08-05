using StoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModel
{
    public class StoreVM : BaseVM
    {
        public List<Product> products {  get; set; }

        public StoreVM()
        {
            products = new List<Product>();
        }
    }
}
