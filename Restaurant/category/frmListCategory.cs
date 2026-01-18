using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Restaurant.Classes;
using Restaurant_Buisness;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Restaurant.Category
{
    public partial class frmListCategory : Form
    {

        private static DataTable _dtAllCategory = clsCategory.GetAllCategories();

        



        //only select the columns that you want to show in the grid
        private DataTable _dtCategory = _dtAllCategory.DefaultView.ToTable(false, "CategoryID", "Name",
                                                         "Description");

        private void _RefreshPeoplList()
        {
            _dtAllCategory = clsCategory.GetAllCategories();
            _dtCategory = _dtAllCategory.DefaultView.ToTable(false, "CategoryID", "Name",
                                                       "Description");

            dgvCategory.DataSource = _dtCategory;
            lblRecordsCount.Text = dgvCategory.Rows.Count.ToString();
        }

        public frmListCategory()
        {
            InitializeComponent();
        }

        private void frmListCategory_Load(object sender, EventArgs e)
        {
            dgvCategory.DataSource = _dtCategory;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvCategory.Rows.Count.ToString();
            if (dgvCategory.Rows.Count > 0)
            {

                dgvCategory.Columns[0].HeaderText = "Category ID";
                dgvCategory.Columns[0].Width = 50;

                dgvCategory.Columns[1].HeaderText = "Name.";
                dgvCategory.Columns[1].Width = 150;


                dgvCategory.Columns[2].HeaderText = "Description";
                dgvCategory.Columns[2].Width = 320;


            }


        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "CategoryID";
                    break;

                case "National No.":
                    FilterColumn = "Name";
                    break;

                case "First Name":
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
                lblRecordsCount.Text = dgvCategory.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "CategoryID")
                //in this case we deal with integer not string.

                _dtCategory.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtCategory.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvCategory.Rows.Count.ToString();

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

        //private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    int CategoryID = (int)dgvCategory.CurrentRow.Cells[0].Value;
        //    Form frm = new frmShowPersonInfo(CategoryID);
        //    frm.ShowDialog();
        //}

        //private void editToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    Form frm = new frmAddUpdatePerson((int)dgvCategory.CurrentRow.Cells[0].Value);
        //    frm.ShowDialog();

        //    _RefreshPeoplList();

        //}

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (MessageBox.Show("Are you sure you want to delete Person [" + dgvCategory.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            //{

            //    //Perform Delele and refresh
            //    if (clsCategory.DeletePerson((int)dgvCategory.CurrentRow.Cells[0].Value))
            //    {
            //        MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        _RefreshPeoplList();
            //    }

            //    else
            //        MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Form frm = new frmAddUpdatePerson();
            //frm.ShowDialog();

            //_RefreshPeoplList();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            //Form frm1 = new frmAddUpdatePerson();
            //frm1.ShowDialog();
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

     
    }
}
