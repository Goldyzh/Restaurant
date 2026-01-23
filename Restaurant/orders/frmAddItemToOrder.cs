using Restaurant.Properties;
using Restaurant_Buisness;
using Restaurant_DataAccess;
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
using static Restaurant.orders.frmAddItemToOrder;
using static System.Net.Mime.MediaTypeNames;


namespace Restaurant.orders
{
    public partial class frmAddItemToOrder : Form
    {

        public delegate void DataBackEventHandler(object sender, int orderID);
        public event DataBackEventHandler DataBack;

        public event Action OnOrderItemsChanged;


        private int _ItemID = -1;
        clsItems _Item;

        private int _OrderItemsID = -1;
        clsOrderItems _OrderItems;

        decimal OrderItemsTotalPrice = 0;


        private int _OrderID = -1;
        clsOrder _Order;
        private string _OrderName = "";
        private string _Notes = "";
        decimal OrderTotalPrice = 0;





        public enum OrderMode { AddNew = 0, Update = 1 };

        private OrderMode _OrderMode;


        public enum OrderItemsMode { AddNew = 0, Update = 1 };

        private OrderItemsMode _OrderItemsMode;


        //public frmAddItemToOrder()
        //{
        //    InitializeComponent();
        //    _OrderMode = OrderMode.AddNew;
        //    _OrderItemsMode = OrderItemsMode.AddNew;

        //}

        public frmAddItemToOrder(int OrderID , int OrderItemsID , string OrderNmae, string Notes)
        {
            InitializeComponent();

            if (OrderID != -1)
            {
               _OrderMode = OrderMode.Update;
               _OrderID = OrderID;
               _OrderName = OrderNmae;
               _Notes = Notes;
                Console.WriteLine(OrderNmae);
                Console.WriteLine(Notes);
                

            }
            else
            {
                _OrderMode = OrderMode.AddNew;
            }

            if (OrderItemsID != -1)
            {
                _OrderItemsMode = OrderItemsMode.Update;
                _OrderItemsID = OrderItemsID;
                _OrderID = OrderID;
            }
            else
            {
                _OrderItemsMode = OrderItemsMode.AddNew;

            }



        }

        private void _ResetDefualtValues()
        {

            if (_OrderMode == OrderMode.AddNew)
            {
                _Order = new clsOrder();
            }
            //else
            //{
            //    lblTitle.Text = "Update Person";
            //}

        

            if (_OrderItemsMode == OrderItemsMode.AddNew)
            {
                _OrderItems = new clsOrderItems();
            }
          

            //txtQuantity.Text = "1";


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

        private void _FillItemsInComoboBox(string CategoryName)
        {


            dtItems = clsItems.GetAllItemsForComboBox(CategoryName);

            cbItem.Items.Clear();
            foreach (DataRow row in dtItems.Rows)
            {
                cbItem.Items.Add(row["ItemName"]);
            }
        }

        private void _FillItemsInComoboBoxByCategoryID(int CategoryID)
        {


            dtItems = clsItems.FillItemsInComoboBoxByCategoryID(CategoryID);

            cbItem.Items.Clear();
            foreach (DataRow row in dtItems.Rows)
            {
                cbItem.Items.Add(row["ItemName"]);
            }
        }


        

        private void cbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string CategoryName = cbCategory.SelectedItem.ToString();

            _FillItemsInComoboBox(CategoryName);


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

            _Item = clsItems.FindItemByItemName(cbItem.Text);

            _ItemID = _Item.ItemID;



            CalculatePrice(_Item.Price, 1);


        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
           

            int Quantity = 1;

            int.TryParse(txtQuantity.Text, out Quantity);

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
                return;

           // Quantity = int.Parse(txtQuantity.Text);

            if (!int.TryParse(txtQuantity.Text, out int value))
            {
                MessageBox.Show(
                    "الكمية المدخلة أكبر من الحد المسموح به",
                    "تحذير",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtQuantity.Text = int.MaxValue.ToString();
                txtQuantity.SelectionStart = txtQuantity.Text.Length;
            }

            if (_Item == null)
                return;
            CalculatePrice(_Item.Price, Quantity);



        }

        private void _LoadData()
        {
            if (_OrderMode == OrderMode.Update)
            {
                _Order = clsOrder.FindBaseOrder(_OrderID);

                if (_Order == null)
                {
                    MessageBox.Show("No Order with ID = " + _OrderID, "Order Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

            }


            if (_OrderItemsMode == OrderItemsMode.Update)
            {
                _OrderItems = clsOrderItems.FindBaseOrder(_OrderItemsID);


                if (_OrderItems == null)
                {
                    MessageBox.Show("No OrderItem with ID = " + _OrderItemsID, "Order Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
                else
                {
                    _ItemID = _OrderItems.ItemID;
                }

                _Item = clsItems.Find(_ItemID);


                if (_Item == null)
                {
                    MessageBox.Show("No Item with ID = " + _ItemID, "Order Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

                //MessageBox.Show(_Item.ItemName);



                _FillItemsInComoboBoxByCategoryID(_Item.CategoryID);

                cbItem.SelectedIndex = cbItem.FindString(_Item.ItemName);

                cbCategory.Text = _Item.CountryInfo.Name;



                lblTitle.Text = "Update Item";

                lblPrice.Text = _OrderItems.Price.ToString();

                txtQuantity.Text = _OrderItems.Quantity.ToString();




                Console.WriteLine("cbItem.SelectedIndex");
                Console.WriteLine(cbItem.SelectedIndex);
                Console.WriteLine("cbItem.SelectedIndex");

            }

           



        }

        private void frmAddItemToOrder_Load(object sender, EventArgs e)
        {
            _FillCategoriesInComoboBox();
            _ResetDefualtValues();

            //if (_OrderItemsMode == OrderItemsMode.Update)
            //{
            //    _LoadData();
            //}
            _LoadData();


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
            if (int.Parse(txtQuantity.Text) < 0)
            {
                MessageBox.Show("Please Quantity a valid Quantity", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _Order.OrderDate = DateTime.Now;
            _Order.TotalPrice = OrderTotalPrice;
            _Order.Status = "Pending";
           // _Order.Notes = _Notes;
            //_Order.OrderName = _OrderName;


            //for now 1
            _Order.CreatedBy = 1;







            bool IsOrderSaved = false;

            //if (_OrderMode == OrderMode.AddNew)
            //{
                if (_Order.Save())
                {
                    //لازم نرجع الايدي للكالد فورم
                    // lblCategoryID.Text = _Category.CategoryID.ToString();
                    //change form mode to update.
                    _OrderMode = OrderMode.Update;
                    _OrderID = _Order.OrderID;


                    // Trigger the event to send data back to the caller form.
                    DataBack?.Invoke(this, _Order.OrderID);

                    IsOrderSaved = true;
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IsOrderSaved = false;
                }
            //}

           

          
            if (IsOrderSaved)
            {
                _OrderItems.OrderID = _OrderID;
                _OrderItems.ItemID = _ItemID;
                _OrderItems.Quantity = int.Parse(txtQuantity.Text);
                _OrderItems.Price = OrderItemsTotalPrice;
                
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

            OnOrderItemsChanged?.Invoke();

            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



      
    }
}
