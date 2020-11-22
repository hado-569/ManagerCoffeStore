namespace QuanLyQuancafe
{
    partial class fQuanlyCaFe
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Flowpnl = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.nmDiscount = new System.Windows.Forms.NumericUpDown();
            this.cbSwitch = new System.Windows.Forms.ComboBox();
            this.btnChangeTable = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThanhtoan = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmADD = new System.Windows.Forms.NumericUpDown();
            this.btnADD = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbFoodCategory = new System.Windows.Forms.ComboBox();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Flowpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmADD)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(896, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.AdminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin Tài khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.ThôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Flowpnl);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 421);
            this.panel1.TabIndex = 1;
            // 
            // Flowpnl
            // 
            this.Flowpnl.AutoScroll = true;
            this.Flowpnl.Controls.Add(this.dataGridView1);
            this.Flowpnl.Location = new System.Drawing.Point(3, 5);
            this.Flowpnl.Name = "Flowpnl";
            this.Flowpnl.Size = new System.Drawing.Size(462, 406);
            this.Flowpnl.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(387, 0);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(496, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 268);
            this.panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(4, 0);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(393, 265);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 143;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số Lượng";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn Giá";
            this.columnHeader3.Width = 78;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành Tiền";
            this.columnHeader4.Width = 74;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtTotalPrice);
            this.panel3.Controls.Add(this.nmDiscount);
            this.panel3.Controls.Add(this.cbSwitch);
            this.panel3.Controls.Add(this.btnChangeTable);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnThanhtoan);
            this.panel3.Location = new System.Drawing.Point(496, 373);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 75);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(196, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thành Tiền";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.Location = new System.Drawing.Point(194, 41);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(121, 22);
            this.txtTotalPrice.TabIndex = 5;
            // 
            // nmDiscount
            // 
            this.nmDiscount.Location = new System.Drawing.Point(98, 44);
            this.nmDiscount.Name = "nmDiscount";
            this.nmDiscount.Size = new System.Drawing.Size(75, 20);
            this.nmDiscount.TabIndex = 4;
            this.nmDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbSwitch
            // 
            this.cbSwitch.FormattingEnabled = true;
            this.cbSwitch.Location = new System.Drawing.Point(4, 44);
            this.cbSwitch.Name = "cbSwitch";
            this.cbSwitch.Size = new System.Drawing.Size(88, 21);
            this.cbSwitch.TabIndex = 4;
            // 
            // btnChangeTable
            // 
            this.btnChangeTable.Location = new System.Drawing.Point(4, 9);
            this.btnChangeTable.Name = "btnChangeTable";
            this.btnChangeTable.Size = new System.Drawing.Size(88, 22);
            this.btnChangeTable.TabIndex = 2;
            this.btnChangeTable.Text = "Chuyển Bàn";
            this.btnChangeTable.UseVisualStyleBackColor = true;
            this.btnChangeTable.Click += new System.EventHandler(this.BtnChangeTable_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Giảm Giá";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btndiscount);
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.Location = new System.Drawing.Point(321, 9);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(75, 63);
            this.btnThanhtoan.TabIndex = 0;
            this.btnThanhtoan.Text = "Thanh Toán";
            this.btnThanhtoan.UseVisualStyleBackColor = true;
            this.btnThanhtoan.Click += new System.EventHandler(this.BtnThanhtoan_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmADD);
            this.panel4.Controls.Add(this.btnADD);
            this.panel4.Controls.Add(this.cbFood);
            this.panel4.Controls.Add(this.cbFoodCategory);
            this.panel4.Location = new System.Drawing.Point(496, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(399, 59);
            this.panel4.TabIndex = 4;
            // 
            // nmADD
            // 
            this.nmADD.Location = new System.Drawing.Point(321, 19);
            this.nmADD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmADD.Name = "nmADD";
            this.nmADD.Size = new System.Drawing.Size(67, 20);
            this.nmADD.TabIndex = 3;
            this.nmADD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnADD
            // 
            this.btnADD.Location = new System.Drawing.Point(240, 3);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(75, 48);
            this.btnADD.TabIndex = 2;
            this.btnADD.Text = "Thêm Món";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.BtnADD_Click);
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(3, 30);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(220, 21);
            this.cbFood.TabIndex = 1;
            // 
            // cbFoodCategory
            // 
            this.cbFoodCategory.FormattingEnabled = true;
            this.cbFoodCategory.Location = new System.Drawing.Point(3, 3);
            this.cbFoodCategory.Name = "cbFoodCategory";
            this.cbFoodCategory.Size = new System.Drawing.Size(220, 21);
            this.cbFoodCategory.TabIndex = 0;
            this.cbFoodCategory.SelectedIndexChanged += new System.EventHandler(this.CbFoodCategory_SelectedIndexChanged);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.ĐăngXuấtToolStripMenuItem_Click);
            // 
            // fQuanlyCaFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 460);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fQuanlyCaFe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Quán Coffe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Flowpnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmADD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel Flowpnl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnChangeTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnThanhtoan;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nmADD;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbFoodCategory;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.ComboBox cbSwitch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
    }
}