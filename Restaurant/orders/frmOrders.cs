using Restaurant.People;
using Restaurant.Properties;
using Restaurant_Buisness;
using Restaurant_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.orders
{
    public partial class frmOrders : Form
    {
        private int _OrderID = -1;
        clsOrder _Order;
        private decimal OrderTotalPrice = 0;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;




        private DataTable _dtOrders;

        private DataTable _dtOrderItems;

        public frmOrders()
        {
            InitializeComponent();
            //_Mode = enMode.AddNew;

        }

     





        private void PendingOrders()
        {
            _dtOrders = clsOrder.GetPendingOrders();
            dgvOrders.DataSource = _dtOrders;

            lbllblOrdersRecordsCount.Text = dgvOrders.Rows.Count.ToString();
            if (dgvOrders.Rows.Count > 0)
            {

                dgvOrders.Columns[0].HeaderText = "Order ID";
                dgvOrders.Columns[0].Width = 80;

                dgvOrders.Columns[1].HeaderText = "Order Date";
                dgvOrders.Columns[1].Width = 120;

                dgvOrders.Columns[2].HeaderText = "Total Price";
                dgvOrders.Columns[2].Width = 80;

                dgvOrders.Columns[3].HeaderText = "Status";
                dgvOrders.Columns[3].Width = 120;

                dgvOrders.Columns[4].HeaderText = "Notes";
                dgvOrders.Columns[4].Width = 300;

                dgvOrders.Columns[5].HeaderText = "Created By";
                dgvOrders.Columns[5].Width = 80;

                dgvOrders.Columns[6].HeaderText = "Order Name";
                dgvOrders.Columns[6].Width = 300;


            }

        }

        private void OrderItems()
        {

            _dtOrderItems = clsOrderItems.GetOrderItems(_OrderID);
            dgvOrderItems.DataSource = _dtOrderItems;

            lblOrderItemsRecordsCount.Text = dgvOrderItems.Rows.Count.ToString();
            if (dgvOrderItems.Rows.Count > 0)
            {

                dgvOrderItems.Columns[0].HeaderText = "ID";
                dgvOrderItems.Columns[0].Width = 80;

                dgvOrderItems.Columns[1].HeaderText = "Order ID";
                dgvOrderItems.Columns[1].Width = 120;

                dgvOrderItems.Columns[2].HeaderText = "Item ID";
                dgvOrderItems.Columns[2].Width = 80;

                 OrderTotalPrice = dgvOrderItems.Rows.Cast<DataGridViewRow>()
                                                     .Where(r => !r.IsNewRow)
                                                     .Sum(r => Convert.ToDecimal(r.Cells[5].Value ?? 0));
                                                    
            }

            lblTotalPrice.Text = OrderTotalPrice.ToString();


        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
          
            frmAddItemToOrder frm1 = new frmAddItemToOrder(_OrderID , -1);
            
            //frmAddItemToOrder frm1 = new frmAddItemToOrder();

            frm1.DataBack += Frm_DataBack;

            frm1.OnOrderItemsChanged += () =>
            {
                OrderItems();
                PendingOrders();
            };


            frm1.ShowDialog();

        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddItemToOrder frm1 = new frmAddItemToOrder(_OrderID , (int)dgvOrderItems.CurrentRow.Cells[0].Value);
            frm1.ShowDialog();

            frm1.DataBack += Frm_DataBack;

            frm1.OnOrderItemsChanged += () =>
            {
                OrderItems();
                PendingOrders();
            };


            frm1.ShowDialog();

        }


        private void Frm_DataBack(object sender, int orderID)
        {

            _OrderID = orderID;
            _Order = clsOrder.FindBaseOrder(orderID);

            lblOrderID.Text = _Order.OrderID.ToString();

            lblTotalPrice.Text = _Order.TotalPrice.ToString();



        }



        private void _ResetDefualtValues()
        {
          

            if (_Mode == enMode.AddNew)
            {
                _Order = new clsOrder();
            }


            lblTotalPrice.Text = "0";

            rbPending.Checked = true;

            txtNotes.Text = "";

            textOrderNmae.Text = "";




        }


        private void frmOrders_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            PendingOrders();

            OrderItems();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrderNow_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblOrderItemsRecordsCount.Text) < 0){
                MessageBox.Show("Please add Items to the Order", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Order.OrderDate = DateTime.Now;
            //_Order.TotalPrice = 0;
            if (rbPending.Checked == true)
            {
                _Order.Status = "Pending";

            }
            if (rbFinished.Checked == true) {
            
                _Order.Status = "Finished";
            
            }

            _Order.Notes = txtNotes.Text;

            if(textOrderNmae.Text != "")
            {
                _Order.OrderName = textOrderNmae.Text;
            }
            


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Item [" + dgvOrderItems.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsOrderItems.DeleteOrderItems((int)dgvOrderItems.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Item Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OrderItems();
                }

                else
                    MessageBox.Show("Item was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    

     
    }
}
