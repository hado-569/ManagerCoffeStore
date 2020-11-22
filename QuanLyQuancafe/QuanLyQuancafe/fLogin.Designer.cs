namespace QuanLyQuancafe
{
    partial class fLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtExit = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnllogin = new System.Windows.Forms.Panel();
            this.Txlogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnllogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtExit);
            this.panel1.Controls.Add(this.btLogin);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pnllogin);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 201);
            this.panel1.TabIndex = 0;
            // 
            // BtExit
            // 
            this.BtExit.Location = new System.Drawing.Point(363, 164);
            this.BtExit.Name = "BtExit";
            this.BtExit.Size = new System.Drawing.Size(112, 23);
            this.BtExit.TabIndex = 4;
            this.BtExit.Text = "Thoát";
            this.BtExit.UseVisualStyleBackColor = true;
            this.BtExit.Click += new System.EventHandler(this.BtExit_Click);
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(3, 164);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(112, 23);
            this.btLogin.TabIndex = 3;
            this.btLogin.Text = "Đăng Nhập";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.BtLogin_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtPass);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 64);
            this.panel2.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(179, 23);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(207, 20);
            this.txtPass.TabIndex = 2;
            this.txtPass.Text = "1";
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật Khẩu :";
            // 
            // pnllogin
            // 
            this.pnllogin.Controls.Add(this.Txlogin);
            this.pnllogin.Controls.Add(this.label1);
            this.pnllogin.Location = new System.Drawing.Point(3, 3);
            this.pnllogin.Name = "pnllogin";
            this.pnllogin.Size = new System.Drawing.Size(472, 64);
            this.pnllogin.TabIndex = 0;
            // 
            // Txlogin
            // 
            this.Txlogin.Location = new System.Drawing.Point(179, 22);
            this.Txlogin.Name = "Txlogin";
            this.Txlogin.Size = new System.Drawing.Size(207, 20);
            this.Txlogin.TabIndex = 1;
            this.Txlogin.Text = "h";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Đăng Nhập :";
            // 
            // fLogin
            // 
            this.AcceptButton = this.btLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 224);
            this.Controls.Add(this.panel1);
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FLogin_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnllogin.ResumeLayout(false);
            this.pnllogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtExit;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnllogin;
        private System.Windows.Forms.TextBox Txlogin;
        private System.Windows.Forms.Label label1;
    }
}

