using CrudAssignment.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudAssignment.Models
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CrudAssignmentContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CrudAssignmentContext>>()))
            {
                if (context == null || context.Item == null)
                {
                    throw new ArgumentNullException("Null CrudAssignmentContext");
                }

                if (context.Item.Any())
                {
                    return;   // DB has been seeded
                }

                context.Item.AddRange(
                    new Item
                    {
                        Id = 1,
                        Name = "Chicken",
                        Description = "juicy",
                        Price = 7.99M
                    },

                    new Item
                    {
                        Id = 2,
                        Name = "Steak",
                        Description = "Red",
                        Price = 10.99M
                    },

                    new Item
                    {
                        Id = 3,
                        Name = "Turkey",
                        Description = "Sandwich",
                        Price = 4.99M
                    },

                    new Item
                    {
                        Id = 4,
                        Name = "Hamburger",
                        Description = "meat",
                        Price = 8.99M
                    },


                    new Item
                    {
                        Id = 5,
                        Name = "Cheese",
                        Description = "cheesy",
                        Price = 0.99M
                    }


                );
            }
        }


    }
}
