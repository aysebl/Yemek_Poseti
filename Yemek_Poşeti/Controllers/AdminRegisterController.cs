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
    public class AdminRegisterController : Controller
    {
        // GET: AdminRegister
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(CMaster ekle)
        {
            try
            {
                using (YemekPosetiEntities db = new YemekPosetiEntities())
                {
                    db.CMasters.Add(ekle);
                    db.SaveChanges();
                }
                return RedirectToAction("Home", "AYönetici");
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}