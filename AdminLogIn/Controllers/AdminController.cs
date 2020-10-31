using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLogIn.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            DataAccess data = new DataAccess();
            ModelState.Clear();
            return View(data.GetUser());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}