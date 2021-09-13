using Microsoft.AspNetCore.Mvc;
using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Repository;
using ShopMoto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Controllers
{
    public class HomeController : Controller
    {
        private readonly MotoRepository _motoRep;

        public HomeController(MotoRepository motoRep)
        {
            _motoRep = motoRep;
        }
        public ViewResult Index()
        {
            var homeMoto = new HomeViewModel()
            {
                favMoto = _motoRep.getFavCars
            };

            return View(homeMoto);
        }
    }
}
