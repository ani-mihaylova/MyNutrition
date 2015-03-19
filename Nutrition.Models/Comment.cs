namespace Nutrition.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Comment
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }
    }
}
