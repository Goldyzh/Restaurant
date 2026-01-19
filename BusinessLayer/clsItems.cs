using System;
using System.Data;
using System.Xml.Linq;
using Restaurant_DataAccess;



namespace Restaurant_Buisness
{
    public  class clsItems
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ItemID { set; get; }
        public string ItemName { set; get; }
        public decimal Price { set; get; }
        public string Description { set; get; }

        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public bool IsAvailable { set; get; }

        public DateTime CreatedAt { set; get; }

        public int CategoryID { set; get; }

        public clsItems()

        {
            this.ItemID = -1;
            this.ItemName = "";
            this.Price = 0;
            this.Description = "";
            this.ImagePath = "";
            this.IsAvailable = false;
            this.CreatedAt = DateTime.Now;
            this.CategoryID = -1;

            Mode = enMode.AddNew;
        }

        private clsItems(int ItemID,  string ItemName,  decimal Price,  string Description,  string ImagePath,
           bool IsAvailable,  DateTime CreatedAt,  int CategoryID)

        {
            this.ItemID = ItemID;
            this.ItemName = ItemName;
            this.Price = Price;
            this.Description = Description;
            this.ImagePath = ImagePath;
            this.IsAvailable = IsAvailable;
            this.CreatedAt = CreatedAt;
            this.CategoryID = CategoryID;
            Mode = enMode.Update;
        }

        private bool _AddNewItem()
        {
            //call DataAccess Layer 

            this.ItemID = clsItemsData.AddNewItem(
            this.ItemName, this.Price, this.Description, this.ImagePath, this.IsAvailable, this.CreatedAt, this.CategoryID);

            return (this.ItemID != -1);
        }

        private bool _UpdateItem()
        {
            //call DataAccess Layer 

            return clsItemsData.UpdateItem(
                this.ItemID, this.ItemName, this.Price, this.Description, this.ImagePath, this.IsAvailable, this.CreatedAt, this.CategoryID);
        }

        public static clsItems Find(int ItemID)
        {

            string ItemName = "", Description = "", ImagePath = "";
            DateTime CreatedAt = DateTime.Now;
            decimal Price = -1;
            int CategoryID = -1;
            bool IsAvailable = false;


            bool IsFound = clsItemsData.GetPersonInfoByID
                                (ItemID, ref  ItemName, ref  Price, ref  Description, ref  ImagePath,
          ref  IsAvailable, ref  CreatedAt, ref  CategoryID);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsItems(ItemID,  ItemName,  Price,  Description,  ImagePath,
           IsAvailable,  CreatedAt,  CategoryID);
            else
                return null;
        }

       

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewItem())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateItem();

            }

            return false;
        }

        public static DataTable GetAllItems()
        {
            return clsItemsData.GetAllItems();
        }

        public static bool DeleteItem(int ID)
        {
            return clsItemsData.DeleteItem(ID); 
        }

        public static bool isItemExist(int ID)
        {
           return clsItemsData.isItemExist(ID);
        }


    }
}
