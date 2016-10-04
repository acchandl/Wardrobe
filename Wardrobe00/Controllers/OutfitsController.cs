using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wardrobe00.Models;
using Wardrobe00.ViewModels;


namespace Wardrobe00.Controllers
{
    public class OutfitsController : Controller
    {
        private Wardrobe00Context db = new Wardrobe00Context();
        //private object outfitViewMod4l;
        //private object outfitViewModel;

        public IEnumerable<int> SelectedAccessories { get; private set; }

        // GET: Outfits
        public ActionResult Index()
        {
            var outfits = db.Outfits.Include(o => o.Bottom).Include(o => o.Shoe).Include(o => o.Top);
            return View(outfits.ToList());
        }

        // GET: Outfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // GET: Outfits/Create
        public ActionResult Create()
        {
            Outfit outfit = new Outfit();
            ViewBag.bottomID = new SelectList(db.Bottoms, "bottomID", "bottomName");
            ViewBag.shoeID = new SelectList(db.Shoes, "shoeID", "shoeName");
            ViewBag.topID = new SelectList(db.Tops, "topID", "topName");

            OutfitViewModel outfitViewModel = new OutfitViewModel
            {
             
                Outfit = outfit,
                //look up all accessories, then converts them into 
                //selectListItem objects
                AllAccessories = from a in db.Accessories
                                 select new SelectListItem
                                 {
                                     Text = a.accessoryName,
                                     Value = a.accessoryId.ToString()
                                 }
            };
           
            return View(outfitViewModel);
            //may have to edit above
        }

        // POST: Outfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "outfitID,topID,bottomID,shoeID")] Outfit outfit, List<int> SelectedAccessories)
{

          
            if (ModelState.IsValid)
            {
                var existingOutfit = outfit;

                existingOutfit.topID = outfit.topID;
                existingOutfit.bottomID = outfit.bottomID;
                existingOutfit.shoeID = outfit.shoeID;

                foreach (int accessoryID in SelectedAccessories)
                {

                    existingOutfit.Accessories.Add(db.Accessories.Find(accessoryID));
                }
                db.Outfits.Add(outfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
      
            ViewBag.bottomID = new SelectList(db.Bottoms, "bottomId", "bottomName", outfit.bottomID);
            ViewBag.shoeID = new SelectList(db.Shoes, "shoeId", "shoeName", outfit.shoeID);
            ViewBag.topID = new SelectList(db.Tops, "topId", "topName", outfit.topID);
            return View(outfit);
        }
     
            
           
            
            //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "outfitID,topID,bottomID,shoeID")] Outfit outfit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Outfits.Add(outfit);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.bottomID = new SelectList(db.Bottoms, "bottomID", "bottomName", outfit.bottomID);
        //    ViewBag.shoeID = new SelectList(db.Shoes, "shoeID", "shoeName", outfit.shoeID);
        //    ViewBag.topID = new SelectList(db.Tops, "topID", "topName", outfit.topID);
        //    return View(outfit);
        //}

        // GET: Outfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }

            ViewBag.bottomID = new SelectList(db.Bottoms, "bottomID", "bottomName", outfit.bottomID);
            ViewBag.shoeID = new SelectList(db.Shoes, "shoeID", "shoeName", outfit.shoeID);
            ViewBag.topID = new SelectList(db.Tops, "topID", "topName", outfit.topID);

            OutfitViewModel outfitViewModel = new OutfitViewModel
            {
                Outfit = outfit,

                //look up all accessories, then converts them into 
                //selectListItem objects
                AllAccessories = from a in db.Accessories
                                 select new SelectListItem
                                 {
                                     Text = a.accessoryName,
                                     Value = a.accessoryId.ToString()
                                 }
            };


            return View(outfitViewModel);
        }



        // POST: Outfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "outfitId,bottomID,shoeID,topID")] Outfit outfit, List<int> SelectedAccessories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outfit).State = EntityState.Modified;
   
                var existingOutfit = db.Outfits.Find(outfit.outfitID);

            
                existingOutfit.topID = outfit.topID;
                existingOutfit.bottomID = outfit.bottomID;
                existingOutfit.shoeID = outfit.shoeID;

                existingOutfit.Accessories.Clear();

                foreach (int accessoryId in SelectedAccessories)
                {
                   
                    existingOutfit.Accessories.Add(db.Accessories.Find(accessoryId));
                }

            
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName", outfit.bottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ShoeName", outfit.shoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopId", "TopName", outfit.topID);
            return View(outfit);
        }

        //    var outfit = db.Outfits.Find(outfitViewModel.Outfit.outfitID);
        //    if (ModelState.IsValid)
        //    {
        //        outfit.Accessories.Clear();
        //        foreach (var accessoryID in outfitViewModel.SelectedAccessories)
        //        {

        //            outfit.Accessories.Add(db.Accessories.Find(accessoryID));
        //        }
        //        outfit.shoeID = outfitViewModel.Outfit.shoeID;
        //        outfit.topID = outfitViewModel.Outfit.topID;
        //        outfit.bottomID = outfitViewModel.Outfit.bottomID;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    outfitViewModel = new OutfitViewModel
        //    {
        //        Outfit = outfit,
        //        AllAccessories = from a in db.Accessories
        //                         select new SelectListItem
        //                         {
        //                             Text = a.accessoryName,
        //                             Value = a.accessoryId.ToString()
        //                         }
        //    };
        //    ViewBag.bottomID = new SelectList(db.Bottoms, "bottomId", "bottomName", outfit.bottomID);
        //    ViewBag.shoeID = new SelectList(db.Shoes, "shoeId", "shoeName", outfit.shoeID);
        //    ViewBag.topID = new SelectList(db.Tops, "topId", "topName", outfit.topID);
        //    return View(outfit);
        //}

        // GET: Outfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outfit outfit = db.Outfits.Find(id);
            db.Outfits.Remove(outfit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
