namespace Nutrition.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Recipe
    {
        private ICollection<Tag> tags;
        private ICollection<Comment> comments;

        public Recipe()
        {
            this.tags = new HashSet<Tag>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? TimeToEat { get; set; }

        public virtual Image Image { get; set; }

        public virtual Rating Rating { get; set; }

        [Required]
        public string Ingredients { get; set; }


        [Required]
        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Tags in recipe cannot be null!");
                }

                this.tags = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
