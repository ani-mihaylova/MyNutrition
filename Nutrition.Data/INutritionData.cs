namespace Nutrition.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Nutrition.Data.Repositories;
    using Nutrition.Models;

    public interface INutritionData
    {
        IApplicationDbContext Context { get; }

        IGenericRepository<Recipe> Recipes { get; }

        IGenericRepository<Day> Days { get;}

        IGenericRepository<Image> Images { get; }

        IGenericRepository<Tag> Tags { get; }

        IGenericRepository<Diet> Diets { get; }

        IGenericRepository<User> Users { get; }

        int SaveChanges();

        void Dispose();
    }
}
