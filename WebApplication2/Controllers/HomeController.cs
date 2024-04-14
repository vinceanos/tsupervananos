using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult NotAuthorized()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        [Authorize]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the user to the database
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Login(User model, string returnUrl)
        {
            tsupervanEntities db = new tsupervanEntities();
            var query = db.User.Where(m => m.Username == model.Username && m.Password == model.Password);
            if (query.Any())
            {
                var dataItem = query.First();
                FormsAuthentication.SetAuthCookie(dataItem.Username, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") & !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();

            }

        }
    }
    }

