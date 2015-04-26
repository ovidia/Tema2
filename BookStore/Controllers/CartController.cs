using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private BooksDb db = new BooksDb();

       
        // GET: /Cart/

        public ActionResult Index()
        {
            var list = db.Cart.Where(c => c.UserName == User.Identity.Name).ToList();
            var totalValue = Total(list);
            ViewBag.totalValue = totalValue;
            return View(list);

        }

        private string Total(List<CartModel> list)
        {
            float t =0;
            foreach (var b in list)

            {
                t += b.Price;
            }

            return t.ToString();
        }

     
    }
}