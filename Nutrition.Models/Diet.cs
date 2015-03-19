namespace Nutrition.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Diet
    {
        private ICollection<Day> days;

        public Diet()
        {
            this.days = new List<Day>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? NumberOfDays { get; set; }

        public virtual ICollection<Day> Days
        {
            get { return this.days; }
            set { this.days = value; }

        }
    }
}
