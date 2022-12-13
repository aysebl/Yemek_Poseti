using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yemek_Poşeti.Models;
using Dapper;


namespace Yemek_Poşeti.Controllers
{
    public class StockController : Controller
    {

        // GET: Stock
        public ActionResult StockListele()
        {
            return View(DP.ReturnList<StockModel>("StockListele"));
        }
        public ActionResult StockEY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StockID", id);
                return View(DP.ReturnList<StockModel>("StockSirala", param).FirstOrDefault<StockModel>());
            }


        }
        [HttpPost]
        public ActionResult StockEY(StockModel stock)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@StockID", stock.StockID);
            param.Add("@ProductID", stock.ProductID);
            param.Add("@ProductAmount", stock.ProductAmount);

            DP.EXReturn("StockEY", param);
            return RedirectToAction("StocListele");

        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@StockID", id);
            DP.EXReturn("StockSil", param);
            return RedirectToAction("StocListele");
        }

    }
}

  
