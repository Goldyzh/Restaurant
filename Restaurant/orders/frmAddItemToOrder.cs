using Restaurant_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        public delegate void DataBackEventHandler(object sender, int orderID);
        public event DataBackEventHandler DataBack;



        private int _ItemID = -1;
        clsItems _Item;

        private int _OrderItemsID = -1;
        clsOrderItems _OrderItems;

        decimal OrderItemsTotalPrice = 0;


        private int _OrderID = -1;
        clsOrder _Order;
        decimal OrderTotalPrice = 0;



        

        public enum OrderMode { AddNew = 0, Update = 1 };

        private OrderMode _OrderMode;


        public enum OrderItemsMode { AddNew = 0, Update = 1 };

        private OrderItemsMode _OrderItemsMode;


        public frmAddItemToOrder()
        {
            InitializeComponent();
            _OrderMode = OrderMode.AddNew;
            _OrderItemsMode = OrderItemsMode.AddNew;


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

             OrderItemsTotalPrice = Price * Quantity;

            lblPrice.Text = OrderItemsTotalPrice.ToString();

        }


        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            _ItemID = clsItems.FindItemByItemName(cbItem.Text).ItemID;

            GetItem(_ItemID);

            int Quantity = 1;

            CalculatePrice(_Item.Price, Quantity);


        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {


            int Quantity = 1;

            int.TryParse(txtQuantity.Text, out Quantity);

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
                return;

            Quantity = int.Parse(txtQuantity.Text);

            CalculatePrice(_Item.Price, Quantity);



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
            if (cbItem.Text == "")
            {
                MessageBox.Show("Please select a Item", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(txtQuantity.Text) > 1)
            {
                MessageBox.Show("Please Quantity a valid Quantity", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _Order.OrderDate = DateTime.Now;
            _Order.TotalPrice = OrderTotalPrice;
            _Order.Status = "Pending";

            //for now 1
            _Order.CreatedBy = 1;







            bool IsOrderSaved = false;

            if (_OrderMode == OrderMode.AddNew)
            {
                if (_Order.Save())
                {
                    //لازم نرجع الايدي للكالد فورم
                    // lblCategoryID.Text = _Category.CategoryID.ToString();
                    //change form mode to update.
                    _OrderMode = OrderMode.Update;


                    // Trigger the event to send data back to the caller form.
                    DataBack?.Invoke(this, _Order.OrderID);

                    IsOrderSaved = true;
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IsOrderSaved = false;
                }
            }

           
          
            if (IsOrderSaved)
            {
                if (_OrderItems.Save())
                {
                    _OrderItemsMode = OrderItemsMode.Update;
                    lblTitle.Text = "Update Order Item";

                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // زايد
                    // Trigger the event to send data back to the caller form.
                    //  DataBack?.Invoke(this, _OrderItems.ItemID);
                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
