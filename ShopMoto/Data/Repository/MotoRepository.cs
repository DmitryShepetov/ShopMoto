using Microsoft.EntityFrameworkCore;
using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Repository
{
    public class MotoRepository
    {
        private readonly AppDBContext appDBContext;

        public MotoRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Moto> Moto => appDBContext.Moto.Include(c => c.Category);

        public IEnumerable<Moto> getFavCars => appDBContext.Moto.Where(p => p.isFavourite).Include(c => c.Category);

        public async Task<Moto> getObjectCarAsync(int carId) => await appDBContext.Moto.FirstOrDefaultAsync(p => p.id == carId);

    }
}
