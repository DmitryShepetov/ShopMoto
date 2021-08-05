using ShopMoto.Data.Interfaces;
using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.mocks
{
    public class MockCategory : IMotoCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{ categoryName = "СпортБайк", desc = "Это мотоцикл, оптимизированный для скоростия" },
                    new Category{ categoryName = "Чоппер", desc = "Это стильный и крутой мотоцикл"}
                };
            }
        }
    }
}
