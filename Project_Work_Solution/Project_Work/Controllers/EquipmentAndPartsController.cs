using Project_Work.Models;
using Project_Work.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Work.Controllers
{
    public class EquipmentAndPartsController : Controller
    {
        // GET: EquipmentAndParts
        EquipentRepository repo = new EquipentRepository();
        public ActionResult Index()
        {
            var data = repo.GetAllRelated();

            return View(data);
        }
        public PartialViewResult GetParts(int id)
        {
            var data = repo.GetPartsOfEquipment(id);
            return PartialView("_Parts", data);
        }
        public ActionResult Create()
        {
            ViewBag.EquipmentTypes = repo.GetTypesForDropDown();
            return View();
        }
        [HttpPost]
        public JsonResult CreatePost(Equipment eq)
        {
            if (ModelState.IsValid)
            {
                repo.InsertEquipmentWithPart(eq);
                return Json(new { success=true, message="Data save succeeded"}, JsonRequestBehavior.DenyGet);
            }
            return Json(new { success = false, message = "Data save failed" }, JsonRequestBehavior.DenyGet);
        }
    }
}