using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eSalex.Models
{
    public class OrderService
    {
        public List<Models.Order> result =new List<Order>();
        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="order"></param>
        public void InsertOrder(Models.Order order)
        {
            //todo
            /*Models.Order o = new Models.Order();
            o.CustId = "1103137114";
            o.CustName = "資訊管理系";
            o.EmpId = 1103137114;
            o.EmpName = "詹育軒";
            o.OrderDate = DateTime.Parse("2017/03/10");*/
            result.Add(order);
        }
        /// <summary>
        /// 依照Id 取得訂單資料
        /// </summary>
        /// <returns></returns>
        public Models.Order GetOrderById(string orderId)
        {
            //todo
            Models.Order o = new Order();
           

            return o;
        }
        /// <summary>
        /// 依照條件取得訂單資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Order> GetOrderByCondtioin()
        {
            //todo
            result.Add(new Order() {CustId = "001", CustName = "叡揚資訊", EmpId = 1, EmpName = "王小明", OrderDate = DateTime.Parse("2015/11/08") });
            result.Add(new Order() {CustId = "002", CustName = "網軟資訊", EmpId = 2, EmpName = "李小華", OrderDate = DateTime.Parse("2015/11/01") });
            return result;
        }
        /// <summary>
        /// 刪除訂單
        /// </summary>
        public void DeleteOrderById(string orderId)
        {
            //todo
        }
        /// <summary>
        /// 更新訂單
        /// </summary>
        public void UpdateOrder(Models.Order order)
        {
            //todo
        }

    }
}