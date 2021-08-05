using Microsoft.AspNetCore.Mvc;
using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using ShopMoto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllMoto _motoRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllMoto motoRep, ShopCart shopCart)
        {
            _motoRep = motoRep;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;
            var obj = new ShopCartViewModel { shopCart = _shopCart };
            return View(obj);
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = _motoRep.Moto.FirstOrDefault(i => i.id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

    }
}
