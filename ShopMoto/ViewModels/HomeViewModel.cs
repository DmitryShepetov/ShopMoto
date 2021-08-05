using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Moto> favMoto { get; set; }
    }
}
