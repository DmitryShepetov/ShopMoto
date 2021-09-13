using Microsoft.AspNetCore.Mvc;
using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using ShopMoto.Data.Repository;
using ShopMoto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Controllers
{
    public class MotoController : Controller
    {
        private readonly MotoRepository _allMoto;
        private readonly IMotoCategory _allCategories;

        public MotoController(MotoRepository iAllMoto, IMotoCategory iMotoCat)
        {
            _allMoto = iAllMoto;
            _allCategories = iMotoCat;
        }
        [Route("Moto/List")]
        [Route("Moto/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Moto> moto = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                moto = _allMoto.Moto.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("Sportbike", category, StringComparison.OrdinalIgnoreCase))
                {
                    moto = _allMoto.Moto.Where(i => i.Category.categoryName.Equals("СпортБайк")).OrderBy(i => i.id);
                }
                else if (string.Equals("Chopper", category, StringComparison.OrdinalIgnoreCase))
                {
                    moto = _allMoto.Moto.Where(i => i.Category.categoryName.Equals("Чоппер")).OrderBy(i => i.id);
                }
                currCategory = _category;
            }

            var motoObj = new MotoListViewModel
            {
                allMoto = moto,
                currCategory = "currCategory"
            };



            return View(motoObj);
        }
        [Route("Moto/Info")]
        [Route("Moto/Info/{name}")]
        public ViewResult Info(string name)
        {
            string _name = name;
            IEnumerable<Moto> moto = null;
            /*string currName = "";*/
            if (string.IsNullOrEmpty(name))
            {
                moto = _allMoto.Moto.OrderBy(i => i.id);
            }
            else
            {
                moto = _allMoto.Moto.Where(i => i.name == name);
            }
            /*currName = _name;*/
            var motoObj = new MotoListViewModel
            {
                allMoto = moto
            };
            return View(motoObj);
        }
    }
}
