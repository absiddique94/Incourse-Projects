using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Management_Siddique.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Siddique.Controllers
{
    public class ServicesController : Controller
    {
        IServiceRepo repo;
        public ServicesController(IServiceRepo repo) { this.repo = repo; }
        public IActionResult Index()
        {
            var s = repo.GetServices();
            return View(s);
        }
    }
}