using M7_Project_Works.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using System.Threading;
using System.IO;
using System.Web.Hosting;

namespace M7_Project_Works.Controllers
{
    [Authorize]
    public class PlayersController : Controller
    {
        teamDbContext db = new teamDbContext();
        // GET: Players
        [AllowAnonymous]
        //public ActionResult Index(int page = 1)
        //{
        //    var data = db
        //        .Players
        //        .Include(p => p.team)
        //        .OrderBy(x => x.PlayerId)
        //        .ToPagedList(page, 3);
        //    return View(data);
        //}
        public ActionResult Index(int page = 1, string sort = "PlayerId")
        {
            List<Player> data = db.Players.ToList();
            if (sort == "PlayerId")
            {
                data = data.OrderBy(x => x.PlayerId).ToList();
                ViewBag.Sort = "PlayerId DESC";
            }
            else if (sort == "PlayerId DESC")
            {
                data = data.OrderByDescending(x => x.PlayerId).ToList();
                ViewBag.Sort = "PlayerId";
            }
            else if (sort == "PlayerName")
            {
                data = data.OrderBy(x => x.PlayerName).ToList();
                ViewBag.Sort = "PlayerName DESC";
            }
            else if (sort == "PlayerName DESC")
            {
                data = data.OrderByDescending(x => x.PlayerName).ToList();
                ViewBag.Sort = "PlayerName";
            }
            
            ViewBag.TotalPages = (int)Math.Ceiling((double)db.Players.Count() / 4);
            ViewBag.CurrentPage = page;
            return View(
               data
                .Skip((page - 1) * 4)
                .Take(4)
                .ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Teams = db.teams.ToList();
            return View();
        }
        [HttpPost]
        //public ActionResult Create(Player p)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Players.Add(p);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Teams = db.teams.ToList();
        //    return View(p);
        //}
        public PartialViewResult Create(Player p)
        {
            Thread.Sleep(4000);
            if (ModelState.IsValid)
            {
                db.Players.Add(p);
                db.SaveChanges();
                return PartialView("_SuccessPartial");
            }
            else
            {
                return PartialView("_FailPartial");
            }
        }

        public ActionResult Edit(int id)
        {
            var t = db.Players.First(x => x.PlayerId == id);
            ViewBag.Teams = db.teams.ToList();
            return View(t);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Player p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teams = db.teams.ToList();
            return View(p);
        }
        public ActionResult Delete(int id)
        {
            var t = db.Players.First(x => x.PlayerId == id);
            return View(t);
        }
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirm(int id)
        {
            var p = new Player { PlayerId = id };
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}