using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Interfaces
{
    public interface IBaseRepository
    {
        public List<User> GetAll();
        public User Get(Guid id);
        public User Create(User model);
        public User Update(User model);
        public void Delete(Guid id);
    }
}
