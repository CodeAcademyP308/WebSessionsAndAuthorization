using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSessions.Models.Entity;

namespace WebSessions.Controllers
{
    [VizewAuthorization]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //if (Session[SessionKey.User] == null)
            //{
            //    return RedirectToAction("Login");
            //}

            if (Session["date"] == null)
            {
                Session["date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return View("IndexX");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            if (user.Email=="test@mail.ru" && user.Password=="12345")
            {
                Session[SessionKey.User] = user;
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("login");
        }
    }
}