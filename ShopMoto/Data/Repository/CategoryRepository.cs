using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Repository
{
    public class CategoryRepository : IMotoCategory
    {
        private readonly AppDBContext appDBContext;

        public CategoryRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Category> AllCategories => appDBContext.Category;
    }
}
