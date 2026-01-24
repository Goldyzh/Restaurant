using Restaurant.Category;
using Restaurant.Classes;
using Restaurant.Item;
using Restaurant.Login;
using Restaurant.orders;
using Restaurant.People;
using Restaurant.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace Restaurant
{

    public partial class frmMain : Form
    {
        frmLogin _frmLogin;




        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();

            lblCurrentTime.Text = "Time: " + DateTime.Now.ToString("hh:mm tt");
            lblCurrentDate.Text = "Date: " + DateTime.Now.ToShortDateString();

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = "Time: " + DateTime.Now.ToString("hh:mm tt");
            lblCurrentDate.Text = "Date: " + DateTime.Now.ToShortDateString();

        }



        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }


        private void vehiclesLicensesServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btmPeople_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != "Manager")
            {
                MessageBox.Show(
                    "You Do Not Have Access to this Section",
                    "Higher Permissions Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }


            Form frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != "Manager")
            {
                MessageBox.Show(
                    "You Do Not Have Access to this Section",
                    "Higher Permissions Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            Form frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            Form frm = new frmListCategory();
            frm.ShowDialog();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            Form frm = new frmListItem();
            frm.ShowDialog();
            
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentUser.Permissions != "Manager"
                && clsGlobal.CurrentUser.Permissions != "Cashier")
            {

                MessageBox.Show(
                    "You Do Not Have Access to this Section",
                    "Higher Permissions Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Form frm = new frmOrders();
            frm.ShowDialog();

        }

        private void btnFinishedOrders_Click(object sender, EventArgs e)
        {
            Form frm = new frmFinishedOrders();
            frm.ShowDialog();

        }

        private void btnKitchenScreen_Click(object sender, EventArgs e)
        {
            Form frm = new frmKitchenScreen();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            lblCurrentUser.Text = "User: " + clsGlobal.CurrentUser.UserName;
            this.Refresh();
        }
    }
}
