using QuanLyQuancafe.DAO;
using QuanLyQuancafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuancafe
{
    public partial class fQuanlyCaFe : Form
    {
        private Account loginacc;

        public Account Loginacc {
            get => loginacc;
            set { loginacc = value;changeACC(loginacc.Type); }
           
        }

        public fQuanlyCaFe(Account acc)

        {


            InitializeComponent();

            this.Loginacc = acc;
            LoadTable();
            LoadCategory();
            LoadCBTable(cbSwitch);
        }

        #region Method
        void changeACC(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += "("+loginacc.DisplayName+")";
        }
         void LoadCategory()
        {
            List<Category> listCategory = CategoryFoodDAO.Instance.GetListCategory();
            cbFoodCategory.DataSource = listCategory;
            cbFoodCategory.DisplayMember = "Name";
            


        }

        void LoadFoodList(int id)
        {
            List<Food> lisftFood = FoodDAO.Instance.GetFoodListByidCategory(id);
            cbFood.DataSource = lisftFood;
            cbFood.DisplayMember = "NameFood";
            
        }
         void LoadTable()
        {
            Flowpnl.Controls.Clear();
           List<Table> table =TableDAO.Instance.LoadTBList();
            foreach (Table item in table)
            {
                Button btn = new Button() { Width = TableDAO.TableWdith, Height = TableDAO.TableHeight };
                btn.Text = item.Name +"\n" +item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Brown;
                    break;
                    default:
                        btn.BackColor = Color.Pink;
                        break;
                }
                Flowpnl.Controls.Add(btn);
            }
        }
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<MenuBill> listBillInfor = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            
            foreach (MenuBill  item in listBillInfor)
            {
                ListViewItem lsvitem = new ListViewItem(item.NameFood.ToString());
                lsvitem.SubItems.Add(item.Count.ToString());
                lsvitem.SubItems.Add(item.Price.ToString());
                lsvitem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;


                lsvBill.Items.Add(lsvitem);
            }

            CultureInfo c = new CultureInfo("vi-VN");

            Thread.CurrentThread.CurrentCulture = c;
            txtTotalPrice.Text = totalPrice.ToString("c", c);

        }

        void LoadCBTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTBList();
            cb.DisplayMember = "Name";
        }

        #endregion

        #region Event
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void btndiscount(object sender, EventArgs e)
        {

        }

        private void ThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccProfile acc = new AccProfile(loginacc);
            acc.UpdateAccount += Acc_UpdateAccount;
            acc.ShowDialog();
           
           
        }

        private void Acc_UpdateAccount(object sender, AccEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void AdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdim adim = new fAdim();
            adim.loginACC = Loginacc;
            adim.InsertFood += Adim_InsertFood;
            adim.UpdateFood += Adim_UpdateFood;
            adim.DeleteFood += Adim_DeleteFood;

            adim.Insertcate += Adim_Insertcate;
            adim.Updatecate += Adim_Updatecate;
            adim.Deletecate += Adim_Deletecate;
            
            adim.ShowDialog();

        }

        private void Adim_Deletecate(object sender, EventArgs e)
        {

            LoadCategory();
            LoadFoodList((cbFoodCategory.SelectedItem as Category).Id);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        private void Adim_Updatecate(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodList((cbFoodCategory.SelectedItem as Category).Id);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        private void Adim_Insertcate(object sender, EventArgs e)
        {
            
            LoadCategory();
            LoadFoodList((cbFoodCategory.SelectedItem as Category).Id);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        private void Adim_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodList( (cbFoodCategory.SelectedItem as Category).Id);
            if (lsvBill.Tag!=null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
            
        }

        private void Adim_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodList((cbFoodCategory.SelectedItem as Category).Id);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        private void Adim_InsertFood(object sender, EventArgs e)
        {
            LoadFoodList((cbFoodCategory.SelectedItem as Category).Id);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        private void CbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem ==null)
            {
                return;

            }
           
            Category selcted = cb.SelectedItem as Category;
            id = selcted.Id;
            LoadFoodList(id);
        }
        private void BtnADD_Click(object sender, EventArgs e)
        {
            try
            {

            
            Table table = lsvBill.Tag as Table;
                if (table ==null)
                {
                MessageBox.Show("Xin hãy chọn bàn trước");
                }
            int idBill = BillDAO.Instance.GetUnCheckBillBYTableID(table.ID);
            int idFood = (cbFood.SelectedItem as Food).Id;
            int count = (int)nmADD.Value;

            if (idBill==-1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInforDAO.Instance.InsertBillInfo(BillDAO.Instance.GETMAXID(), idFood, count );
            }
            else
            {
                BillInforDAO.Instance.InsertBillInfo(idBill, idFood, count);
            }
            ShowBill(table.ID);
            LoadTable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnThanhtoan_Click(object sender, EventArgs e)
        {

            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUnCheckBillBYTableID(table.ID);
            int discount = (int)nmDiscount.Value;
            
            double totalPrice =  Convert.ToDouble(txtTotalPrice.Text.Split(',')[0]);
            double totalPriceDiscount = totalPrice - (totalPrice/100)*discount;
            
            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc muốn thanh toán cho bàn {0}\n Tổng Tiền là : {1} Nghìn Đồng\n Tổng Tiền sau khi giảm giá {3} % , là : {2} Nghìn Đồng", table.Name,totalPrice,totalPriceDiscount,discount ) ," Thông Báo ",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill,discount,(float)totalPriceDiscount);
                    ShowBill(table.ID);
                    LoadTable();
                }
            }
        }

        private void BtnChangeTable_Click(object sender, EventArgs e)
        {

            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbSwitch.SelectedItem as Table).ID;
            if (MessageBox.Show("Bạn có chắc muốn chuyển "+ (lsvBill.Tag as Table).Name + " bàn "+ (cbSwitch.SelectedItem as Table).Name ,"Thông Báo",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
            }
            


            LoadTable();
        }

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
    }
}
