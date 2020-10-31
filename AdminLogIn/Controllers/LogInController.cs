using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminLogIn.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            UserController uc = new UserController();
            if (ModelState.IsValid && uc.UserExists(model) && uc.PasswordValid(model))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return View("Dashboard");
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
    }
}