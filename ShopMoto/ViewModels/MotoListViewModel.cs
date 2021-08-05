using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.ViewModels
{
    public class MotoListViewModel
    {
        public IEnumerable<Moto> allMoto { get; set; }

        public string currCategory { get; set; }
    }
}
