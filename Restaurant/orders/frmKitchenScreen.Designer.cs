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
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.lblOrderItemsRecordsCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInProgressOrders)).BeginInit();
            this.cmsOrdersKitchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTitle.Location = new System.Drawing.Point(750, 9);
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
            this.dgvInProgressOrders.Size = new System.Drawing.Size(1011, 345);
            this.dgvInProgressOrders.TabIndex = 12;
            this.dgvInProgressOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInProgressOrders_CellClick);
            // 
            // cmsOrdersKitchen
            // 
            this.cmsOrdersKitchen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.setFinishToolStripMenuItem});
            this.cmsOrdersKitchen.Name = "contextMenuStrip1";
            this.cmsOrdersKitchen.Size = new System.Drawing.Size(126, 32);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(122, 6);
            // 
            // setFinishToolStripMenuItem
            // 
            this.setFinishToolStripMenuItem.Name = "setFinishToolStripMenuItem";
            this.setFinishToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.setFinishToolStripMenuItem.Text = "Set Ready";
            this.setFinishToolStripMenuItem.Click += new System.EventHandler(this.SetReadyToolStripMenuItem_Click);
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.ContextMenuStrip = this.cmsOrdersKitchen;
            this.dgvOrderItems.Location = new System.Drawing.Point(1044, 143);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.Size = new System.Drawing.Size(568, 345);
            this.dgvOrderItems.TabIndex = 16;
            // 
            // lblOrderItemsRecordsCount
            // 
            this.lblOrderItemsRecordsCount.AutoSize = true;
            this.lblOrderItemsRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderItemsRecordsCount.Location = new System.Drawing.Point(1200, 491);
            this.lblOrderItemsRecordsCount.Name = "lblOrderItemsRecordsCount";
            this.lblOrderItemsRecordsCount.Size = new System.Drawing.Size(18, 20);
            this.lblOrderItemsRecordsCount.TabIndex = 17;
            this.lblOrderItemsRecordsCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(1050, 491);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Records Count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(414, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "In Progress Orders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(1252, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Order Items";
            // 
            // frmKitchenScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1633, 544);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOrderItemsRecordsCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbllblOrdersRecordsCount);
            this.Controls.Add(this.RecordsCount);
            this.Controls.Add(this.dgvInProgressOrders);
            this.Name = "frmKitchenScreen";
            this.Text = "frmKitchenScreen";
            this.Load += new System.EventHandler(this.frmKitchenScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInProgressOrders)).EndInit();
            this.cmsOrdersKitchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Label lblOrderItemsRecordsCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}