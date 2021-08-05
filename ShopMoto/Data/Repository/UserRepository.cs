using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Repository
{
    public class UserRepository
    {
        private readonly AppDBContext appDBContext;
        private readonly User user;
        public UserRepository(AppDBContext appDBContext, User user)
        {
            this.appDBContext = appDBContext;
            this.user = user;
        }
        public void updateUser(User user)
        {

            appDBContext.Users.Update(user);
            appDBContext.SaveChanges();
        }
        public void createUser(User user)
        {
            appDBContext.Users.Add(user);
            appDBContext.SaveChanges();
        }
    }
}
