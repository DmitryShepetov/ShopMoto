/*using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopMoto.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContext content)
        {

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.Moto.Any())
            {
                content.AddRange(
                    new Moto
                    {
                        name = "Suzuki GSX 600R",
                        shortDesc = "Модель спортивного мотоцикла Suzuki GSX-R 600",
                        longDesc = "Острые грани и стремительный силуэт не выбиваются из фирменного стиля и напоминают о легендарных «джиксерах» прошлых лет.",
                        img = "/img/SuzukiGSX600R.jpg",
                        price = 4500,
                        isFavourite = true,
                        available = true,
                        Category = Categories["СпортБайк"],
                        country = "Япония",
                        volume = 599
                    },
                    new Moto
                    {
                        name = "Honda CBR 600RR",
                        shortDesc = "Модель спортивного мотоцикла Honda CBR 600RR",
                        longDesc = "Аппарат построенный по всем канонам жанра обладает 4-цилиндровым двигателем с рядным расположением цилиндров",
                        img = "/img/2006HondaCBR600RR-001.jpg",
                        price = 5000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["СпортБайк"]
                    },
                    new Moto
                    {
                        name = "Kawasaki ZX6R",
                        shortDesc = "Модель спортивного мотоцикла Kawasaki ZX6R",
                        longDesc = "Ninja ZX-6R с большим на 37 см3 объемом двигателя обладает преимуществами, которые обязательно доставят удовольствие от поездки.    ",
                        img = "/img/zx-6r.jpg",
                        price = 5500,
                        isFavourite = false,
                        available = false,
                        Category = Categories["СпортБайк"]
                    },
                    new Moto
                    {
                        name = "Yamaha R6",
                        shortDesc = "Модель спортивного мотоцикла Yamaha R6",
                        longDesc = "Легенда мотоспорта, многократный чемпион мира в классе Supersport – Yamaha YZF-R6",
                        img = "/img/YamahaR6.jpg",
                        price = 6000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["СпортБайк"]
                    },
                    new Moto
                    {
                        name = "Yamaha Drag Star",
                        shortDesc = "Модель крузера Yamaha Drag Star",
                        longDesc = "Это серийный мотоцикл, в той или иной мере тяготеющий к ретро-стилю",
                        img = "/img/yamaha-drag-star-400.jpg",
                        price = 12000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Чоппер"]

                    },
                    new Moto
                    {
                        name = "Suzuki Boulevard M109R",
                        shortDesc = "Модель пауэр-крузер Suzuki Boulevard M109R",
                        longDesc = "Это самый новый из стилей чоппероподобных мотоциклов, являющий собой нечто среднее между круизером и мускул-байком.",
                        img = "/img/SuzukiBoulevardM109.jpg",
                        price = 15000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Чоппер"]
                    });
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{ categoryName = "СпортБайк", desc = "Это мотоцикл, оптимизированный для скоростия" },
                        new Category{ categoryName = "Чоппер", desc = "Это стильный и крутой мотоцикл" }
                        };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);

                }
                return category;
            }
        }
    }
}
*/