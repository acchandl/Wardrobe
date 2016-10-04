﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe00.Models
{
    public class Bottom
    {
        [Key]
        public int bottomID { get; set; }

        public string bottomName { get; set; }
        public string photo { get; set; }
        public int seasonID { get; set; }
        public int occasionID { get; set; }
        public int colorID { get; set; }
    

        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }
        public virtual Color Color { get; set; }

        public virtual ICollection<Outfit> Outfits { get; set; }
    }
}