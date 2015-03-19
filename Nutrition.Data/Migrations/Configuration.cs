namespace Nutrition.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Nutrition.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedTags(context);
        }

        private void SeedTags(ApplicationDbContext context)
        {
            if (context.Tags.Count() != 0)
            {
                return;
            }

            var listOfTags = new List<Tag>()
            {
                new Tag(){ Name="Супи"},
                new Tag(){ Name="Салати"},
                new Tag(){ Name="Предстия"},
                new Tag(){ Name="Ястия с яйца"},
                new Tag(){ Name="Сосове"},
                new Tag(){ Name="Пици"},
                new Tag(){ Name="Тестени изделия"},
                new Tag(){ Name="Зеленчуци"},
                new Tag(){ Name="Десерти"},
                new Tag(){ Name="Варива"},
                new Tag(){ Name="Гъби"},
                new Tag(){ Name="Паста"},
                new Tag(){ Name="Напитки"},
                new Tag(){ Name="Ориз"},
                new Tag(){ Name="Ястия от птиче месо"},
                new Tag(){ Name="Ястия с месо"},
                new Tag(){ Name="Ястия с риба"}
            };

            foreach (var tag in listOfTags)
            {
                context.Tags.Add(tag);
            }

            context.SaveChanges();
        }
    }
}
