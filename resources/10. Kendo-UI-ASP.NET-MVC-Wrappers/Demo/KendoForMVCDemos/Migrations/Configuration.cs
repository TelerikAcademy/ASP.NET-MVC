namespace KendoForMVCDemos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KendoForMVCDemos.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<KendoForMVCDemos.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KendoForMVCDemos.Models.ApplicationDbContext context)
        {
            // this.PopulateBooks(context);
        }

        private void PopulateBooks(Models.ApplicationDbContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                var category = new Category
                {
                    Name = "Category " + i,
                };

                for (int j = 0; j < 10; j++)
                {
                    category.Books.Add(new Book
                        {
                            Title = "Book " + i + " " + j,
                            Content = "Content " + i + " " + j,
                            Author = "Author " + i + " " + j,
                            Category = category
                        });
                }

                context.Categories.Add(category);
            }
        }
    }
}
