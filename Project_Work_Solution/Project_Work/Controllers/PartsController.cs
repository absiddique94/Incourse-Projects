using Project_Work.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Project_Work.Models;

namespace Project_Work.Controllers
{
    [Authorize]
    public class PartsController : Controller
    {
        EquipentRepository repo = new EquipentRepository();
        public ActionResult Index(int pg = 1)
        {
            return View(repo.GetParts().ToPagedList(pg, 5));
        }
        public ActionResult Create()
        {
            ViewBag.EqTypes = repo.GetTypesForDropDown();
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Part p)
        {
            if (ModelState.IsValid)
            {
                repo.InsertPart(p);
                return RedirectToAction("Index");
            }
            ViewBag.EqTypes = repo.GetTypesForDropDown();
            return View(p);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.EqTypes = repo.GetTypesForDropDown();
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Part p)
        {
            if (ModelState.IsValid)
            {
                repo.UpdatePart(p);
                return RedirectToAction("Index");
            }
            ViewBag.EqTypes = repo.GetTypesForDropDown();
            return View(p);
        }
        public ActionResult Delete(int id)
        {
            
            return View(repo.GetPart(id));
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                repo.DeletePart(id);
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }
}