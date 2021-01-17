using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Management_Siddique.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Siddique.Controllers
{
    public class HospitalsController : Controller
    {
        IHospitalRepo repo;
        public HospitalsController(IHospitalRepo repo) { this.repo = repo; }
        public IActionResult Index()
        {
            return View(repo.GetHospitals());
        }
    }
}