namespace Restaurant.orders
{
    partial class frmKitchenScreen
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbllblOrdersRecordsCount = new System.Windows.Forms.Label();
            this.RecordsCount = new System.Windows.Forms.Label();
            this.dgvInProgressOrders = new System.Windows.Forms.DataGridView();
            this.cmsOrdersKitchen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.setFinishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInProgressOrders)).BeginInit();
            this.cmsOrdersKitchen.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTitle.Location = new System.Drawing.Point(423, 45);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(212, 31);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "Kitchen Screen";
            // 
            // lbllblOrdersRecordsCount
            // 
            this.lbllblOrdersRecordsCount.AutoSize = true;
            this.lbllblOrdersRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllblOrdersRecordsCount.Location = new System.Drawing.Point(172, 491);
            this.lbllblOrdersRecordsCount.Name = "lbllblOrdersRecordsCount";
            this.lbllblOrdersRecordsCount.Size = new System.Drawing.Size(18, 20);
            this.lbllblOrdersRecordsCount.TabIndex = 13;
            this.lbllblOrdersRecordsCount.Text = "0";
            // 
            // RecordsCount
            // 
            this.RecordsCount.AutoSize = true;
            this.RecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordsCount.ForeColor = System.Drawing.Color.DimGray;
            this.RecordsCount.Location = new System.Drawing.Point(18, 491);
            this.RecordsCount.Name = "RecordsCount";
            this.RecordsCount.Size = new System.Drawing.Size(134, 20);
            this.RecordsCount.TabIndex = 14;
            this.RecordsCount.Text = "Records Count:";
            // 
            // dgvInProgressOrders
            // 
            this.dgvInProgressOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInProgressOrders.ContextMenuStrip = this.cmsOrdersKitchen;
            this.dgvInProgressOrders.Location = new System.Drawing.Point(18, 143);
            this.dgvInProgressOrders.Name = "dgvInProgressOrders";
            this.dgvInProgressOrders.Size = new System.Drawing.Size(1051, 345);
            this.dgvInProgressOrders.TabIndex = 12;
            // 
            // cmsOrdersKitchen
            // 
            this.cmsOrdersKitchen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.setFinishToolStripMenuItem});
            this.cmsOrdersKitchen.Name = "contextMenuStrip1";
            this.cmsOrdersKitchen.Size = new System.Drawing.Size(181, 54);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // setFinishToolStripMenuItem
            // 
            this.setFinishToolStripMenuItem.Name = "setFinishToolStripMenuItem";
            this.setFinishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setFinishToolStripMenuItem.Text = "Set Ready";
            this.setFinishToolStripMenuItem.Click += new System.EventHandler(this.SetReadyToolStripMenuItem_Click);
            // 
            // frmKitchenScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 544);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbllblOrdersRecordsCount);
            this.Controls.Add(this.RecordsCount);
            this.Controls.Add(this.dgvInProgressOrders);
            this.Name = "frmKitchenScreen";
            this.Text = "frmKitchenScreen";
            this.Load += new System.EventHandler(this.frmKitchenScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInProgressOrders)).EndInit();
            this.cmsOrdersKitchen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lbllblOrdersRecordsCount;
        private System.Windows.Forms.Label RecordsCount;
        private System.Windows.Forms.DataGridView dgvInProgressOrders;
        private System.Windows.Forms.ContextMenuStrip cmsOrdersKitchen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem setFinishToolStripMenuItem;
    }
}