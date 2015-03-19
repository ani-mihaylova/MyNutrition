namespace Nutrition.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Day
    {
        private ICollection<Recipe> recipes;

        public Day()
        {
            this.recipes = new List<Recipe>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public int Number { get; set; }

        public string Description { get; set; }

        public ICollection<Recipe> Recipes
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }

    }
}
