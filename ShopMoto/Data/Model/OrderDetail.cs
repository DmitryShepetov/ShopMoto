using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Model
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int motoID { get; set; }
        public uint price { get; set; }
        public virtual Moto moto { get; set; }
        public virtual Order order { get; set; }   
    }
}
