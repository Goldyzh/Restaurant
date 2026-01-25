using Restaurant.category;
using Restaurant.Classes;
using Restaurant_Buisness;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Restaurant.Category
{
    public partial class frmListCategory : Form
    {

        private static DataTable _dtAllCategory = clsCategory.GetAllCategories();

        



        //only select the columns that you want to show in the grid
        private DataTable _dtCategory = _dtAllCategory.DefaultView.ToTable(false, "CategoryID", "Name",
                                                         "Description");

        private void _RefreshCategoryList()
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
            cbFilterBy.SelectedIndex = 1;
            if (dgvCategory.Rows.Count <= 0)
            {
                lblRecordsCount.Text = "0";
            }
            else
            {
                lblRecordsCount.Text = (dgvCategory.Rows.Count - 1).ToString();
            }
            if (dgvCategory.Rows.Count > 0)
            {

                dgvCategory.Columns[0].HeaderText = "Category ID";
                dgvCategory.Columns[0].Width = 50;

                dgvCategory.Columns[1].HeaderText = "Name";
                dgvCategory.Columns[1].Width = 190;


                dgvCategory.Columns[2].HeaderText = "Description";
                dgvCategory.Columns[2].Width = 375;


            }


        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Category ID":
                    FilterColumn = "CategoryID";
                    break;

                case "Name":
                    FilterColumn = "Name";
                    break;

                case "Description":
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


        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

  
      

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "Category ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmAddUpdatedCategory();
            frm1.ShowDialog();
            _RefreshCategoryList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvCategory.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsCategory.DeleteCategory((int)dgvCategory.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Category Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshCategoryList();
                }

                else
                    MessageBox.Show("Category was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
