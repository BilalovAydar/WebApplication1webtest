using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

//using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication1Context(serviceProvider.GetRequiredService<DbContextOptions<WebApplication1Context>>()))
            {
                // Look for any movies.
                if (context.Price.Any())
                {
                    return;   // DB has been seeded
                }
                context.Price.AddRange(
                    new Price
                    {
                        Name = "Прайс от 22.01.2014"
                    },
                    new Price
                    {
                        Name = "Прайс от 22.01.2014"
                    },
                    new Price
                    {
                        Name = "Прайс от 21.01.2013"
                    }, 
                    new Price
                    {
                        Name = "Прайс от 21.01.2013"
                    }
                );
                context.SaveChanges();
                if (context.Good.Any())
                {
                    return;   // DB has been seeded
                }
                context.Good.AddRange(
                    new Good
                    {
                        Name = "Стул",
                        MyIntCol = 2,
                        MyTextCol = "Значение для первой колонки",
                        PriceId = 1,
                        MyStrCol = "супер"                       
                    },
                    new Good
                    {
                        Name = "Стол",
                        MyIntCol = 2,
                        MyTextCol = "деревяный",
                        PriceId = 2,
                        MyStrCol = "супер"
                    },
                    new Good
                    {
                        Name = "Компьютер",
                        MyIntCol = 2,
                        MyTextCol = "Pentium 4",
                        PriceId = 3,
                        MyStrCol = "супер"
                    },
                    new Good
                    {
                        Name = "Стул",
                        MyIntCol = 2,
                        MyTextCol = "Значение для первой колонки",
                        PriceId = 2,
                        MyStrCol = "супер"
                    },
                    new Good
                    {
                        Name = "Стол",
                        MyIntCol = 2,
                        MyTextCol = "деревяный",
                        PriceId = 3,
                        MyStrCol = "супер"
                    },
                    new Good
                    {
                        Name = "Компьютер",
                        MyIntCol = 2,
                        MyTextCol = "Pentium 4",
                        PriceId = 1,
                        MyStrCol = "супер"
                    },
                    new Good
                    {
                        Name = "Стул",
                        MyIntCol = 2,
                        MyTextCol = "Значение для первой колонки",
                        PriceId = 3,
                        MyStrCol = "супер"
                    },
                    new Good
                    {
                        Name = "Стол",
                        MyIntCol = 2,
                        MyTextCol = "деревяный",
                        PriceId = 1,
                        MyStrCol = "супер"
                    },
                    new Good
                    {
                        Name = "Компьютер",
                        MyIntCol = 2,
                        MyTextCol = "Pentium 4",
                        PriceId = 2,
                        MyStrCol = "супер"
                    },
                    new Good
                    {
                        Name = "Стул",
                        MyIntCol = 2,
                        MyTextCol = "Значение для первой колонки",
                        PriceId = 2,
                        MyStrCol = "супер"
                    },
                    new Good
                    {
                        Name = "Стол",
                        MyIntCol = 2,
                        MyTextCol = "деревяный",
                        PriceId = 3,
                        MyStrCol = "супер"
                    },
                    new Good
                    {
                        Name = "Компьютер",
                        MyIntCol = 2,
                        MyTextCol = "Pentium 4",
                        PriceId = 1,
                        MyStrCol = "супер"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
