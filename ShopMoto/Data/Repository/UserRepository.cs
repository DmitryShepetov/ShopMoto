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
        public async void updateUserAsync(User user)
        {

            appDBContext.Users.Update(user);
            await appDBContext.SaveChangesAsync();
        }
        public async void createUserAsync(User user)
        {
            await appDBContext.Users.AddAsync(user);
            await appDBContext.SaveChangesAsync();
        }
    }
}
