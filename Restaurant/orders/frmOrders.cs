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
using static System.Net.Mime.MediaTypeNames;

namespace Restaurant.orders
{
    public partial class frmOrders : Form
    {
        private int _OrderID = -1;
        clsOrder _Order;
        private string _OrderName = "";
        private string _Notes = "";
        private decimal _OrderTotalPrice = 0;

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
            _dtOrders = clsOrder.GetOrdersForOrdersScreen();
            dgvOrders.DataSource = _dtOrders;

            if (dgvOrders.Rows.Count <= 0)
            {
                lbllblOrdersRecordsCount.Text = "0";
            }
            else
            {
                lbllblOrdersRecordsCount.Text = (dgvOrders.Rows.Count - 1).ToString();
            }

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
                dgvOrders.Columns[6].Width = 80;


            }

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
                dgvOrderItems.Columns[1].Width = 120;

                dgvOrderItems.Columns[2].HeaderText = "Item ID";
                dgvOrderItems.Columns[2].Width = 80;

                 _OrderTotalPrice = dgvOrderItems.Rows.Cast<DataGridViewRow>()
                                                     .Where(r => !r.IsNewRow)
                                                     .Sum(r => Convert.ToDecimal(r.Cells[5].Value ?? 0));
                                                    
            }

            lblTotalPrice.Text = _OrderTotalPrice.ToString();

            


        }



        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddItemToOrder frm1 = new frmAddItemToOrder(_OrderID , (int)dgvOrderItems.CurrentRow.Cells[0].Value ,  _OrderName,  _Notes, _OrderTotalPrice);

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

            _OrderID = -1;

            dgvOrderItems.DataSource = null;

            _Order = null;

             _OrderTotalPrice = 0;

            lblOrderID.Text = "N/A";

            lblTotalPrice.Text = "0";

            lblOrderStatus.Text = "N/A";

            // txtNotes.Text = "";

            //txtOrderName.Text = "";




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

            
                _Order.Status = "Pending";

            
          

            _Order.Notes = txtNotes.Text;

            if(txtOrderName.Text != "")
            {
                _Order.OrderName = txtOrderName.Text;
            }

            if (clsOrder.SetInProgress((int)dgvOrders.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Order set In Progress Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PendingOrders();

            }
            else
                MessageBox.Show("Order was not set In Progress.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);





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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Order [" + dgvOrders.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                //Perform Deleleand refresh
                if (clsOrderItems.DeleteOrderItemsByOrderID((int)dgvOrders.CurrentRow.Cells[0].Value))
                {
                    if (clsOrder.DeleteOrder((int)dgvOrders.CurrentRow.Cells[0].Value))
                    {
                        MessageBox.Show("Order Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OrderItems();
                        PendingOrders();

                    }

                }
                else
                    MessageBox.Show("Order was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        void _LoadOrderForEdit()
        {
            //1- set _OrderID = ;
            _OrderID = (int)dgvOrders.CurrentRow.Cells[0].Value;

            //2- LoadOrderIems in OrderIemsdgv OrderItems();
            OrderItems();

            //3- find clsOrder _Order;
            _Order = clsOrder.FindBaseOrder(_OrderID);

            

            //4- load Data in form
            lblOrderID.Text = _OrderID.ToString();

            lblOrderStatus.Text = _Order.Status.ToString();

            if (_Order.Notes != "")
            {
                txtNotes.Text = _Order.Notes.ToString();

            }
            if (_Order.OrderName != "")
            {
                txtOrderName.Text = _Order.OrderName.ToString();

            }



        }

       

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _LoadOrderForEdit();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel Order [" + dgvOrders.CurrentRow.Cells[0].Value + "]", "Confirm Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

          
                 if (clsOrder.Cancel((int)dgvOrders.CurrentRow.Cells[0].Value))
                 {
                    MessageBox.Show("Order Cancelled Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OrderItems();
                    PendingOrders();
                    _ResetDefualtValues();

                 }
                 else
                 MessageBox.Show("Order was not Cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void btnNewOrder(object sender, EventArgs e)
        {
            _OrderID = -1;

            OrderItems();

            _ResetDefualtValues();

            frmAddItemToOrder frm1 = new frmAddItemToOrder(_OrderID, -1 , _OrderName, _Notes, _OrderTotalPrice);

            //frmAddItemToOrder frm1 = new frmAddItemToOrder();

            frm1.DataBack += Frm_DataBack;

            frm1.OnOrderItemsChanged += () =>
            {
                OrderItems();
                PendingOrders();
            };


            frm1.ShowDialog();

        }

        private void setFinishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to set Finish Order [" + dgvOrders.CurrentRow.Cells[0].Value + "]", "Confirm Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                if (clsOrder.SetFinished((int)dgvOrders.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Order set Finished Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    OrderItems();
                    PendingOrders();

                }
                else
                    MessageBox.Show("Order was not set Finished.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void textOrderNmae_TextChanged(object sender, EventArgs e)
        {
            _OrderName = txtOrderName.Text;
           
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            _Notes = txtNotes.Text;
           
        }

        private void lblTotalPrice_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmAddItemToOrder frm1 = new frmAddItemToOrder(_OrderID, -1, _OrderName, _Notes, _OrderTotalPrice);

            frm1.DataBack += Frm_DataBack;

            frm1.OnOrderItemsChanged += () =>
            {
                OrderItems();
                PendingOrders();
            };

            frm1.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            frmAddItemToOrder frm1 = new frmAddItemToOrder(_OrderID, -1, _OrderName, _Notes, _OrderTotalPrice);

            frm1.DataBack += Frm_DataBack;

            frm1.OnOrderItemsChanged += () =>
            {
                OrderItems();
                PendingOrders();
            };

            frm1.ShowDialog();
        }
    }
}
