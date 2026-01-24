namespace Restaurant
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.btnFinishedOrders = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btmPeople = new System.Windows.Forms.Button();
            this.lblRestaurantNmae = new System.Windows.Forms.Label();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnKitchenScreen = new System.Windows.Forms.Button();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrders
            // 
            this.btnOrders.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrders.Font = new System.Drawing.Font("Jokerman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrders.ForeColor = System.Drawing.Color.Red;
            this.btnOrders.Location = new System.Drawing.Point(26, 162);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(214, 118);
            this.btnOrders.TabIndex = 0;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnItems
            // 
            this.btnItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItems.Font = new System.Drawing.Font("Jokerman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItems.ForeColor = System.Drawing.Color.Red;
            this.btnItems.Location = new System.Drawing.Point(827, 163);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(215, 118);
            this.btnItems.TabIndex = 1;
            this.btnItems.Text = "Items";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnFinishedOrders
            // 
            this.btnFinishedOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinishedOrders.Font = new System.Drawing.Font("Jokerman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishedOrders.ForeColor = System.Drawing.Color.Red;
            this.btnFinishedOrders.Location = new System.Drawing.Point(491, 163);
            this.btnFinishedOrders.Name = "btnFinishedOrders";
            this.btnFinishedOrders.Size = new System.Drawing.Size(330, 118);
            this.btnFinishedOrders.TabIndex = 2;
            this.btnFinishedOrders.Text = "Finished Orders";
            this.btnFinishedOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinishedOrders.UseVisualStyleBackColor = true;
            this.btnFinishedOrders.Click += new System.EventHandler(this.btnFinishedOrders_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.Font = new System.Drawing.Font("Jokerman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.Red;
            this.btnUsers.Location = new System.Drawing.Point(1593, 162);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(260, 118);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btmPeople
            // 
            this.btmPeople.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btmPeople.Font = new System.Drawing.Font("Jokerman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmPeople.ForeColor = System.Drawing.Color.Red;
            this.btmPeople.Location = new System.Drawing.Point(1314, 163);
            this.btmPeople.Name = "btmPeople";
            this.btmPeople.Size = new System.Drawing.Size(273, 118);
            this.btmPeople.TabIndex = 4;
            this.btmPeople.Text = "People";
            this.btmPeople.UseVisualStyleBackColor = true;
            this.btmPeople.Click += new System.EventHandler(this.btmPeople_Click);
            // 
            // lblRestaurantNmae
            // 
            this.lblRestaurantNmae.AutoSize = true;
            this.lblRestaurantNmae.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblRestaurantNmae.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRestaurantNmae.Font = new System.Drawing.Font("Snap ITC", 68.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestaurantNmae.ForeColor = System.Drawing.Color.Red;
            this.lblRestaurantNmae.Location = new System.Drawing.Point(438, 23);
            this.lblRestaurantNmae.Name = "lblRestaurantNmae";
            this.lblRestaurantNmae.Size = new System.Drawing.Size(975, 117);
            this.lblRestaurantNmae.TabIndex = 5;
            this.lblRestaurantNmae.Text = "Goldyz Resturant";
            // 
            // btnCategories
            // 
            this.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.Font = new System.Drawing.Font("Jokerman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.Color.Red;
            this.btnCategories.Location = new System.Drawing.Point(1048, 163);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(260, 118);
            this.btnCategories.TabIndex = 6;
            this.btnCategories.Text = "Categories";
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnKitchenScreen
            // 
            this.btnKitchenScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKitchenScreen.Font = new System.Drawing.Font("Jokerman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKitchenScreen.ForeColor = System.Drawing.Color.Red;
            this.btnKitchenScreen.Location = new System.Drawing.Point(252, 163);
            this.btnKitchenScreen.Name = "btnKitchenScreen";
            this.btnKitchenScreen.Size = new System.Drawing.Size(214, 118);
            this.btnKitchenScreen.TabIndex = 8;
            this.btnKitchenScreen.Text = "Kitchen Screen";
            this.btnKitchenScreen.UseVisualStyleBackColor = true;
            this.btnKitchenScreen.Click += new System.EventHandler(this.btnKitchenScreen_Click);
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCurrentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.Location = new System.Drawing.Point(23, 32);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(72, 31);
            this.lblCurrentDate.TabIndex = 10;
            this.lblCurrentDate.Text = "Date";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTime.Location = new System.Drawing.Point(23, 83);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(74, 31);
            this.lblCurrentTime.TabIndex = 12;
            this.lblCurrentTime.Text = "Time";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Location = new System.Drawing.Point(1679, 69);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(72, 31);
            this.lblCurrentUser.TabIndex = 13;
            this.lblCurrentUser.Text = "User";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogOut.Location = new System.Drawing.Point(1676, 12);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(234, 35);
            this.btnLogOut.TabIndex = 14;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = global::Restaurant.Properties.Resources._813M9p5FvEL;
            this.ClientSize = new System.Drawing.Size(1922, 653);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.btnKitchenScreen);
            this.Controls.Add(this.btnCategories);
            this.Controls.Add(this.lblRestaurantNmae);
            this.Controls.Add(this.btmPeople);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnFinishedOrders);
            this.Controls.Add(this.btnItems);
            this.Controls.Add(this.btnOrders);
            this.Name = "frmMain";
            this.Text = "Main Screen";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Button btnFinishedOrders;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btmPeople;
        private System.Windows.Forms.Label lblRestaurantNmae;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnKitchenScreen;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLogOut;
    }
}

