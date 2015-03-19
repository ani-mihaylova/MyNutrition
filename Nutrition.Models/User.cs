namespace Nutrition.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Diet> diets;
        private ICollection<Recipe> myRecipes;

        public User()
        {
            this.diets = new List<Diet>();
            this.myRecipes = new HashSet<Recipe>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Diet> Diets
        {
            get { return this.diets; }
            set { this.diets = value; }
        }

        public virtual ICollection<Recipe> MyRecipes
        {
            get { return this.myRecipes; }
            set { this.myRecipes = value; }
        }
    }

}
