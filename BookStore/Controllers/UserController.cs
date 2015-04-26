using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BookStore.Models;
using BookStore.Service;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService = new UserService();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.LogInModel user)
        {
            if (ModelState.IsValid)
            {
                if (_userService.IsValid(user.Username, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                    var role = _userService.GetUserRole(user.Username, user.Password);
                    Session["user"] = role;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Cart/Create

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Cart/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel user)
        {
            _userService.RegisterUser(user);
           return RedirectToAction("Login");
        }
    }
}
