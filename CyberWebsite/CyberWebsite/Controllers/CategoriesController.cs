using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CyberWebsite.Models;

namespace CyberWebsite.Controllers
{
    public class CategoriesController : Controller
    {
        CyberWebsiteEntities cyberDB = new CyberWebsiteEntities();
        public ActionResult Index()
        {
            IList<Categories> model = cyberDB.Categories.ToList();

            return View(model);
        }

        public ActionResult Edit(int id)
        {

            Models.Categories model = cyberDB.Categories.First(x => x.Id == id);

            return View(model);

        }
        [HttpPost]
        public ActionResult Edit(Categories model)
        {

            cyberDB.Categories.AddOrUpdate(model);
            cyberDB.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Create()
        {
            Categories model = new Categories();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Categories model)
        {
            cyberDB.Categories.Add(model);
            cyberDB.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Models.Categories model = cyberDB.Categories.First(x => x.Id == id);

            cyberDB.Categories.Remove(model);
            cyberDB.SaveChanges();

            return RedirectToAction("Index");

        }

        public PartialViewResult _CategoryList(int id)
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