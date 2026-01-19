using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace Restaurant_DataAccess
{
    public class clsItemsData
    {

        public static bool GetPersonInfoByID(int ItemID, ref string ItemName, ref decimal Price, ref string Description, ref string ImagePath,
          ref bool IsAvailable, ref DateTime CreatedAt, ref int CategoryID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Items WHERE ItemID = @ItemID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ItemID", ItemID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    ItemName = (string)reader["ItemName"];
                    Price = (decimal)reader["Price"];



 
                    CreatedAt = (DateTime)reader["CreatedAt"];

                    Description = (string)reader["Description"];
                  

                    CategoryID = (int)reader["CategoryID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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




        public static int AddNewItem( string ItemName,  decimal Price, string Description,  string ImagePath,
           bool IsAvailable,  DateTime CreatedAt,  int CategoryID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int ItemID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Items (ItemName, Price,Description
           ,ImagePath
           ,IsAvailable
           ,CreatedAt
           ,CategoryID)
                             VALUES (@ItemName, @Price,@Description
           ,@ImagePath
           ,@IsAvailable
           ,@CreatedAt
           ,@CategoryID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ItemName", ItemName);
            command.Parameters.AddWithValue("@Price", Price);




            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
   
            command.Parameters.AddWithValue("@Description", Description);
        

            command.Parameters.AddWithValue("@CategoryID", CategoryID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            command.Parameters.AddWithValue("@IsAvailable", IsAvailable);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ItemID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error:------------------------------ " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return ItemID;
        }

   
        public static bool UpdateItem(int ItemID,  string ItemName,  decimal Price,  string Description,  string ImagePath,
           bool IsAvailable,  DateTime CreatedAt,  int CategoryID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Items  
                            set ItemName = @ItemName,
                                Price = @Price,
                                Description = @Description,
                                ImagePath = @ImagePath, 
                                IsAvailable = @IsAvailable,
                                CreatedAt = @CreatedAt,
                                CategoryID = @CategoryID,
                                ImagePath =@ImagePath
                                where ItemID = @ItemID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ItemID", ItemID);
            command.Parameters.AddWithValue("@ItemName", ItemName);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@CategoryID", CategoryID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


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


        public static DataTable GetAllItems()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =
              @"SELECT Items.ItemID, Items.ItemName,
              Items.Price, Items.Price, Items.Description, Items.ImagePath,
			  Items.IsAvailable,
			  Items.CreatedAt, Items.CategoryID
              FROM            Items INNER JOIN
                         Categories ON Items.CategoryID = Categories.CategoryID
              ORDER BY Items.CategoryID";




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

        public static bool DeleteItem(int ItemID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Items 
                                where ItemID = @ItemID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ItemID", ItemID);

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

        public static bool isItemExist(int ItemID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Items WHERE ItemID = @ItemID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ItemID", ItemID);

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
