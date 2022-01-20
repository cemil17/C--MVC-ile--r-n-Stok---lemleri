using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entity;
using PagedList.Mvc;
using PagedList;

namespace MVCStock.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        MvcDbStockEntities stockEntities = new MvcDbStockEntities();
        public ActionResult Index(int number =1)
        {
            var values = stockEntities.TBL_Category.ToList().ToPagedList(number, 4);             

            return View(values);
        }
        [HttpGet] // eğer sayfa da bir işlem yapılmazsa bu çalışır
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]  // Eğer sayfada bir post işlemi yapıldıysa bu çalışır örneğin butona basmak gibi
        public ActionResult New(TBL_Category p1)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }
            stockEntities.TBL_Category.Add(p1);
            stockEntities.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var category = stockEntities.TBL_Category.Find(id);
            stockEntities.TBL_Category.Remove(category);
            stockEntities.SaveChanges();
            return RedirectToAction("Index");
        }

   
        public ActionResult CategoryBring(int id)
        {
            var find = stockEntities.TBL_Category.Find(id);
            return View("CategoryBring", find);
        }

        public ActionResult UpdateCategory(TBL_Category p1)
        {
            var category = stockEntities.TBL_Category.Find(p1.Category_Id);
            category.Category = p1.Category;
            stockEntities.SaveChanges();
            return RedirectToAction("Index");
        }
       

    }
}