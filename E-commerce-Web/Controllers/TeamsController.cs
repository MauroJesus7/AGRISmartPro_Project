using AGRISmartPro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AGRISmartPro.Controllers
{
    public class TeamsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Teams
        public ActionResult Index()
        {
            var teams = db.Teams.ToList();
            return View(teams);
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team teams = db.Teams.Find(id);
            if (teams == null)
            {
                return HttpNotFound();
            }
            return View(teams);
        }

        // GET: Teams/Create
        public ActionResult Create() 
        {
            return View();
        }

        // POST: Teams/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "TeamId, Name, Description, Created_By")] Team team)
        {
            if (ModelState.IsValid)
            {
                //team.Created_At = DateTime.Now;
                db.Teams.Add(team);
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
                        ModelState.AddModelError(string.Empty, "Cannot save! Duplicated Name...");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }

                    return View(team);
                }
            }

            return View(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "TeamId, Name, Description, Created_By")] Team team)
        {
            if (ModelState.IsValid)
            {
                //team.Updated_At = DateTime.Now;
                db.Entry(team).State = EntityState.Modified;
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
                            ModelState.AddModelError(string.Empty, "Cannot save! Duplicated Name...");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                        return View(team);
                }
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teams/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
