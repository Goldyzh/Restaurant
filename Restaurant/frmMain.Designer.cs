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
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnFinishedOrders = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btmPeople = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrders
            // 
            this.btnOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrders.Font = new System.Drawing.Font("Jokerman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrders.ForeColor = System.Drawing.Color.Red;
            this.btnOrders.Location = new System.Drawing.Point(260, 70);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(192, 118);
            this.btnOrders.TabIndex = 0;
            this.btnOrders.Text = "Orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Font = new System.Drawing.Font("Jokerman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.Red;
            this.btnMenu.Location = new System.Drawing.Point(538, 70);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(192, 118);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = " Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            // 
            // btnFinishedOrders
            // 
            this.btnFinishedOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinishedOrders.Font = new System.Drawing.Font("Jokerman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishedOrders.ForeColor = System.Drawing.Color.Red;
            this.btnFinishedOrders.Location = new System.Drawing.Point(260, 249);
            this.btnFinishedOrders.Name = "btnFinishedOrders";
            this.btnFinishedOrders.Size = new System.Drawing.Size(192, 118);
            this.btnFinishedOrders.TabIndex = 2;
            this.btnFinishedOrders.Text = "Finished Orders";
            this.btnFinishedOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinishedOrders.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.Font = new System.Drawing.Font("Jokerman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.Red;
            this.btnUsers.Location = new System.Drawing.Point(538, 248);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(192, 118);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            // 
            // btmPeople
            // 
            this.btmPeople.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btmPeople.Font = new System.Drawing.Font("Jokerman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmPeople.ForeColor = System.Drawing.Color.Red;
            this.btmPeople.Location = new System.Drawing.Point(390, 404);
            this.btmPeople.Name = "btmPeople";
            this.btmPeople.Size = new System.Drawing.Size(192, 118);
            this.btmPeople.TabIndex = 4;
            this.btmPeople.Text = "People";
            this.btmPeople.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1100, 591);
            this.Controls.Add(this.btmPeople);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnFinishedOrders);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnOrders);
            this.Name = "frmMain";
            this.Text = "Main Screen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnFinishedOrders;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btmPeople;
    }
}

