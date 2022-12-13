using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yemek_Poşeti.Models;
using Dapper;


namespace Yemek_Poşeti.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult OrderListele()
        {
            return View(DP.ReturnList<OrderModel>("OrderListele"));
        }
        public ActionResult OrderEY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@OrderID", id);
                return View(DP.ReturnList<OrderModel>("OrderSirala", param).FirstOrDefault<OrderModel>());
            }


        }
        [HttpPost]
        public ActionResult OrderEY(OrderModel order)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrderID", order.OrderID);
            param.Add("@CustomerID", order.CustomerID);
            param.Add("@OrderDate", order.OrderDate);
            param.Add("@OrderAddress", order.OrderAddress);
            param.Add("@OrderPrice", order.OrderPrice);
            param.Add("@ProductID", order.ProductID);
            DP.EXReturn("OrderEY", param);
            return RedirectToAction("OrderListele");

        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrderID", id);
            DP.EXReturn("OrderSil", param);
            return RedirectToAction("OrderListele");
        }
    }
}
