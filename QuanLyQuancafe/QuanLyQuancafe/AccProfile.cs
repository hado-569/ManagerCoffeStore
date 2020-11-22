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
    public partial class AccProfile : Form
    {
        private Account loginacc;
        public AccProfile(Account acc)
        {
            InitializeComponent();
            Loginacc = acc;

        }
        void UpdateAcc()
        {
            string dispalyname = txtDisplayName.Text;
            string pass = txtPass.Text;
            string newpass = txtNewPass.Text;
            string renewPass = txtReNewPass.Text;
            string username = Txlogin.Text;

            if (newpass.Equals(renewPass))
            {
                MessageBox.Show("Hãy nhập lại mật khẩu !");

            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(username, dispalyname, pass, renewPass))
                {
                    MessageBox.Show("Cập nhật thành công ! ");
                    if (updateAcc!= null)
                    {
                        updateAcc(this, new AccEvent(AccountDAO.Instance.GetAccountByUserName(username)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu !");
                }
            }
        }
        private event EventHandler<AccEvent> updateAcc;
        public event EventHandler<AccEvent> UpdateAccount
        {
            add { updateAcc += value; }
            remove { updateAcc -= value; }
        }
        
            
        void ChangeACC(Account acc)
        {
            Txlogin.Text = Loginacc.UserName;
            txtDisplayName.Text = Loginacc.DisplayName;
        }
        public Account Loginacc { get => loginacc;
            set { loginacc = value; ChangeACC(loginacc); } }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAcc();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class AccEvent : EventArgs
    {
        private Account acc;
        public AccEvent(Account acc)
        {
            this.Acc = acc;
        }

        public Account Acc { get => acc; set => acc = value; }
    }
}
