using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGRISmartPro.Models;

namespace AGRISmartPro.Controllers
{
    public class CropsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Crops
        public ActionResult Index()
        {
            return View(db.Crops.ToList());
        }

        // GET: Crops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crop crops = db.Crops.Find(id);
            if (crops == null)
            {
                return HttpNotFound();
            }
            return View(crops);
        }

        // GET: Crops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CropId, Name")] Crop crops)
        {
            if (ModelState.IsValid)
            {
                db.Crops.Add(crops);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    if (ex.InnerException != null &&
                        ex.InnerException.InnerException != null
                        && ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "Cannot save! Duplicated Crop Name...");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }

                    return View(crops);
                }
            }

            return View(crops);
        }

        // GET: Crops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crop crops = db.Crops.Find(id);
            if (crops == null)
            {
                return HttpNotFound();
            }
            return View(crops);
        }

        // POST: Crops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CropId, Name")] Crop crops)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crops).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    if (ex.InnerException != null &&
                        ex.InnerException.InnerException != null
                        && ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "Cannot save! Duplicated Crop Name...");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }

                    return View(crops);
                }
            }
            return View(crops);
        }

        // GET: Crops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crop crops = db.Crops.Find(id);
            if (crops == null)
            {
                return HttpNotFound();
            }
            return View(crops);
        }

        // POST: Crops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crop crops = db.Crops.Find(id);
            db.Crops.Remove(crops);
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null && 
                        ex.InnerException.InnerException != null
                        && ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError(string.Empty, "Is not possible remove the crop because of relationship... You must to remove the associated disease first.");
                }else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                return View(crops);
            }
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
