using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberWebsite.Models;

namespace CyberWebsite.Controllers
{
    public class ProductController : Controller
    {
        CyberWebsiteEntities cyberDB = new CyberWebsiteEntities();
        public ActionResult Index(int id)
        {
            return View();
        }

        public ActionResult ProductsInCategory(int id)
        {

            ViewBag.CategoryName = cyberDB.Categories.First(x => x.Id == id).Description;
            ViewBag.CategoryId = id;

            return View();
        }

	}
}