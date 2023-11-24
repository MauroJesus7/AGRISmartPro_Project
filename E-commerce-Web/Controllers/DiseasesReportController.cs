using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AGRISmartPro.Classes;
using AGRISmartPro.Models;

namespace AGRISmartPro.Controllers
{
    public class DiseasesReportController : Controller
    {
        private AppDbContext db = new AppDbContext();

        //IMAGE UPLOAD 

        // CASCADE LIST VIEW CONTROL
        public JsonResult GetDiseases(int cropId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var diseases = db.Diseases.AsQueryable();
            //var diseases = db.Diseases.ToList();

            if (cropId!=0)
            {
                diseases= diseases.Where(c => c.CropId == cropId);
                //diseases = diseases.Where(c => c.CropId == cropId).ToList();
            }            
         
            return Json(diseases);
        }

        // GET: Reports
        public ActionResult Index()
        {            
            var reports = db.DiseasesReport.Include(x => x.Diseases).Include(x => x.Crops).Include(x => x.User);
            return View(reports.ToList());
        }

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseReport report = db.DiseasesReport.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: DiseasesReport/Create
        public ActionResult Create()
        {
            ViewBag.DiseaseId = new SelectList(CombosHelper.GetDiseases(), "DiseaseId", "Name");
            ViewBag.CropId = new SelectList(CombosHelper.GetCrops(), "CropId", "Name");
            return View();
        }

        // POST: DiseasesReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiseaseReport report)
        {
            if (ModelState.IsValid)
            {           
                db.DiseasesReport.Add(report);
                db.SaveChanges();                

                if (report.PhotoFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}", report.Dis_ReportId);

                    var response = FilesHelper.UploadPhoto(report.PhotoFile, folder, file);
                    if (response)
                    {
                        pic = string.Format("{0}/{1}", folder, file);
                        report.Photo = pic;
                    }
                }

                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiseaseId = new SelectList(CombosHelper.GetDiseases(), "DiseaseId", "Name", report.DiseaseId);
            ViewBag.CropId = new SelectList(CombosHelper.GetCrops(), "CropId", "Name", report.CropId);
            return View(report);
        }

        // GET: DiseasesReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseReport report = db.DiseasesReport.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiseaseId = new SelectList(CombosHelper.GetDiseases(), "DiseaseId", "Name", report.DiseaseId);
            ViewBag.CropId = new SelectList(CombosHelper.GetCrops(), "CropId", "Name", report.CropId);
            return View(report);
        }

        // POST: DiseasesReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DiseaseReport report)
        {
            if (ModelState.IsValid)
            {              

                if (report.PhotoFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}.jpg", report.Dis_ReportId);

                    var response = FilesHelper.UploadPhoto(report.PhotoFile, folder, file);
                    if (response)
                    {
                        pic = string.Format("{0}/{1}", folder, file);
                        report.Photo = pic;
                        db.Entry(report).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }

                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(CombosHelper.GetDiseases(), "CropId", "Name", report.DiseaseId);
            ViewBag.CropId = new SelectList(CombosHelper.GetCrops(), "CropId", "Name", report.CropId);
            return View(report);
        }

        // GET: DiseasesReport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseReport company = db.DiseasesReport.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: DiseasesReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiseaseReport company = db.DiseasesReport.Find(id);
            db.DiseasesReport.Remove(company);
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
