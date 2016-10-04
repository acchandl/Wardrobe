using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe00.Models
{
    public class Accessory
    {
        internal object accessoryId;

        [Key]
        public int accessoryID { get; set; }

        public string accessoryName { get; set; }
        public string photo { get; set; }
        public int colorID { get; set; }
        public int seasonID { get; set; }
        public int occasionID { get; set; }

        public virtual Color Color { get; set; }
        public virtual Season Season { get; set; }
        public virtual Occasion Occasion { get; set; }
        public virtual ICollection<Outfit> Outfits { get; set; }
    }
}