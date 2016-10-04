using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wardrobe00.Models;

namespace Wardrobe00.Controllers
{
    public class ShoesController : Controller
    {
        private Wardrobe00Context db = new Wardrobe00Context();

        // GET: Shoes
        public ActionResult Index()
        {
            var shoes = db.Shoes.Include(s => s.Color).Include(s => s.Occasion).Include(s => s.Season);
            return View(shoes.ToList());
        }

        // GET: Shoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoe shoe = db.Shoes.Find(id);
            if (shoe == null)
            {
                return HttpNotFound();
            }
            return View(shoe);
        }

        // GET: Shoes/Create
        public ActionResult Create()
        {
            ViewBag.colorID = new SelectList(db.Colors, "colorID", "colorName");
            ViewBag.occasionID = new SelectList(db.Occasions, "occasionID", "occasionName");
            ViewBag.seasonID = new SelectList(db.Seasons, "seasonID", "seasonName");
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shoeID,typeID,shoeName,photo,seasonID,occasionID,colorID")] Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                db.Shoes.Add(shoe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.colorID = new SelectList(db.Colors, "colorID", "colorName", shoe.colorID);
            ViewBag.occasionID = new SelectList(db.Occasions, "occasionID", "occasionName", shoe.occasionID);
            ViewBag.seasonID = new SelectList(db.Seasons, "seasonID", "seasonName", shoe.seasonID);
            return View(shoe);
        }

        // GET: Shoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoe shoe = db.Shoes.Find(id);
            if (shoe == null)
            {
                return HttpNotFound();
            }
            ViewBag.colorID = new SelectList(db.Colors, "colorID", "colorName", shoe.colorID);
            ViewBag.occasionID = new SelectList(db.Occasions, "occasionID", "occasionName", shoe.occasionID);
            ViewBag.seasonID = new SelectList(db.Seasons, "seasonID", "seasonName", shoe.seasonID);
            return View(shoe);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shoeID,typeID,shoeName,photo,seasonID,occasionID,colorID")] Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.colorID = new SelectList(db.Colors, "colorID", "colorName", shoe.colorID);
            ViewBag.occasionID = new SelectList(db.Occasions, "occasionID", "occasionName", shoe.occasionID);
            ViewBag.seasonID = new SelectList(db.Seasons, "seasonID", "seasonName", shoe.seasonID);
            return View(shoe);
        }

        // GET: Shoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoe shoe = db.Shoes.Find(id);
            if (shoe == null)
            {
                return HttpNotFound();
            }
            return View(shoe);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shoe shoe = db.Shoes.Find(id);
            db.Shoes.Remove(shoe);
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
