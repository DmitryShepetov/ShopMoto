using Microsoft.EntityFrameworkCore;
using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Repository
{
    public class BaseRepository 
    {
        private readonly AppDBContext appDBContext;
        public BaseRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task<User> CreateAsync(User model)
        {
            await appDBContext.Set<User>().AddAsync(model);
            appDBContext.SaveChanges();
            return model;
        }

        public async void Delete(Guid id)
        {
            var toDelete = await appDBContext.Set<User>().FirstOrDefaultAsync(m => m.Id == id);
            appDBContext.Set<User>().Remove(toDelete);
            await appDBContext.SaveChangesAsync();
        }

        public async Task<User> GetAsync(Guid id) => await appDBContext.Set<User>().FirstOrDefaultAsync(m => m.Id == id);

        public async Task<List<User>> GetAllAsync() => await appDBContext.Set<User>().ToListAsync();
        public async Task<User> UpdateAsync(User model)
        {
            var toUpdate = await appDBContext.Set<User>().FirstOrDefaultAsync(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            appDBContext.Update(toUpdate);
            await appDBContext.SaveChangesAsync();
            return toUpdate;
        }
    }
}
