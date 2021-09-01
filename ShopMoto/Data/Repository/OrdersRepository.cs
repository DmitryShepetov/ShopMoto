using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContext appDBContext;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDBContext appDBContext, ShopCart shopCart)
        {
            this.appDBContext = appDBContext;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.dateTime = DateTime.Now;
            appDBContext.Order.Add(order);
            appDBContext.SaveChanges();
            var items = shopCart.listShopItems;
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    motoID = el.moto.id,
                    orderID = order.id,
                    price = el.moto.price     
                };
                appDBContext.OrderDetail.Add(orderDetail);
            }
            appDBContext.SaveChanges();
            print();
        }
    }
}
