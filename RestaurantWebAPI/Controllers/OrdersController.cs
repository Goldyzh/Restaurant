using Microsoft.AspNetCore.Mvc;
using Restaurant_DataAccess; // check spelling: should be "Business"
using RestaurantWebAPI.DTOs;
using System.Data;

namespace RestaurantWebAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        // GET: api/orders
        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                DataTable dt = clsOrderData.GetOrdersForOrdersScreen();
                Console.WriteLine("dtdtdtdtdtdtdtdt");
                Console.WriteLine(dt);
                Console.WriteLine("dtdtdtdtdtdtdtdt");

                if (dt == null || dt.Rows.Count == 0)
                    return Ok(new List<OrderDto>()); // return empty list if no data

                var orders = new List<OrderDto>();

                foreach (DataRow row in dt.Rows)
                {
                    orders.Add(new OrderDto
                    {
                        OrderID = row["OrderID"] != DBNull.Value ? Convert.ToInt32(row["OrderID"]) : 0,
                        OrderDate = row["OrderDate"] != DBNull.Value ? Convert.ToDateTime(row["OrderDate"]) : (DateTime?)null,
                        TotalPrice = row["TotalPrice"] != DBNull.Value ? Convert.ToDecimal(row["TotalPrice"]) : (decimal?)null,
                        Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : null,
                        Notes = row["Notes"] != DBNull.Value ? row["Notes"].ToString() : null,
                        CreatedBy = row["CreatedBy"] != DBNull.Value ? Convert.ToInt32(row["CreatedBy"]) : (int?)null,
                        OrderName = row["OrderName"] != DBNull.Value ? row["OrderName"].ToString() : null
                    });
                }

                Console.WriteLine("orders[0]");
                Console.WriteLine(orders[0]);
                Console.WriteLine("orders[0]");
                return Ok(orders);
            }
            catch (Exception ex)
            {
                // Log ex.Message if you have a logger
                return StatusCode(500, new { message = "An error occurred while fetching orders.", detail = ex.Message });
            }
        }
    }
}