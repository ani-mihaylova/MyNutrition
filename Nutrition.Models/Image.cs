namespace Nutrition.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Image
    {
        [Key]
        public int ID { get; set; }

        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
