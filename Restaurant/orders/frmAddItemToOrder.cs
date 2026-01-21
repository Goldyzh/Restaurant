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
            //Console.WriteLine("==============================");
            //Console.WriteLine("CategoryID==============================");
            //Console.WriteLine(CategoryID);
            //Console.WriteLine("CategoryID==============================");


            dtItems = clsItems.GetAllItemsForComboBox(CategoryID);

            cbItem.Items.Clear();
            foreach (DataRow row in dtItems.Rows)
            {
                cbItem.Items.Add(row["ItemName"]);
            }
        }

        private void cbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {

            int CategoryID = cbCategory.SelectedIndex + 1;

            _FillItemsInComoboBox(CategoryID);

        }

        private void GetItem(int ItemID)
        {
            _Item = clsItems.Find(ItemID);

        }

        private void CalculatePrice(decimal Price, int Quantity)
        {

            int.TryParse(txtQuantity.Text, out Quantity);

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
                return;

            decimal TotalPrice = Price * Quantity;

            lblPrice.Text = TotalPrice.ToString();

            Console.WriteLine("_Item.Price in CalculatePrice==============================");
            Console.WriteLine(TotalPrice);
            Console.WriteLine("_Item.Price in CalculatePrice==============================");
            lblPrice.Text = TotalPrice.ToString();
        }


        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ItemID = clsItems.FindItemByItemName(cbItem.Text).ItemID;

            GetItem(ItemID);

            int Quantity = 1;

            CalculatePrice(_Item.Price, Quantity);


        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

            //decimal TotalPrice = _Item.Price * decimal.Parse(txtQuantity.Text);

            int Quantity = 1;

            int.TryParse(txtQuantity.Text, out Quantity);

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
                return;

            Quantity = int.Parse(txtQuantity.Text);

            CalculatePrice(_Item.Price, Quantity);




            //  lblPrice.Text = _Item.Price.ToString();



            //Console.WriteLine("_Item.Price");
            //Console.WriteLine(_Item.Price);
            //Console.WriteLine("_Item.Price");

            //Console.WriteLine("txtQuantity_TextChanged");
            //Console.WriteLine(txtQuantity.Text);
            //Console.WriteLine("txtQuantity_TextChanged");


            //Console.WriteLine("_Item.Price");
            //Console.WriteLine(TotalPrice);
            //Console.WriteLine("_Item.Price");


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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
