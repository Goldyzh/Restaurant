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

        private DataTable _dtOrders;

        public frmKitchenScreen()
        {
            InitializeComponent();
        }

        private void GetRadyItems()
        {
            _dtOrders = clsOrder.GetIOrdersForKitchen();
            dgvInProgressOrders.DataSource = _dtOrders;

            if (dgvInProgressOrders.Rows.Count <= 0)
            {
                lbllblOrdersRecordsCount.Text = "0";
            }
            else
            {
                lbllblOrdersRecordsCount.Text = (dgvInProgressOrders.Rows.Count - 1).ToString();
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

                dgvInProgressOrders.Columns[5].HeaderText = "Created By";
                dgvInProgressOrders.Columns[5].Width = 80;

                dgvInProgressOrders.Columns[6].HeaderText = "Order Name";
                dgvInProgressOrders.Columns[6].Width = 300;


            }


        }


        private void frmKitchenScreen_Load(object sender, EventArgs e)
        {

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
    }
}
