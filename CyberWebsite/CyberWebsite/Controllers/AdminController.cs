using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberWebsite.Models;

namespace CyberWebsite.Controllers
{
    
    public class AdminController : Controller
    {
        CyberWebsiteEntities cyberDB = new CyberWebsiteEntities();
        public ActionResult Index()
        {
            return View();
        }
        //hoi
	}
}