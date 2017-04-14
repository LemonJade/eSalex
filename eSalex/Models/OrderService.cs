using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            DataTable dt = new DataTable();
            String sql = @"SELECT
                           A.OrderId,A,CusId,B.Companyname As Custname,
                           A.EmpId,C.lastname+C.firstname As EmpName,
                           A.OrderData,A.RequireDdate,A.ShippedData,
                           A.ShiperId,D.companyname As ShipperName,A.Freight,
                           A.ShipName,A.ShipAddress,A.ShipCity,A.ShipRegion,A.ShipPostalCode,A.ShipCountry
                           From Sales.Order As A
                           INNER JOIN Sales.Customers As B on A.custId=B.custid
                           INNER JOIN HR.Employees As C on A.empId=C.empid
                           INNER JOIN Sales.Shippers As D on A.shipperId=B.shipperid
                           Where A.orderId=@orderId";

            using (SqlConnection conn=new SqlConnection(@"Server=MA324-45\SQLEXPRESS;DataBase=TSQL2012"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@orderId",orderId));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                conn.Close();
            }
            return this.MapOrderDataToList(dt).FirstOrDefault();
        }

        private List<Models.Order> MapOrderDataToList(DataTable dt)
        {
            List<Models.Order> result = new List<Order>();

            foreach(DataRow r in dt.Rows)
            {
                result.Add(new Order()
                {
                    CustId = r["CustId"].ToString(),
                    CustName = r["CustName"].ToString(),
                    EmpId = (int)r["EmpId"],
                    EmpName = r["EmpName"].ToString(),
                    Freight = (double)r["Freight"],
                    OrderDate = r["OrderDate"] == DBNull.Value ? (DateTime?)null : (DateTime)r["OrderDate"],
                    OrderId = (int)r["OrderId"],
                    RequiredDate = r["RequireDdate"] == DBNull.Value ? (DateTime?)null : (DateTime)r["RequireDdate"],
                    ShipAddress = r["ShipAddress"].ToString(),
                    ShipCity = r["ShipCity"].ToString(),
                    ShipCountry = r["ShipCountry"].ToString(),
                    ShipName = r["ShipName"].ToString(),
                    ShippedDate = r["ShippedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)r["ShippedDate"],
                    ShipperId = (int)r["ShipperId"],
                    ShipperName = r["ShipperName"].ToString(),
                    ShipPostalCode = r["ShipPostalCode"].ToString(),
                    ShipRegion = r["ShipRegion"].ToString()



                });
            }
            return result;
        }


        /// <summary>
        /// 依照條件取得訂單資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Order> GetOrderByCondtioin()
        {
            //todo
            //result.Add(new Order() {CustId = "001", CustName = "叡揚資訊", EmpId = 1, EmpName = "王小明", OrderDate = DateTime.Parse("2015/11/08") });
            //result.Add(new Order() {CustId = "002", CustName = "網軟資訊", EmpId = 2, EmpName = "李小華", OrderDate = DateTime.Parse("2015/11/01") });
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