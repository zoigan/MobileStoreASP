using System;
using System.Linq;

namespace MobileStore.Models
{
    public static class SampleData
    {
        public static void Initialize(MobileContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        UserId = Guid.NewGuid(),
                        Name = "iPhone X",
                        Company = "Apple",
                        Price = 600
                    },
                    new Phone
                    {
                        UserId = Guid.NewGuid(),
                        Name = "Samsung Galaxy Edge",
                        Company = "Samsung",
                        Price = 550
                    },
                    new Phone
                    {
                        UserId = Guid.NewGuid(),
                        Name = "Pixel 3",
                        Company = "Google",
                        Price = 500
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
