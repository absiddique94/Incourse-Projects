using Project_Work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Work.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        EquipmentDbContext db = new EquipmentDbContext();
        public ActionResult Index()
        {
            return View(db.EquipmentTypes.ToList());
        }
    }
}