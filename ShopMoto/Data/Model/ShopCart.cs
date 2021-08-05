using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Model
{
    public class ShopCart
    {
        private readonly AppDBContext appDBContext;

        public ShopCart(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        public void AddToCart(Moto moto)
        {
            appDBContext.ShopCartItems.Add(new ShopCartItem 
            { 
                ShopCartId = ShopCartId,
                moto = moto,
                price = moto.price 
            });
            appDBContext.SaveChanges();
        }
        public List<ShopCartItem> getShopItems()
        {
            return appDBContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.moto).ToList();
        }
    }
}
