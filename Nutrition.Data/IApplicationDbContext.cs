namespace Nutrition.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Nutrition.Models;

    public interface IApplicationDbContext
    {
        IDbSet<Recipe> Recipes { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<Diet> Diets { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<Day> Days { get; set; }

        IDbSet<Image> Images { get; set; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
