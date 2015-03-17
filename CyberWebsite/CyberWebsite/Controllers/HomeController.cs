using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberWebsite.Models;

namespace CyberWebsite.Controllers
{
    public class HomeController : Controller
    {
        CyberWebsiteEntities cyberDB = new CyberWebsiteEntities();
        public ActionResult Index()
        {
            //gets the four topcategories
            IList<Categories> model = cyberDB.Categories.Where(x => x.IdParent == 0).ToList();

            return View(model);
        }

        public ActionResult About()
        {

            return View();
        }

    }
}