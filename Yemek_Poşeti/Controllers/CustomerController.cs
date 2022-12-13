using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yemek_Poşeti.Models;
using Dapper;



namespace Yemek_Poşeti.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustomerListele()
        {
            return View(DP.ReturnList<CustomerModel>("CustomerListele"));
        }
        public ActionResult CustomerEY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustomerID", id);
                return View(DP.ReturnList<CustomerModel>("CustomerSirala", param).FirstOrDefault<CustomerModel>());
            }


        }
        [HttpPost]
        public ActionResult CustomerEY(CustomerModel Customer)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerID", Customer.CustomerID);
            param.Add("@CName", Customer.CName);
            param.Add("@CUserName", Customer.CUserName);
            param.Add("@CUserPassword", Customer.CUserPassword);
            param.Add("@CUserMail", Customer.CUserMail);
            param.Add("@CUserAddress", Customer.CUserAddress);
            DP.EXReturn("CustomerEY", param);
            return RedirectToAction("CustomerListele");

        }
        public ActionResult CustomerDelete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerID", id);
            DP.EXReturn("CustomerSil", param);
            return RedirectToAction("CustomerListele");
        }

    }
   
}
