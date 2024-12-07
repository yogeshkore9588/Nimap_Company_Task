using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Nimap_Company_Task.Models;
using Nimap_Company_Task.Models.Validations;

namespace Nimap_Company_Task.Controllers
{
    public class ProductController : Controller
    {
        private NimapCompanyEntities dbo = new NimapCompanyEntities();
        // GET: Product
        public ActionResult Index()
        {
            List<tblProduct> products = dbo.tblProducts.ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblProduct tp)
        {
            if (ModelState.IsValid)
            {
                tblProduct temp = new tblProduct();
                temp.ProductID = tp.ProductID;
                temp.ProductName = tp.ProductName;
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int ProductID)
        {
            var tp = dbo.tblProducts.Find(ProductID);
            ProductValidationClass pvc = new ProductValidationClass();
            pvc.ProductID = ProductID;
            pvc.ProductName = tp.ProductName;
            return View(pvc);
        }
        [HttpPost]
        public ActionResult Edit(ProductValidationClass pvc)
        {
            if (ModelState.IsValid)
            {
                var tp = dbo.tblProducts.FirstOrDefault(x => x.ProductID == pvc.ProductID);

                pvc.ProductName = tp.ProductName;
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int ProductID)
        {
            var tp = dbo.tblProducts.SingleOrDefault(x => x.ProductID == ProductID);
            if (tp != null)
            {
                dbo.tblProducts.Remove(tp);
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Select(int ProductID)
        {
            tblProduct tp = dbo.tblProducts.Find(ProductID);
            return View();
        }
    }
}