using System.Linq;
using System.Web.Mvc;
using MVC5_Sessions.Models;

namespace MVC5_Sessions.Controllers
{
    public class ProductController : Controller
    {

        ApplicationEntities ctx;
        public ProductController()
        {
            ctx = new ApplicationEntities(); 
        }

        // GET: Product
        /// <summary>
        /// Type Case the TempData to Category
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (TempData["Category"] != null)
        //    if (Session["Category"] != null)
            {
                var Cat = (Category)TempData["Category"];
               // var Cat = (Category)Session["Category"];

                var Products = from p in ctx.Products
                               where p.CategoryId == Cat.CategoryId
                               select p;

                TempData.Keep("Category");

                return View(Products.ToList());
            }
            else
            {
                return View(ctx.Products.ToList());
            }
        }
        //  var Data = Session["Category"] as Category;
        [HttpPost]
        public ActionResult Index(int id=0) 
        {
            var Data = TempData["Category"] as Category;
         

            return RedirectToAction("Index");
        }
    }
}