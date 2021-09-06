using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDBContext appDBContext;
        public BaseRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public User Create(User model)
        {
            appDBContext.Set<User>().Add(model);
            appDBContext.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = appDBContext.Set<User>().FirstOrDefault(m => m.Id == id);
            appDBContext.Set<User>().Remove(toDelete);
            appDBContext.SaveChanges();
        }

        public User Get(Guid id)
        {
            return appDBContext.Set<User>().FirstOrDefault(m => m.Id == id);
        }

        public List<User> GetAll()
        {
            return appDBContext.Set<User>().ToList();
        }

        public User Update(User model)
        {
            var toUpdate = appDBContext.Set<User>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            appDBContext.Update(toUpdate);
            appDBContext.SaveChanges();
            return toUpdate;
        }
    }
}
