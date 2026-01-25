using Restaurant.Classes;
using Restaurant.Properties;
using Restaurant_Buisness;
using Restaurant_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Item
{
    public partial class frmAddUpdatedItems : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int ItemID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };

        private enMode _Mode;
        private int _ItemID = -1;
        clsItems _Item;


        public frmAddUpdatedItems()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatedItems(int ItemID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _ItemID = ItemID;
        }


        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillCategoriesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Item";
                _Item = new clsItems();
            }
            else
            {
                lblTitle.Text = "Update Item";
            }


            pbPersonImage.Image = Resources.Male_512;


            //hide/show the remove linke incase there is no image for the person.
            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);


            //this will set default country to jordan.
            cbCategory.SelectedIndex = cbCategory.FindString("Jordan");

            txtItemName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";

            chkIsAvailable.Checked = true;


        }

        private void _FillCategoriesInComoboBox()
        {
            DataTable dtCategories = clsCategory.GetAllCategories();

            foreach (DataRow row in dtCategories.Rows)
            {
                cbCategory.Items.Add(row["Name"]);
            }
        }


        private string CategoryName = "1";

        private void cbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CategoryName = cbCategory.SelectedItem.ToString();
        }

        private void _LoadData()
        {

            _Item = clsItems.Find(_ItemID);

            if (_Item == null)
            {
                MessageBox.Show("No Person with ID = " + _ItemID, "Item Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lblItemID.Text = _ItemID.ToString();
            txtItemName.Text = _Item.ItemName;
            txtPrice.Text = _Item.Price.ToString();
            chkIsAvailable.Checked = _Item.IsAvailable;


            if (_Item.Description != "")
            {
                txtDescription.Text = _Item.Description;
            }


            cbCategory.Text = _Item.CategoryInfo.Name;




            //load person image incase it was set.
            if (_Item.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Item.ImagePath;

            }

            //hide/show the remove linke incase there is no image for the person.
            llRemoveImage.Visible = (_Item.ImagePath != "");

        }

        private void frmAddUpdatedItems_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Item.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Item.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Item.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Item.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

       

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!_HandlePersonImage())
                return;

            if (cbCategory.Text == "")
            {
                MessageBox.Show("Please select a Category", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int CategoryID = clsCategory.Find(cbCategory.Text).CategoryID;
        

            _Item.ItemName = txtItemName.Text.Trim();
            _Item.Price = decimal.Parse(txtPrice.Text) ;
            _Item.Description = txtDescription.Text.Trim();
            _Item.CreatedAt = DateTime.Now;
            _Item.CategoryID = CategoryID;

            //_Item.CategoryID = CategoryName;


            if (chkIsAvailable.Checked)
            {
                _Item.IsAvailable = true;
            }
            else
            {
                _Item.IsAvailable = false;
            }
             


            



            if (pbPersonImage.ImageLocation != null)
                _Item.ImagePath = pbPersonImage.ImageLocation;
            else
                _Item.ImagePath = "";

            if (_Item.Save())
            {
                lblItemID.Text = _Item.ItemID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Item.ItemID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private void llSetImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            pbPersonImage.ImageLocation = null;



            pbPersonImage.Image = Resources.Male_512;

            llRemoveImage.Visible = false;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            //change the defualt image to female incase there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            //change the defualt image to male incase there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }


     


    }
}

