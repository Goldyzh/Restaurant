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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Runtime.ConstrainedExecution;

namespace Restaurant.category
{
    public partial class frmAddUpdatedCategory : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };

        private enMode _Mode;
        private int _CategoryID = -1;
        clsCategory _Category;

        public frmAddUpdatedCategory()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }

        public frmAddUpdatedCategory(int CategoryID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _CategoryID = CategoryID;
        }

        private void _ResetDefualtValues()
        {


            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Category";
                _Category = new clsCategory();
            }
            else
            {
                lblTitle.Text = "Update Category";
            }



            //hide/show the remove linke incase there is no image for the person.
            llRemoveImage.Visible = (pbCategoryImage.ImageLocation != null);




        }



        private void _LoadData()
        {

            _Category = clsCategory.Find(_CategoryID);

            if (_Category == null)
            {
                MessageBox.Show("No Category with ID = " + _CategoryID, "Category Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lblCategoryID.Text = _CategoryID.ToString();
            txtName.Text = _Category.Name;


        

            txtDescription.Text = _Category.Description;



            //load person image incase it was set.
            if (_Category.ImagePath != "")
            {
                pbCategoryImage.ImageLocation = _Category.ImagePath;

            }

            //hide/show the remove linke incase there is no image for the person.
            llRemoveImage.Visible = (_Category.ImagePath != "");

        }

        private void frmAddUpdatedCategory_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private bool _HandleCategoryImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Category.ImagePath != pbCategoryImage.ImageLocation)
            {
                if (_Category.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Category.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbCategoryImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbCategoryImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbCategoryImage.ImageLocation = SourceImageFile;
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

            if (!_HandleCategoryImage())
                return;


            _Category.Name = txtName.Text.Trim();

            _Category.Description = txtDescription.Text.Trim();

            if (pbCategoryImage.ImageLocation != null)
                _Category.ImagePath = pbCategoryImage.ImageLocation;
            else
                _Category.ImagePath = "";

            if (_Category.Save())
            {
                lblCategoryID.Text = _Category.CategoryID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Category.CategoryID);
                this.Close();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbCategoryImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            pbCategoryImage.ImageLocation = null;




            llRemoveImage.Visible = false;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            //change the defualt image to female incase there is no image set.
            if (pbCategoryImage.ImageLocation == null)
                pbCategoryImage.Image = Resources.Female_512;
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            //change the defualt image to male incase there is no image set.
            if (pbCategoryImage.ImageLocation == null)
                pbCategoryImage.Image = Resources.Male_512;
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
