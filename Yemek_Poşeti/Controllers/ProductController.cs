using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yemek_Poşeti.Models;
using Dapper;

namespace Yemek_Poşeti.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
        public ActionResult ProductListele()
        {
            return View(DP.ReturnList<ProductModel>("ProductListele"));
        }
        public ActionResult ProductEY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ProductID", id);
                return View(DP.ReturnList<ProductModel>("ProductSirala", param).FirstOrDefault<ProductModel>());
            }


        }
        [HttpPost]
        public ActionResult ProductEY(ProductModel product)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductID", product.ProductID);
            param.Add("@ProductName", product.ProductName);
            param.Add("@Type", product.Type);
            param.Add("@Price", product.Price);
            param.Add("@Number", product.Number);
            DP.EXReturn("ProductEY", param);
            return RedirectToAction("ProductListele");

        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductID", id);
            DP.EXReturn("ProductSil", param);
            return RedirectToAction("ProductListele");
        }
    }
}