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
    public class RegisterController : Controller
    {
        // GET: Register


        public ActionResult YeniUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUser(Customer ekle)
        {
            try
            {
                using (YemekPosetiEntities db = new YemekPosetiEntities())
                {
                    db.Customers.Add(ekle);
                    db.SaveChanges();
                }
                return RedirectToAction("Home", "Yonetici");
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}