using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Sach
        public ActionResult Index(int? size, int? page, string sortProperty, string searchString, string sortOrder = "", int categoryID = 0)
        {


            /* ViewBag.Keyword = searchString;
             ViewBag.Subject = categoryID;
             var E_sach = data.Saches.Include(s => s.Sach).Include(s => s.Category);

             if(!String.IsNullOrEmpty(searchString))
                Sach = Sach.Where(b => b.Title.Contains(searchString));*/


             if (page == null) page = 1;
             var all_sach = (from s in data.Saches select s).OrderBy(m => m.masach);
             int pageSize = 3;
             int pageNum = page ?? 1;
             return View(all_sach.ToPagedList(pageNum, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}