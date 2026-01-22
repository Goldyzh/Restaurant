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

            _dtOrders = clsOrder.GetFinishedOrders();
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

     
    }
}
