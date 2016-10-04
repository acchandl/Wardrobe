using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe00.Models
{
    public class Season
    {
        [Key]
        public int seasonID { get; set; }
        public string seasonName { get; set; }

        ICollection<Outfit> Outfit { get; set; }
        ICollection<Top> Top { get; set; }
        ICollection<Bottom> Bottom { get; set; }
        ICollection<Shoe> Shoes { get; set; }
        ICollection<Accessory> Accessories { get; set; }

    }
}