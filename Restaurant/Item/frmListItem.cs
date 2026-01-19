using Restaurant.category;
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
using Restaurant.Classes;
using System.Security.Policy;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Restaurant.Item
{
    public partial class frmListItem : Form
    {

        private static DataTable _dtAllItems = clsItems.GetAllItems();





        //only select the columns that you want to show in the grid
        private DataTable _dtCategory = _dtAllItems.DefaultView.ToTable(false, "ItemID", "ItemName", "Price",
                                                         "Description" , "ImagePath" , "IsAvailable" , "CreatedAt" , "Name");

        private void _RefreshItemsList()
        {
            _dtAllItems = clsItems.GetAllItems();
            _dtCategory = _dtAllItems.DefaultView.ToTable(false, "ItemID", "ItemName", "Price",
                                                         "Description", "ImagePath", "IsAvailable", "CreatedAt", "Name");

            dgvItems.DataSource = _dtCategory;
            lblRecordsCount.Text = dgvItems.Rows.Count.ToString();
        }

        public frmListItem()
        {
            InitializeComponent();
        }

        private void frmListItem_Load(object sender, EventArgs e)
        {
            dgvItems.DataSource = _dtCategory;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvItems.Rows.Count.ToString();
            if (dgvItems.Rows.Count > 0)
            {

                dgvItems.Columns[0].HeaderText = "Item ID";
                dgvItems.Columns[0].Width = 80;

                dgvItems.Columns[1].HeaderText = "Item Name";
                dgvItems.Columns[1].Width = 150;

                dgvItems.Columns[2].HeaderText = "Price";
                dgvItems.Columns[2].Width = 80;

                dgvItems.Columns[3].HeaderText = "Description";
                dgvItems.Columns[3].Width = 320;

                dgvItems.Columns[4].HeaderText = "Image Path";
                dgvItems.Columns[4].Width = 150;

                dgvItems.Columns[5].HeaderText = "Is Available";
                dgvItems.Columns[5].Width = 80;

                dgvItems.Columns[6].HeaderText = "Created At";
                dgvItems.Columns[6].Width = 150;

                dgvItems.Columns[7].HeaderText = "Category Name";
                dgvItems.Columns[7].Width = 130;


            }


        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column ItemName 
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "CategoryID";
                    break;

                case "National No.":
                    FilterColumn = "ItemName";
                    break;

                case "First ItemName":
                    FilterColumn = "Description";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtCategory.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvItems.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "CategoryID")
                //in this case we deal with integer not string.

                _dtCategory.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtCategory.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvItems.Rows.Count.ToString();

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

        private void showDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int ItemID = (int)dgvItems.CurrentRow.Cells[0].Value;
            Form frm = new frmAddUpdatedItems(ItemID);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            Form frm = new frmAddUpdatedItems((int)dgvItems.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshItemsList();

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            //if (MessageBox.Show("Are you sure you want to delete Person [" + dgvCategory.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            //{

            //    //Perform Delele and refresh
            //    if (clsItems.DeletePerson((int)dgvCategory.CurrentRow.Cells[0].Value))
            //    {
            //        MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        _RefreshPeoplList();
            //    }

            //    else
            //        MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //Form frm = new frmAddUpdatePerson();
            //frm.ShowDialog();

            //_RefreshPeoplList();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCategory_DoubleClick(object sender, EventArgs e)
        {
            //Form frm = new frmShowPersonInfo((int)dgvCategory.CurrentRow.Cells[0].Value);
            //frm.ShowDialog();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmAddUpdatedItems();
            frm1.ShowDialog();
            _RefreshItemsList();
        }

  

 

     
    }
}
