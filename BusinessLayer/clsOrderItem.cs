using Restaurant_Buisness;
using Restaurant_DataAccess;
using System;
using System.Data;


namespace Restaurant_Buisness
{
    public class clsOrderItems
    {
        public enum enMode { AddNew = 0, Update = 1 };


        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }

        public int OrderID { set; get; }

        public int ItemID { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }


        public clsOrder Order;

        public clsOrderItems()

        {
            this.ID = -1;
            this.OrderID = -1;
            this.ItemID = -1;
            this.Quantity = -1;
            this.Price = -1;

            Mode = enMode.AddNew;

        }

        private clsOrderItems(int ID, int OrderID ,int ItemID , int Quantity, decimal Price)

        {
            this.ID = ID;
            this.OrderID = OrderID;
            this.ItemID = ItemID;
            this.Quantity = Quantity;
            this.Price = Price;
            Mode = enMode.Update;
        }

        private bool _AddNewOrder()
        {
            //call DataAccess Layer 

            this.ID = clsOrderItemsData.AddNewOrderItems(
                this.OrderID, this.ItemID, this.Quantity, this.Price);

            return (this.ID != -1);
        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsOrderItemsData.UpdateOrderItems(this.ID, this.OrderID, this.ItemID, this.Quantity, this.Price);
           
        }

        public  static clsOrderItems FindBaseOrder(int ID)
        {
            int OrderID=-1 ;
            int ItemID = -1;
            int Quantity = -1 ;
            decimal Price = -1 ;

            bool IsFound = clsOrderItemsData.GetOrderItemsInfoByID
                                (
                                    ID, ref OrderID , 
                                    ref ItemID ,
                                     ref Quantity,
                                    ref Price


                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsOrderItems(ID, OrderID,
                                     ItemID, Quantity, Price);
            else
                return null;
        }

   


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrder())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }

            return false;
        }

        public  bool Delete()
        {
            return clsOrderItemsData.DeleteOrderItems(this.ID); 
        }

        public static bool IsApplicationExist(int ID)
        {
           return clsOrderItemsData.IsOrderItemsExist(ID);
        }

        public static DataTable GetOrderItems()
        {
            return clsOrderItemsData.GetOrderItems();
        }




    }
}
