using Restaurant_Buisness;
using Restaurant_DataAccess;
using System;
using System.Data;


namespace Restaurant_Buisness
{
    public class clsOrder
    {
        public enum enMode { AddNew = 0, Update = 1 };


        public enMode Mode = enMode.AddNew;

        public int OrderID { set; get; }

        public DateTime OrderDate { set; get; }

        public decimal TotalPrice { set; get; }

        public string Status  { set; get; }

        public string Notes { set; get; }

        public int CreatedBy { set; get; }

        public string OrderName { set; get; }



        public clsUser CreatedByUserInfo;

        public clsOrder()

        {
            this.OrderID = -1;
            this.OrderDate = DateTime.Now;
            this.TotalPrice = -1;
            this.Status = "";
            this.Notes = "";
            this.CreatedBy = -1;
            this.OrderName = "";


            Mode = enMode.AddNew;

        }

        private clsOrder(int OrderID, DateTime OrderDate ,decimal TotalPrice
            , string Status, string Notes, int CreatedBy , string OrderName)

        {
            this.OrderID = OrderID;
            this.OrderDate = OrderDate;
            this.TotalPrice = TotalPrice;
            this.Status = Status;
            this.Notes = Notes;
            this.CreatedBy = CreatedBy;
            this.OrderName = OrderName;
            Mode = enMode.Update;
        }

        private bool _AddNewOrder()
        {
            //call DataAccess Layer 

            this.OrderID = clsOrderData.AddNewOrder(
                this.OrderDate, this.TotalPrice,
                this.Status, this.Notes,
                this.CreatedBy , this.OrderName);

            return (this.OrderID != -1);
        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsOrderData.UpdateOrder(this.OrderID, this.OrderDate, this.TotalPrice,
                this.Status, this.Notes,
                this.CreatedBy ,this.OrderName );
           
        }

        public  static clsOrder FindBaseOrder(int OrderID)
        {
            decimal TotalPrice =-1;
            DateTime OrderDate=DateTime.Now ;  string Status = "" , Notes = "" , OrderName = "";
            int CreatedBy = -1;

            bool IsFound = clsOrderData.GetOrderInfoByID
                                (
                                    OrderID, ref OrderDate , 
                                    ref TotalPrice, ref Status,
                                    ref Notes, ref CreatedBy , ref OrderName

                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsOrder(OrderID, OrderDate,
                                     TotalPrice,  Status,
                                     Notes,  CreatedBy , OrderName);
            else
                return null;
        }

        public bool Cancel()
        {
            string NewStatus = "Cancelled";
            return clsOrderData.UpdateStatus (OrderID, NewStatus);
        }

        public bool SetComplete()
        {
            string NewStatus = "Finished";

            return clsOrderData.UpdateStatus(OrderID, NewStatus);
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

        public static bool DeleteOrder(int OrderID)
        {
            return clsOrderData.DeleteOrder(OrderID); 
        }

        public static bool IsApplicationExist(int OrderID)
        {
           return clsOrderData.IsOrderExist(OrderID);
        }

        public static DataTable GetPendingOrders()
        {
            return clsOrderData.GetPendingOrders();
        }



        public static DataTable GetFinishedOrders()
        {
            return clsOrderData.GetFinishedOrders();
        }


    }
}
