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
        public Models.OrderService service = new Models.OrderService();
        public ActionResult Index()
        {
            //orderService.InsertOrder(new Models.Order() { CustId = "001", CustName = "叡揚資訊", EmpId = 1, EmpName = "王小明", OrderDate = DateTime.Parse("2015/11/08") });
            ViewBag.order=service.GetOrderByCondtioin();
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
            ViewBag.order = o;
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
            ViewBag.order = service.GetOrderByCondtioin();
            return this.Json(service.GetOrderById(id.ToString()), JsonRequestBehavior.AllowGet);
        }

    }
}
