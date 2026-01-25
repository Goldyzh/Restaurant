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

namespace Restaurant.orders
{
  

    public partial class frmKitchenScreen : Form
    {
        private int _OrderID = -1;
        clsOrder _Order;

        private decimal _OrderTotalPrice = 0;

        private DataTable _dtOrders;

        private DataTable _dtOrderItems;

        public frmKitchenScreen()
        {
            InitializeComponent();
        }

        private void OrderItems()
        {

            _dtOrderItems = clsOrderItems.GetOrderItems(_OrderID);
            dgvOrderItems.DataSource = _dtOrderItems;


            if (dgvOrderItems.Rows.Count <= 0)
            {
                lblOrderItemsRecordsCount.Text = "0";
            }
            else
            {
                lblOrderItemsRecordsCount.Text = (dgvOrderItems.Rows.Count - 1).ToString();
            }

            if (dgvOrderItems.Rows.Count > 0)
            {

                dgvOrderItems.Columns[0].HeaderText = "ID";
                dgvOrderItems.Columns[0].Width = 80;

                dgvOrderItems.Columns[1].HeaderText = "Order ID";
                dgvOrderItems.Columns[1].Width = 80;

                dgvOrderItems.Columns[2].HeaderText = "Item ID";
                dgvOrderItems.Columns[2].Width = 80;

                _OrderTotalPrice = dgvOrderItems.Rows.Cast<DataGridViewRow>()
                                                    .Where(r => !r.IsNewRow)
                                                    .Sum(r => Convert.ToDecimal(r.Cells[5].Value ?? 0));

            }


        }



        private void GetRadyItems()
        {
            _dtOrders = clsOrder.GetIOrdersForKitchen();
            dgvInProgressOrders.DataSource = _dtOrders;

            if (dgvInProgressOrders.Rows.Count <= 0)
            {
                lblOrdersRecordsCount.Text = "0";
            }
            else
            {
                lblOrdersRecordsCount.Text = (dgvInProgressOrders.Rows.Count - 1).ToString();
            }

            if (dgvInProgressOrders.Rows.Count > 0)
            {

                dgvInProgressOrders.Columns[0].HeaderText = "Order ID";
                dgvInProgressOrders.Columns[0].Width = 80;

                dgvInProgressOrders.Columns[1].HeaderText = "Order Date";
                dgvInProgressOrders.Columns[1].Width = 120;

                dgvInProgressOrders.Columns[2].HeaderText = "Total Price";
                dgvInProgressOrders.Columns[2].Width = 80;

                dgvInProgressOrders.Columns[3].HeaderText = "Status";
                dgvInProgressOrders.Columns[3].Width = 120;

                dgvInProgressOrders.Columns[4].HeaderText = "Notes";
                dgvInProgressOrders.Columns[4].Width = 300;

                dgvInProgressOrders.Columns[5].HeaderText = "Order Name";
                dgvInProgressOrders.Columns[5].Width = 295;

                dgvInProgressOrders.Columns[6].HeaderText = "Created By";
                dgvInProgressOrders.Columns[6].Width = 80;


            }


        }

        private void frmKitchenScreen_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 1;

            GetRadyItems();
        }

        private void SetReadyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Set Ready Order [" + dgvInProgressOrders.CurrentRow.Cells[0].Value + "]", "Confirm Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                if (clsOrder.SetReady((int)dgvInProgressOrders.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Order set Ready Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GetRadyItems();
                   

                }
                else
                    MessageBox.Show("Order was not set Ready.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }


        private void dgvInProgressOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvInProgressOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //1- set _OrderID = ;
            _OrderID = (int)dgvInProgressOrders.CurrentRow.Cells[0].Value;

            //2- LoadOrderIems in OrderIemsdgv OrderItems();
            OrderItems();

            //3- find clsOrder _Order;
            _Order = clsOrder.FindBaseOrder(_OrderID);



        }

     
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column ItemName 
            switch (cbFilterBy.Text)
            {
                case "Order ID":
                    FilterColumn = "OrderID";
                    break;

                case "Order Name":
                    FilterColumn = "OrderName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtOrders.DefaultView.RowFilter = "";
                lblOrdersRecordsCount.Text = dgvInProgressOrders.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "OrderID")
                //in this case we deal with integer not string.

                _dtOrders.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtOrders.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblOrdersRecordsCount.Text = dgvInProgressOrders.Rows.Count.ToString();
        }



        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }

        private void txtFilterValue_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "Order ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
