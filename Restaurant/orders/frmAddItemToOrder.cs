using Restaurant_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Restaurant.orders
{
    public partial class frmAddItemToOrder : Form
    {

        private int _ItemID = -1;
        clsItems _Item;

        

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;

        public frmAddItemToOrder()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }

      


        private void _FillCategoriesInComoboBox()
        {
            DataTable dtCategories = clsCategory.GetAllCategories();

            foreach (DataRow row in dtCategories.Rows)
            {
                cbCategory.Items.Add(row["Name"]);
            }
        }

        DataTable dtItems = new DataTable();

        private void _FillItemsInComoboBox(int CategoryID)
        {
            Console.WriteLine("==============================");
            Console.WriteLine("_FillItemsInComoboBox Called" );
            Console.WriteLine("CategoryID==============================");
            Console.WriteLine(CategoryID);
            Console.WriteLine("CategoryID==============================");


            dtItems = clsItems.GetAllItemsForComboBox(CategoryID);

            cbItem.Items.Clear();
            foreach (DataRow row in dtItems.Rows)
            {
                cbItem.Items.Add(row["ItemName"]);
            }
        }

        private void cbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Console.WriteLine("selected==============================");
            Console.WriteLine(cbCategory.SelectedIndex);
            Console.WriteLine("selected==============================");

            int CategoryID = cbCategory.SelectedIndex + 1;

            _FillItemsInComoboBox(CategoryID);

        }

        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ItemID = cbItem.SelectedIndex + 1;

            _Item = clsItems.Find(ItemID);

            Console.WriteLine("_Item==============================");
            Console.WriteLine(ItemID);
            Console.WriteLine("_Item==============================");



        }



        private void frmAddItemToOrder_Load(object sender, EventArgs e)
        {
            _FillCategoriesInComoboBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbCategory.Text == "")
            {
                MessageBox.Show("Please select a Category", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

      
    }
}
