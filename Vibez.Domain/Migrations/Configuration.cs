namespace Vibez.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vibez.Domain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Vibez.Domain.Context.VibezContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vibez.Domain.Context.VibezContext context)
        {
            //var categories = context.Categories.ToList();
            var category = new Category
            {
                Name = "News"
            };

            var catgry = context.Categories.Where(cn => cn.Name == category.Name).FirstOrDefault();

            if(catgry == null)
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
            
            //context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
