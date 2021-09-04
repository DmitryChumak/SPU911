using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public static class TestData
    {
        public static void Init(CarContext context)
        {
            if (!context.Cars.Any())
            {
                context.Cars.AddRange(
                    new Car
                    {
                        Title = "Kia",
                        Model = "Sorento",
                        Price = 22000
                    },
                    new Car
                    {
                        Title = "Lexus",
                        Model = "NX200t",
                        Price = 34000
                    },
                    new Car
                    {
                        Title = "Daewoo",
                        Model = "Lanos",
                        Price = 3500
                    },
                    new Car
                    {
                        Title = "Tesla",
                        Model = "Model X",
                        Price = 150000
                    },
                    new Car
                    {
                        Title = "Mini",
                        Model = "Cooper",
                        Price = 28000
                    },
                    new Car
                    {
                        Title = "Honda",
                        Model = "Civic",
                        Price = 34700
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
