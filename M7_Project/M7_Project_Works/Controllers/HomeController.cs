using M7_Project_Works.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M7_Project_Works.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Message()
        {
            var data = new MessageData { Title = "Cricket in Bangladesh", MessageType = "Normal", MessageText = " Cricket is the most popular sport in Bangladesh. There is a strong domestic league which on many occasions also saw Test players from many countries (Sri Lanka, India, Pakistan, and England) gracing the cricket fields of Bangladesh. In the year 2000 Bangladesh became a full member of the International Cricket Council. The Bangladesh national cricket team goes by the nickname of the Tigers. Bangladesh's victory in the ICC Under-19 Cricket World Cup which was held in South Africa in 2020 is the country's biggest cricketing achievement."};
            return PartialView("_Message", data);
        }
    }
}