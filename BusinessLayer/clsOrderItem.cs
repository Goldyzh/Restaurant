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


        public clsOrder Order;

        public clsOrderItems()

        {
            this.ID = -1;
            this.OrderID = -1;
            this.ItemID = -1;

            Mode = enMode.AddNew;

        }

        private clsOrderItems(int ID, int OrderID ,int ItemID)

        {
            this.ID = ID;
            this.OrderID = OrderID;
            this.ItemID = ItemID;
            Mode = enMode.Update;
        }

        private bool _AddNewOrder()
        {
            //call DataAccess Layer 

            this.ID = clsOrderItemsData.AddNewOrderItems(
                this.OrderID, this.ItemID);

            return (this.ID != -1);
        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsOrderItemsData.UpdateOrderItems(this.ID, this.OrderID, this.ItemID);
           
        }

        public  static clsOrderItems FindBaseOrder(int ID)
        {
            int OrderID=-1 ;
            int ItemID = -1;

            bool IsFound = clsOrderItemsData.GetOrderItemsInfoByID
                                (
                                    ID, ref OrderID , 
                                    ref ItemID

                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsOrderItems(ID, OrderID,
                                     ItemID);
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
