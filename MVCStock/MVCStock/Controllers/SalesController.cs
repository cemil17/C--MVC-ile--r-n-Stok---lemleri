using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;

namespace MVCStock.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        MvcDbStockEntities entities = new MvcDbStockEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewSales()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSales(TBL_Sales p)
        {
            entities.TBL_Sales.Add(p);
            entities.SaveChanges();
            return View("Index");
        }
    }
}