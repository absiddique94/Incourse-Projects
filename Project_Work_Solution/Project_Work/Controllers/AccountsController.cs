using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Project_Work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Work.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel m)
        {
            var User_Store = new UserStore<IdentityUser>();

            var User_Manager = new UserManager<IdentityUser>(User_Store);

            var User = User_Manager.Find(m.Username, m.Password);



            if (User != null)

            {

                var Auth_Manager = HttpContext.GetOwinContext().Authentication;

                var User_Identity = User_Manager.CreateIdentity(User, DefaultAuthenticationTypes.ApplicationCookie);



                Auth_Manager.SignIn(new AuthenticationProperties() { IsPersistent = false }, User_Identity);

                return RedirectToAction("Index", "Home");

            }

            else

            {

                ModelState.AddModelError("", "Username or password incorrect.");

            }
            return View(m);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(LoginModel m)
        {
            var User_Store = new UserStore<IdentityUser>();

            var User_Manager = new UserManager<IdentityUser>(User_Store);



            var New_User = new IdentityUser() { UserName = m.Username };

            IdentityResult User_Result = User_Manager.Create(New_User, m.Password);



            if (User_Result.Succeeded)

            {

                var Auth_Manager = HttpContext.GetOwinContext().Authentication;



                return RedirectToAction("Login");

            }

            else

            {

                ModelState.AddModelError("", User_Result.Errors.FirstOrDefault());

            }
            return View(m);
        }
        public ActionResult Logout()
        {
            var Auth_Manager = HttpContext.GetOwinContext().Authentication;

            Auth_Manager.SignOut();

            return RedirectToAction("Login", "Accounts", new { });
        }
    }
}