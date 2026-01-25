using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Restaurant_DataAccess
{
    public class clsOrderData
    {
      

        public static bool GetOrderInfoByID(int OrderID, ref DateTime OrderDate, ref decimal TotalPrice, 
            ref string Status, ref string Notes, ref int CreatedBy , ref string OrderName)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = "SELECT * FROM Orders WHERE OrderID = @OrderID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@OrderID", OrderID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        // The record was found
                        isFound = true;

                        OrderID = (int)reader["OrderID"];
                        OrderDate = (DateTime) reader["OrderDate"];
                        TotalPrice = (decimal)reader["TotalPrice"];
                        Status = (string)reader["Status"];
                        Notes = (string)reader["Notes"];
                        CreatedBy = (int)reader["CreatedBy"];
                        OrderName = (string)reader["OrderName"];


                }
                else
                    {
                        // The record was not found
                        isFound = false;
                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }

        public static DataTable GetOrdersForOrdersScreen()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
                  string query = "SELECT * FROM View_OrdersForOrdersScreen WHERE Status = 'Pending' or Status = 'InProgress' or Status = 'Ready' ORDER BY  OrderID DESC";



            SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)

                    {
                        dt.Load(reader);
                    }

                    reader.Close();


                }

                catch (Exception ex)
                {
                    // Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return dt;

            }

        public static DataTable GetFinishedOrders()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM View_OrdersForOrdersScreen WHERE Status = 'Cancelled' or Status = 'Finished' ORDER BY OrderID DESC";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetIOrdersForKitchen()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM View_OrdersForOrdersScreen WHERE Status = 'InProgress' or Status = 'Ready' ORDER BY OrderID DESC";



            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }




        public static int AddNewOrder(DateTime OrderDate,  decimal TotalPrice,
             string Status,  string Notes,  int CreatedBy , string OrderName)
        {

            //this function will return the new person id if succeeded and -1 if not.
            int OrderID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Orders ( 
                            OrderDate,TotalPrice,
                            Status,Notes,CreatedBy,
                            OrderName)
                             VALUES (@OrderDate,@TotalPrice,
                                      @Status,@Notes,
                                      @CreatedBy, @OrderName);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("OrderDate", @OrderDate);
            command.Parameters.AddWithValue("TotalPrice", @TotalPrice);
            command.Parameters.AddWithValue("Status", @Status);
            command.Parameters.AddWithValue("Notes", @Notes);
            command.Parameters.AddWithValue("CreatedBy", @CreatedBy);
            command.Parameters.AddWithValue("OrderName", OrderName);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    OrderID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: in AddNewOrder-------------------- " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return OrderID;
        }

   

        public static bool UpdateOrder(int OrderID, DateTime OrderDate, decimal TotalPrice,
             string Status, string Notes, int CreatedBy , string OrderName)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Orders  
                            set OrderDate = @OrderDate,
                                TotalPrice = @TotalPrice,
                                Status = @Status,
                                Notes = @Notes, 
                                CreatedBy = @CreatedBy,
                                OrderName=@OrderName
                            where OrderID=@OrderID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("OrderDate", OrderDate);
            command.Parameters.AddWithValue("TotalPrice", TotalPrice);
            command.Parameters.AddWithValue("Status", Status);
            command.Parameters.AddWithValue("Notes", Notes);
            command.Parameters.AddWithValue("CreatedBy", CreatedBy);
            command.Parameters.AddWithValue("OrderName", OrderName);



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteOrder(int OrderID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Orders 
                                where OrderID = @OrderID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID", OrderID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }
        
       
        public static bool IsOrderExist(int OrderID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Orders WHERE OrderID = @OrderID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID", OrderID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

  

     

      
        public static bool UpdateStatus(int OrderID, string NewStatus)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Orders  
                            set 
                                Status = @NewStatus 
                            where OrderID=@OrderID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);
            

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
