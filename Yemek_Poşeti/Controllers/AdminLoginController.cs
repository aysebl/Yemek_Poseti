using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Yemek_Poşeti.Models;
using Microsoft.SqlServer.Server;


namespace Yemek_Poşeti.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(AdminLogin user)
        {
            using (YemekPosetiEntities db = new YemekPosetiEntities())
            {
                var result = db.CMasters.Where(x => x.UserName == user.Username && x.UserPassword == user.Password1);
                if (result.Count() != 0)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    //session["userıd]= user.username;
                    return RedirectToAction("Home", "AYönetici");
                }
                else
                {
                    TempData["msg"] = "hatalı";
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return View("Login");
        }


    }
}