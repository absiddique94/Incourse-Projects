using Project_Work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Project_Work.Repositories;
using PagedList;
using PagedList.Mvc;
namespace Project_Work.Controllers
{
    public class EquipmentsController : Controller
    {
        EquipentRepository repo = new EquipentRepository();
        public ActionResult Index(int pg =1)
        {
            return View("IndexCRUD",repo.GetEquipments().ToPagedList(pg, 5));
        }
        public ActionResult PartList(int id)
        {
            var eq= repo.GetEquipment(id);
            ViewBag.Equipment= eq == null ? "" : eq.Model;
            return View(repo.GetPartsOfEquipment(id));
        }
        public ActionResult EquipmentDetails(int id)
        {
            return View(repo.GetEquipment(id));
        }
        public ActionResult CreateEquipment(int id)
        {
            return View();
        }
        public ActionResult EditEquipment(int id)
        {
            ViewBag.EqTypes = repo.GetTypesForDropDown();
            return View(repo.GetEquipment(id));
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditEquipment(Equipment eq)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateEquipment(eq);
                return RedirectToAction("Index");
            }
            ViewBag.EqTypes = repo.GetTypesForDropDown();
            return View(eq);
        }

    }
}