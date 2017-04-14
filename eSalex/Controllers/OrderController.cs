using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eSalex.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            Models.OrderService service = new Models.OrderService();
            ViewBag.order = service.GetOrderById("10250");
            return View();//
        }

        [HttpGet()]
        public ActionResult InsertOrder()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult InsertOrder(Models.Order o)
        {
            Models.OrderService service = new Models.OrderService();
            service.InsertOrder(o);
            if (ModelState.IsValid)
            {
                ViewBag.Hello = "vb welcome";
                TempData["Hello"] = "td welcome";
                return RedirectToAction("index");
            }
            return View(o);
        }

        public JsonResult showJsonResult(int id)
    {
            Models.OrderService service = new Models.OrderService();
            ViewBag.order = service.GetOrderByCondtioin();
            return this.Json(service.GetOrderById(id.ToString()), JsonRequestBehavior.AllowGet);
        }

    }
}
