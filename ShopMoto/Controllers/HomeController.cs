using Microsoft.AspNetCore.Mvc;
using ShopMoto.Data.Interfaces;
using ShopMoto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllMoto _motoRep;

        public HomeController(IAllMoto motoRep)
        {
            _motoRep = motoRep;
        }
        public  ViewResult Index()
        {
            var homeMoto = new HomeViewModel()
            {
                favMoto = _motoRep.getFavCars
            };

            return View(homeMoto);
        }
    }
}
