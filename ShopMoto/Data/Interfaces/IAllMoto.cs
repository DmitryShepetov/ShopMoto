using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Interfaces
{
    public interface IAllMoto
    {
        IEnumerable<Moto> Moto { get; }
        IEnumerable<Moto> getFavCars { get; }
        Moto getObjectCar(int carId);
    }
}
