using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe00.Models
{
    public class Color
    {
        [Key]
        public int colorID { get; set; }
        public string colorName { get; set; }

        ICollection<Outfit> ClothingItems { get; set; }
        ICollection<Top> Top { get; set; }
        ICollection<Bottom> Bottoms { get; set; }
        ICollection<Shoe> Shoes { get; set; }

    }
}