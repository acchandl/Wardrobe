using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe00.Models
{
    public class Occasion
    {
        [Key]
        public int occasionID { get; set; }
        public string occasionName { get; set; }

        ICollection<Outfit> Outfit { get; set; }
        ICollection<Top> Top { get; set; }
        ICollection<Bottom> Bottoms { get; set; }
        ICollection<Shoe> Shoes { get; set; }
        ICollection<Accessory> Accessories { get; set; }
    }
}