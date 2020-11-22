using QuanLyQuancafe.DAO;
using QuanLyQuancafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuancafe
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            string userName= Txlogin.Text;
            string passWord= txtPass.Text;
            if (Login(userName,passWord))
            {
                Account loginAcc = AccountDAO.Instance.GetAccountByUserName(userName);
            fQuanlyCaFe f = new fQuanlyCaFe(loginAcc);

                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai Ten Tai Khoan Hoac Mat Khau ! ");
            }


        }

        bool Login(string userName,string passWord)
        {
            return AccountDAO.Instance.Login(userName,passWord) ;

        }
        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban co muon thoat chuong trinh ! ","Thong Bao ",MessageBoxButtons.OKCancel)!= System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
