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
            Models.OrderService orderService= new Models.OrderService();
            //orderService.InsertOrder(new Models.Order() { CustId = "001", CustName = "叡揚資訊", EmpId = 1, EmpName = "王小明", OrderDate = DateTime.Parse("2015/11/08") });
            ViewBag.order=orderService.GetOrderByCondtioin();
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
            Models.OrderService os = new Models.OrderService();
            ViewBag.order = o;

            Models.OrderService service = new Models.OrderService();
            return View("index");
        }

        public JsonResult showJsonResult(int id)
        {
            Models.OrderService service = new Models.OrderService();
            ViewBag.order = service.GetOrderByCondtioin();
            return this.Json(service.GetOrderById(id.ToString()), JsonRequestBehavior.AllowGet);
        }

    }
}
