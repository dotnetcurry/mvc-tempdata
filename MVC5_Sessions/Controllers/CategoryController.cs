using System.Linq;
using System.Web.Mvc;

using MVC5_Sessions.Models;

namespace MVC5_Sessions.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
    public class CategoryController : Controller
    {
        ApplicationEntities ctx;

        public CategoryController()
        {
            ctx = new ApplicationEntities();
        }

        // GET: Category
        public ActionResult Index()
        {
            var cats = ctx.Categories.ToList();
            return View(cats);
        }

        public ActionResult SearchProducts()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SearchProducts(Category c)
        {
           TempData["Category"] = c;
        //   Session["Category"] = c;
            return  RedirectToAction("Index","Product");
        }
    }
}