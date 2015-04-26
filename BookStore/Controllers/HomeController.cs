using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private BooksDb db = new BooksDb();
        public ActionResult Index()
        {
            ViewBag.Message = " Enjoy our books!";
            if (Session["user"] == null)
            {
                FormsAuthentication.SignOut();
              
                Session["user"] = "guest";
            }

            return View(db.Books.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Do you want to find more about us? Here it is:";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can contact us here:";

            return View();
        }

       
    }
}
