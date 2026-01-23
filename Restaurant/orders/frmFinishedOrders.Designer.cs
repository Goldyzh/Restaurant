namespace Restaurant.orders
{
    partial class frmFinishedOrders
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.lbllblOrdersRecordsCount = new System.Windows.Forms.Label();
            this.RecordsCount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 160);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(1051, 345);
            this.dgvOrders.TabIndex = 0;
            // 
            // lbllblOrdersRecordsCount
            // 
            this.lbllblOrdersRecordsCount.AutoSize = true;
            this.lbllblOrdersRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllblOrdersRecordsCount.Location = new System.Drawing.Point(166, 508);
            this.lbllblOrdersRecordsCount.Name = "lbllblOrdersRecordsCount";
            this.lbllblOrdersRecordsCount.Size = new System.Drawing.Size(18, 20);
            this.lbllblOrdersRecordsCount.TabIndex = 8;
            this.lbllblOrdersRecordsCount.Text = "0";
            // 
            // RecordsCount
            // 
            this.RecordsCount.AutoSize = true;
            this.RecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordsCount.ForeColor = System.Drawing.Color.DimGray;
            this.RecordsCount.Location = new System.Drawing.Point(12, 508);
            this.RecordsCount.Name = "RecordsCount";
            this.RecordsCount.Size = new System.Drawing.Size(134, 20);
            this.RecordsCount.TabIndex = 9;
            this.RecordsCount.Text = "Records Count:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTitle.Location = new System.Drawing.Point(407, 50);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(222, 31);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Finished Orders";
            // 
            // frmFinishedOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 556);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbllblOrdersRecordsCount);
            this.Controls.Add(this.RecordsCount);
            this.Controls.Add(this.dgvOrders);
            this.Name = "frmFinishedOrders";
            this.Text = "frmFinishedOrders";
            this.Load += new System.EventHandler(this.frmFinishedOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label lbllblOrdersRecordsCount;
        private System.Windows.Forms.Label RecordsCount;
        private System.Windows.Forms.Label lblTitle;
    }
}