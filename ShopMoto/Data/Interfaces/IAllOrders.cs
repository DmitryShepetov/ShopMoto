using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrderAsync(Order order);
    }
}
