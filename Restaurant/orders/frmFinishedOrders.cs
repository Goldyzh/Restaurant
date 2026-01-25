using Restaurant.People;
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
    public partial class frmFinishedOrders : Form
    {

        private DataTable _dtOrders;

        public frmFinishedOrders()
        {
            InitializeComponent();
        }

     

        private void frmFinishedOrders_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 1;

            _dtOrders = clsOrder.GetFinishedOrders();
            dgvOrders.DataSource = _dtOrders;

            lblOrdersRecordsCount.Text = (dgvOrders.Rows.Count - 1).ToString();
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

                dgvOrders.Columns[5].HeaderText = "Order Name";
                dgvOrders.Columns[5].Width = 300;

                dgvOrders.Columns[6].HeaderText = "Created By";
                dgvOrders.Columns[6].Width = 90;


            }

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
                lblOrdersRecordsCount.Text = dgvOrders.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "OrderID")
                //in this case we deal with integer not string.

                _dtOrders.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtOrders.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblOrdersRecordsCount.Text = dgvOrders.Rows.Count.ToString();
        }



        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
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
