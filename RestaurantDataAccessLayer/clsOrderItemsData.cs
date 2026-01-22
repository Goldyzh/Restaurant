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
    public class clsOrderItemsData
    {
        

        public static bool GetOrderItemsInfoByID(int ID, ref int OrderID, ref int ItemID, ref int Quantity, ref decimal Price)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = "SELECT * FROM OrderItems WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ID", ID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        // The record was found
                        isFound = true;

                        ID = (int)reader["ID"];
                        OrderID = (int)reader["OrderID"];
                        ItemID = (int)reader["ItemID"];
                        Quantity = (int)reader["Quantity"];
                        Price = (decimal)reader["Price"];

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

        public static DataTable GetOrderItems(int OrderID)
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //string query = "SELECT * FROM OrderItems Order BY ID DESC";
            //string query = "SELECT * FROM OrderItems Order BY ID";

            string query = @"SELECT 
                 OrderItems.ID,
                 OrderItems.OrderID,
                 OrderItems.ItemID,
                 Items.ItemName,
                 OrderItems.Quantity,
                 OrderItems.Price
                                  FROM OrderItems
                  INNER JOIN Items
                                   ON OrderItems.ItemID = Items.ItemID
                  where OrderItems.OrderID = @OrderID
                  ORDER BY OrderItems.ID;";
                                  




           

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID", OrderID);


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
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return dt;

            }





        public static int AddNewOrderItems(int OrderID,  int ItemID, int Quantity, decimal Price)
        {

            //this function will return the new person id if succeeded and -1 if not.
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO OrderItems ( 
                            OrderID,ItemID ,Quantity, Price)
                             VALUES (@OrderID,@ItemID,@Quantity ,@Price);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("OrderID", @OrderID);
            command.Parameters.AddWithValue("ItemID", @ItemID);
            command.Parameters.AddWithValue("Quantity", Quantity);
            command.Parameters.AddWithValue("Price", Price);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error in AddNewOrderItems---------------------: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return ID;
        }


        public static bool UpdateOrderItems(int ID, int OrderID, int ItemID, int Quantity, decimal Price)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  OrderItems  
                            set OrderID = @OrderID,
                                ItemID = @ItemID,
                                Quantity = @Quantity,
                                Price = @Price

                            where ID=@ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("OrderID", OrderID);
            command.Parameters.AddWithValue("ItemID", ItemID);
            command.Parameters.AddWithValue("Quantity", Quantity);
            command.Parameters.AddWithValue("Price", Price);




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

        public static bool DeleteOrderItems(int ID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete OrderItems 
                                where ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

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

        public static bool IsOrderItemsExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM OrderItems WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

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

  

     

      
      

    }
}
