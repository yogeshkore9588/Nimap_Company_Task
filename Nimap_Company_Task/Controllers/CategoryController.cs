using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Nimap_Company_Task.Models;

namespace Nimap_Company_Task.Controllers
{
    public class CategoryController : Controller
    {
        private NimapCompanyEntities dbo = new NimapCompanyEntities();
        // GET: Category
        public ActionResult Index()
        {
            List<tblCategory> catlist = dbo.tblCategories.ToList();
            return View(catlist);
        }
        public ActionResult Delete(int CategoryID)
        {
            tblCategory cat = dbo.tblCategories.SingleOrDefault(x => x.CategoryID == CategoryID);
            if (cat != null)
            {
                dbo.tblCategories.Remove(cat);
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int CategoryID)
        {
            tblCategory tc = dbo.tblCategories.FirstOrDefault(x=>x.CategoryID == CategoryID);
            if (tc == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(tc);
            }
        }
        [HttpPost]
        public ActionResult Edit(tblCategory tc)
        {
            if (ModelState.IsValid)
            {
                tblCategory oldtc = dbo.tblCategories.FirstOrDefault(x => x.CategoryID == tc.CategoryID);
                oldtc.CategoryID = tc.CategoryID;
                oldtc.CategoryName = tc.CategoryName;
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}