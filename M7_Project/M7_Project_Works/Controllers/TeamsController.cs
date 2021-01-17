using M7_Project_Works.Models;
using M7_Project_Works.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M7_Project_Works.Controllers
{
    [Authorize]
    public class TeamsController : Controller
    {
       
        teamDbContext db = new teamDbContext();
        // GET: Teames
        [AllowAnonymous]
        public ActionResult Index()
        {
            var data = db.teams
                    .Select(x => new TeamVM { teamId = x.teamId, teamName = x.teamName, Location = x.Location, Contact=x.Contact, Established = x.Established })
                    .ToList();
            return View(data); 

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(team b)
        {
            if (ModelState.IsValid)
            {
                db.teams.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b);
        }
        public ActionResult Edit(int id)
        {
            var t = db.teams.First(x => x.teamId == id);

            return View(t);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(team t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t);
        }
        public ActionResult Delete(int id)
        {
            var t = db.teams.First(x => x.teamId == id);
            return View(t);
        }
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirm(int id)
        {
            var t = new team { teamId = id };
            db.Entry(t).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}