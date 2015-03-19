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

        public PartialViewResult _ProductInfo(int id)
        {
            IList<Categories> model = null;
            //Gets the category
            Categories category = cyberDB.Categories.First(x => x.Id == id);

            //If category is root, get all subcategories
            if (category.IdParent == 0)
            {
                model = cyberDB.Categories.Where(x => x.IdParent == category.Id).ToList();
            }
            else //Check get all parent's subcategories
            {
                model = cyberDB.Categories.Where(x => x.IdParent == category.IdParent).ToList();
            }

            return PartialView(model);
        }
	}
}