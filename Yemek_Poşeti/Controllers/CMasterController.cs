using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yemek_Poşeti.Models;
using Dapper;


namespace Yemek_Poşeti.Controllers
{
    public class CMasterController : Controller
    {
       
        
            // GET: CMaster
            public ActionResult AdminListele()
            {
                return View(DP.ReturnList<CMasterModel>("AdminListele"));
            }
            public ActionResult AdminEY(int id = 0)
            {
                if (id == 0)
                    return View();
                else
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@UserID", id);
                    return View(DP.ReturnList<CMasterModel>("AdminSirala", param).FirstOrDefault<CMasterModel>());
                }


            }
            [HttpPost]
            public ActionResult AdminEY(CMasterModel cMaster)
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", cMaster.UserID);
                param.Add("@Name", cMaster.Name);
                param.Add("@UserName", cMaster.UserName);
                param.Add("@UserPassword", cMaster.UserPassword);
                param.Add("@UserMail", cMaster.UserMail);
                param.Add("@UserAddress", cMaster.UserAddress);

                DP.EXReturn("AdminEY", param);
                return RedirectToAction("Index");

            }
            public ActionResult AdminDelete(int id = 0)
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", id);
                DP.EXReturn("AdminSil", param);
                return RedirectToAction("Index");
            }
        }

    
}