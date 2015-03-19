namespace Nutrition.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Nutrition.Data.Repositories;
    using Nutrition.Models;

    public class NutritionData:INutritionData
    {
         private readonly IApplicationDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public NutritionData(IApplicationDbContext context)
        {
            this.context = context;
        }

        public IApplicationDbContext Context
        {
            get { return this.context; }
        }

        public IGenericRepository<Recipe> Recipes
        {
            get { return this.GetRepository<Recipe>(); }
        }

        public IGenericRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IGenericRepository<Rating> Ratings
        {
            get { return this.GetRepository<Rating>(); }
        }

        public IGenericRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }
        }

        public IGenericRepository<Diet> Diets
        {
            get { return this.GetRepository<Diet>(); }
        }

        public IGenericRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IGenericRepository<Image> Images
        {
            get { return this.GetRepository<Image>(); }
        }

        public IGenericRepository<Day> Days
        {
            get { return this.GetRepository<Day>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeof(T)];
        }
    }
}
