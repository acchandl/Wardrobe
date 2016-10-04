using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wardrobe00.Models
{
    public class Outfit
    {

        public Outfit()
        {
            Accessories = new HashSet<Accessory>();
        }

        [Key]
        public int outfitID { get; set; }
        public int topID { get; set; }
        public int bottomID { get; set; }
        public int shoeID { get; set; }


        //navigation properties
        public virtual Top Top { get; set; }
        public virtual Bottom Bottom { get; set; }
        public virtual Shoe Shoe { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }

    }
}