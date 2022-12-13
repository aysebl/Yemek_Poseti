using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yemek_Poşeti.Models;
using Dapper;

namespace Yemek_Poşeti.Controllers
{
    public class UserProductController : Controller
    {
        // GET: UserProduct
        public ActionResult UPListele()
        {
            return View(DP.ReturnList<ProductModel>("ProductListele"));
        }
    }
}