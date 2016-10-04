using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wardrobe00.Models;

namespace Wardrobe00.ViewModels
{
    public class OutfitViewModel
    {
        public Outfit Outfit { get; set; }
        public IEnumerable<SelectListItem> AllAccessories { get; set; }

        public List<int> _selectedAccessories;
        public List<int> SelectedAccessories
        {
            get
            {
                if (_selectedAccessories == null)
                {
                    _selectedAccessories = (from a in Outfit.Accessories
                                            select a.accessoryID).ToList();
                }
                return _selectedAccessories;
            }
            set { _selectedAccessories = value; }
        }
    }
}