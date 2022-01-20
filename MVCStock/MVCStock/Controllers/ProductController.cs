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
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStockEntities entities = new MvcDbStockEntities();
        public ActionResult Index(int number=1)
        {
            var values = entities.TBL_Products.ToList().ToPagedList(number, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult New()
        {
            List<SelectListItem> values = (from i in entities.TBL_Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Category,
                                               Value = i.Category_Id.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View();
        }

        [HttpPost]
        public ActionResult New(TBL_Products p1)
        {
            var ctg = entities.TBL_Category.Where(m => m.Category_Id == p1.TBL_Category.Category_Id).FirstOrDefault();
            p1.TBL_Category = ctg;
            entities.TBL_Products.Add(p1);
            entities.SaveChanges();
            return RedirectToAction("Index"); // kaydettikten sonra index sayfasına geri gönder
        }

        public ActionResult Delete(int id)
        {
            var product = entities.TBL_Products.Find(id);
            entities.TBL_Products.Remove(product);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductBring(int id)
        {
            var bring = entities.TBL_Products.Find(id);
            List<SelectListItem> values = (from i in entities.TBL_Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Category,
                                               Value = i.Category_Id.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View("ProductBring", bring);
        }

        public ActionResult UpdateProduct(TBL_Products p1)
        {
            var update = entities.TBL_Products.Find(p1.Product_Id);
            update.Name = p1.Name;
            update.Brand = p1.Brand;
            update.Price = p1.Price;
            update.Stock = p1.Stock;
            //update.Category = p1.Category;
            var ctg = entities.TBL_Category.Where(m => m.Category_Id == p1.TBL_Category.Category_Id).FirstOrDefault();
            update.Category = ctg.Category_Id;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}