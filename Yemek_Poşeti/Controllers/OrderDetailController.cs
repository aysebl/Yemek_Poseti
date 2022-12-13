using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yemek_Poşeti.Models;
using Dapper;

namespace Yemek_Poşeti.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: Personel
        public ActionResult OrderDetailListele()
        {
            return View(DP.ReturnList<OrderDetailModel>("OrderDetailListele"));
        }
        public ActionResult OrderDetailEY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@OrderDetailID", id);
                return View(DP.ReturnList<OrderDetailModel>("OrderDetailSirala", param).FirstOrDefault<OrderDetailModel>());
            }


        }
        [HttpPost]
        public ActionResult OrderDetailEY(OrderDetailModel detail)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrderDetailID", detail.OrderDetailID);
            param.Add("@ProductID", detail.ProductID);
            param.Add("@Introduction", detail.Introduction);
            DP.EXReturn("OrderDetailEY", param);
            return RedirectToAction("OrderDetailListele");

        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrderDetailID", id);
            DP.EXReturn("OrderDetailSil", param);
            return RedirectToAction("OrderDetailLİstele");
        }
    }
}