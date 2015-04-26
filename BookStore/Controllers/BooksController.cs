using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private BooksDb db = new BooksDb();

        //
        // GET: /Books/

        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        //
        // GET: /Books/Details/5

        public ActionResult Details(int id = 0)
        {
            BooksModel booksmodel = db.Books.Find(id);
            if (booksmodel == null)
            {
                return HttpNotFound();
            }
            return View(booksmodel);
        }

        //
        // GET: /Books/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Books/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BooksModel booksmodel)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(booksmodel);
                db.SaveChanges();
                return RedirectToAction("index", "home");
                //return RedirectToAction("Index");
            }

            return View(booksmodel);
        }

        //
        // GET: /Books/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BooksModel booksmodel = db.Books.Find(id);
            if (booksmodel == null)
            {
                return HttpNotFound();
            }
            return View(booksmodel);
        }

        //
        // POST: /Books/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BooksModel booksmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booksmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index", "home");
            }
            return View(booksmodel);
        }

        //
        // GET: /Books/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BooksModel booksmodel = db.Books.Find(id);
            if (booksmodel == null)
            {
                return HttpNotFound();
            }
            return View(booksmodel);
        }

        //
        // POST: /Books/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BooksModel booksmodel = db.Books.Find(id);
            db.Books.Remove(booksmodel);
            db.SaveChanges();
            return RedirectToAction("index", "home");
        }

        public ActionResult Buy(int id = 0)
        {
            BooksModel booksmodel = db.Books.Find(id);
            if (booksmodel == null)
            {
                return HttpNotFound();
            }
            var cartModel = new CartModel()
            {
                Author = booksmodel.Author,
                Gender = booksmodel.Gender,
                Price = booksmodel.Price,
                Title = booksmodel.Title,
                Id = booksmodel.Id
            };

            return View(cartModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(CartModel cartmodel)
        {
            var booksmodel = db.Books.Find(cartmodel.Id);
            cartmodel.Author = booksmodel.Author;
            cartmodel.Gender = booksmodel.Gender;
            cartmodel.Price = booksmodel.Price*cartmodel.Count;
            cartmodel.Title = booksmodel.Title;
            cartmodel.UserName = User.Identity.Name;
            if (ModelState.IsValid)
            {
                db.Cart.Add(cartmodel);
                db.SaveChanges();
                return RedirectToAction("index", "home");
            }

            return View(cartmodel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}