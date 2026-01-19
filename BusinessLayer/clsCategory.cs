using System;
using System.Data;
using System.Xml.Linq;
using Restaurant_DataAccess;



namespace Restaurant_Buisness
{
    public  class clsCategory
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int CategoryID { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }

        private string _ImagePath;
      
        public string ImagePath   
        {
            get { return _ImagePath; }   
            set { _ImagePath = value; }  
        }

        public clsCategory()

        {
            this.CategoryID = -1;
            this.Name = "";
            this.Description = "";
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsCategory(int CategoryID, string Name,string Description, string ImagePath)

        {
            this.CategoryID = CategoryID;
            this.Name = Name;
            this.Description= Description;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;
        }





        private bool _AddNewCategory()
        {
            //call DataAccess Layer 

            this.CategoryID = clsCategoryData.AddNewCategory(
                this.Name,this.Description , this.ImagePath);

            return (this.CategoryID != -1);
        }

        private bool _UpdateCategory()
        {
            //call DataAccess Layer 

            return clsCategoryData.UpdateCategory(
                this.CategoryID, this.Name,this.Description, this.ImagePath);
        }


        public static clsCategory Find(string Name)
        {

            int CategoryID = -1;
            string Description = "", ImagePath = "";

            if (clsCategoryData.GetCategoryInfoByName(CategoryID, ref  Name, ref Description, ref ImagePath))

                return new clsCategory(CategoryID, Name, Description, ImagePath);
            else
                return null;

        }

        public static clsCategory Find(int CategoryID)
        {

            string Name = "", Description = "",  ImagePath = "";            

            bool IsFound = clsCategoryData.GetCategoryInfoByID 
                                (
                                    CategoryID, ref Name, ref Description, ref ImagePath
                                );

            if (IsFound)
                //we return new object of that Category with the right data
                return new clsCategory(CategoryID, Name,Description , ImagePath);
            else
                return null;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCategory())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCategory();

            }

            return false;
        }

        public static DataTable GetAllCategories()
        {
            return clsCategoryData.GetAllCategories();
        }

        public static bool DeleteCategory(int ID)
        {
            return clsCategoryData.DeleteCategory(ID); 
        }

        public static bool isCategoryExist(int ID)
        {
           return clsCategoryData.IsCategoryExist(ID);
        }


    }
}
