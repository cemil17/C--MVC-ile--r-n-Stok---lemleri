using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCStock.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStockEntities entities = new MvcDbStockEntities();
        public ActionResult Index(int number = 1)
        {
            var values = entities.TBL_Customers.ToList().ToPagedList(number, 5);

            return View(values);
        }


        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(TBL_Customers p1)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }
            entities.TBL_Customers.Add(p1);
            entities.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var customer = entities.TBL_Customers.Find(id);
            entities.TBL_Customers.Remove(customer);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerBring(int id)
        {
            var bring = entities.TBL_Customers.Find(id);
            return View("CustomerBring", bring);
        }

        public ActionResult UpdateCustomer(TBL_Customers p1)
        {
            var update = entities.TBL_Customers.Find(p1.Customer_Id);
            update.Name = p1.Name;
            update.Surname = p1.Surname;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}