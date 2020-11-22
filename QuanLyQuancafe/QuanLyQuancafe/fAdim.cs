using QuanLyQuancafe.DAO;
using QuanLyQuancafe.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyQuancafe
{
    public partial class fAdim : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource AccList = new BindingSource();
        BindingSource TableList = new BindingSource();
        BindingSource CategoryList = new BindingSource();
        public Account loginACC;
        public fAdim()
        {
            InitializeComponent();

            loadListBillBydate(DtpkCheckin.Value, dtpkCheckout.Value);
            loadDatetime();
            dtgvFood.DataSource = foodList;
            dataAccount.DataSource = AccList;
            dataFoodTable.DataSource = TableList;
            dataCategory.DataSource = CategoryList;
            loadListFood();
            loadAccount();
            LoadTableList();
            LoadDataCategory();
            CategoryBinding();
            TableBinding();
            AddFoodBinding();
            GetlistCategory(cbCategory);
            Accountbinding();
        }

        #region methods
        void loadDatetime()
        {
            DateTime today = DateTime.Now;
            DtpkCheckin.Value = new DateTime(today.Year,today.Month,1);
            dtpkCheckout.Value = DtpkCheckin.Value.AddMonths(1).AddDays(-1);
        }
        void loadListBillBydate(DateTime checkin,DateTime checkout )
        {
            DtBill.DataSource = BillDAO.Instance.GetListBillByDate(checkin,checkout);
        }

        void loadListFood()
        {

            foodList.DataSource = FoodDAO.Instance.GetlistFood();
            

        }
        void AddFoodBinding()
        {
            txtFoodname.DataBindings.Add(new Binding("Text",dtgvFood.DataSource,"NameFood",true,DataSourceUpdateMode.Never));
            TxtID.DataBindings.Add("Text",dtgvFood.DataSource,"ID", true, DataSourceUpdateMode.Never);
            nmPrice.DataBindings.Add("Text",dtgvFood.DataSource,"Price", true, DataSourceUpdateMode.Never);
        }
        void GetlistCategory(ComboBox cb)
        {
            cb.DataSource = CategoryFoodDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        //category e-handler
        private event EventHandler insertcate;
        public event EventHandler Insertcate
        {
            add { insertcate += value; }
            remove { insertcate -= value; }
        }
        private event EventHandler updatecate;
        public event EventHandler Updatecate
        {
            add { updatecate += value; }
            remove { updatecate -= value; }
        }
        private event EventHandler deletecate;
        public event EventHandler Deletecate
        {
            add { deletecate += value; }
            remove { deletecate -= value; }
        }
        List<Food> SeachFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFood(name);

            return listFood;
        }

        void Accountbinding()
        {
            TxtAccName.DataBindings.Add(new Binding("Text",dataAccount.DataSource,"UserName",true,DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding ("Text",dataAccount.DataSource,"DisplayName", true, DataSourceUpdateMode.Never));
            nmType.DataBindings.Add(new Binding("Value",dataAccount.DataSource,"Type", true, DataSourceUpdateMode.Never));
        }

        void loadAccount()
        {
            AccList.DataSource = AccountDAO.Instance.GetlistAccount();
            
        }
        void AddAccount(string name,string displayname,int type)
        {
            if (AccountDAO.Instance.InsertAccount(name, displayname, type))
            {
                MessageBox.Show("Thêm tài khoản thành công !");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm tài khoản !");
            }
            loadAccount();
        }
        void EditAccount(string name, string displayname, int type)
        {
            if (AccountDAO.Instance.UpdateACC(name, displayname, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công !");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật tài khoản !");
            }
            
            loadAccount();
        }
        void DeletaAccount(string name)
        {
            if (loginACC.UserName.Equals(name))
            {
                MessageBox.Show("Không thể xóa tài khoản này khi đang đăng nhập ! ");
                return;
            }
            if (AccountDAO.Instance.DeleteACC(name))
            {
                MessageBox.Show("Cập nhật tài khoản thành công !");
            }
            else
            {
                MessageBox.Show("Có lỗi xãy ra khi cập nhật tài khoản !");
            }
            loadAccount();
        }
        void Repassword(string username)
        {
            if (AccountDAO.Instance.RepassACC(username))
            {
                MessageBox.Show("Đặt Lại mật khẩu thành công !");
            }
            else
            {
                MessageBox.Show("Đặt Lại mật khẩu thất bại !");
            }
        }

        void LoadTableList()
        {
            TableList.DataSource = TableDAO.Instance.LoadTBList();
        }
        void TableBinding()
        {
            txtIDTBFood.DataBindings.Add("Text",dataFoodTable.DataSource, "ID", true, DataSourceUpdateMode.Never);
            txbTable.DataBindings.Add("Text", dataFoodTable.DataSource, "Name", true, DataSourceUpdateMode.Never);
            txbStatus.DataBindings.Add("Text", dataFoodTable.DataSource, "Status", true, DataSourceUpdateMode.Never);

        }
        void ADDTable(string name)
        {
            if (TableDAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Thêm bàn thành công !");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm bàn !");
            }
        }

        void EditTable(string nameTB,int idTB)
        {
            if (TableDAO.Instance.UpdateTable(idTB, nameTB))
            {
                MessageBox.Show("Cập nhật bàn thành công !");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật bàn !");
            }
        }

        void DeleteTable(int idTB,int idBill)
        {

            if (txbStatus.Text== "Có Người")
            {
                MessageBox.Show("Không thế xóa bàn khi bàn còn đang sử dụng");
                return;
            }

            if (TableDAO.Instance.DeleteTable(idTB,idBill))
            {
                MessageBox.Show("Xóa bàn thành công !");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa bàn !");
            }
            
        }
        void CategoryBinding()
        {
            txtIdCategory.DataBindings.Add("Text",dataCategory.DataSource,"Id", true, DataSourceUpdateMode.Never);
            txtCategoryName.DataBindings.Add("Text", dataCategory.DataSource, "Name", true, DataSourceUpdateMode.Never);

        }
        void LoadDataCategory()
        {
            CategoryList.DataSource = CategoryFoodDAO.Instance.GetListCategory();
        }
        void ADDcategory(string namecategory)
        {
            
            if (CategoryFoodDAO.Instance.InsertCategory(namecategory))
            {
                MessageBox.Show("Thêm danh mục thành công !");
                LoadDataCategory();
                if (insertcate != null)
                {
                    insertcate(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm danh mục bàn !");
            }
            
        }
        void EditCategory(string namecategory,int idcategory)
        {
            if (CategoryFoodDAO.Instance.UpdateCategory(idcategory, namecategory))
            {
                MessageBox.Show("Sửa danh mục thành công !");
                LoadDataCategory();
                if (insertcate != null)
                {
                    insertcate(this, new EventArgs());
                }

            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa danh mục !");

            }
            
        }
        void Deletecategory(int idcategory,int idfood )
        {
            
            if (CategoryFoodDAO.Instance.DeleteCategory(idcategory, idfood))
            {
                MessageBox.Show("Xóa danh mục thành công !");
                LoadDataCategory();
                if (insertcate != null)
                {
                    insertcate(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa danh mục !");

            }
           
        }
        #endregion

        #region events
        private void BtnReview_Click(object sender, EventArgs e)
        {
            loadListBillBydate(DtpkCheckin.Value,dtpkCheckout.Value);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            loadListFood();
            
        }
        private void TxtID_TextChanged(object sender, EventArgs e)
        {
            
            if (dtgvFood.SelectedCells.Count>0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
                Category category = CategoryFoodDAO.Instance.GetCategoryByID(id);
                cbCategory.SelectedItem = category;
                int index = -1;
                int i = 0;

                foreach (Category item in cbCategory.Items)
                {
                    if (item.Id == category.Id)
                    {
                        index = i;
                        break;
                    }
                    i++;

                }
                cbCategory.SelectedIndex = index;

            }

        }

        private void btn_insertfood(object sender, EventArgs e)
        {
            string namefood = txtFoodname.Text;
            int idfood = Convert.ToInt32(TxtID.Text );
            int categoryid = (cbCategory.SelectedItem as Category).Id;
            float price = (float)nmPrice.Value;
            
            if (FoodDAO.Instance.InsertFood(namefood, categoryid, price))
            {
                MessageBox.Show("Thêm món thành công");
                loadListFood();
                if (insertFood!=null)
                {
                    insertFood(this,new EventArgs());
                }

            }
            else
            {
                MessageBox.Show("Xảy ra lỗi trong qua trình thêm món ! ");
            }
        }
        private void EditFood_Click(object sender, EventArgs e)
        {
            string namefood = txtFoodname.Text;
            int idfood = Convert.ToInt32(TxtID.Text);
            int categoryid = (cbCategory.SelectedItem as Category).Id;
            float price = (float)nmPrice.Value;

            if (FoodDAO.Instance.UpdateFood(idfood,namefood,categoryid,price))
            {
                MessageBox.Show("Cập nhật món thành công");
                loadListFood();
                if (updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xảy ra lỗi trong qua trình cập nhật món ! ");
            }
        }
        private void DeleteFood_Click(object sender, EventArgs e)
        {
            int idfood = Convert.ToInt32(TxtID.Text);
            if (FoodDAO.Instance.DeleteFood(idfood))
            {
                MessageBox.Show("Xóa món thành công");
                loadListFood();
                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xảy ra lỗi trong qua trình xóa món ! ");
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            
            foodList.DataSource= SeachFoodByName(TXTsearchFood.Text);
        }
        private void btn_ShowACC(object sender, EventArgs e)
        {
            loadAccount();
        }
        private void Btn_addacc_Click(object sender, EventArgs e)
        {
            string username = TxtAccName.Text;
            string displayname = txtDisplayName.Text;
            int type = (int)nmType.Value;
            AddAccount(username, displayname, type);
        }

        private void Btn_deleteacc_Click(object sender, EventArgs e)
        {
            string username = TxtAccName.Text;
            DeletaAccount(username);

        }

        private void Btn_editacc_Click(object sender, EventArgs e)
        {
            string username = TxtAccName.Text;
            string displayname = txtDisplayName.Text;
            int type = (int)nmType.Value;
            EditAccount(username, displayname, type);
        }

        private void BtnResetPass_Click(object sender, EventArgs e)
        {
            string username = TxtAccName.Text;
            Repassword(username);
        }
        private void BtnShowtablefood_Click(object sender, EventArgs e)
        {
            LoadTableList();
        }

        private void BtnADDtablefood_Click(object sender, EventArgs e)
        {
            string nameTB = txbTable.Text;
            ADDTable(nameTB);
            LoadTableList();
        }

        private void BtnDEltablefood_Click(object sender, EventArgs e)
        {
            
            int idTB = Convert.ToInt32(txtIDTBFood.Text);
            int idBill = BillDAO.Instance.GETMAXID();
            DeleteTable(idTB,idBill);
            LoadTableList();
        }

        private void BtnEdittablefood_Click(object sender, EventArgs e)
        {
            string nameTB = txbTable.Text;
            int idTB = Convert.ToInt32(txtIDTBFood.Text);
            EditTable(nameTB,idTB);
            LoadTableList();
        }
        private void BtnADDCate_Click(object sender, EventArgs e)
        {
            string namecategory = txtCategoryName.Text;
            int idcategory = Convert.ToInt32(txtIdCategory.Text);
            ADDcategory(namecategory);
            LoadDataCategory();
        }

        private void BtnDELcate_Click(object sender, EventArgs e)
        {
            int idcategory = Convert.ToInt32(txtIdCategory.Text);
            int idfood = FoodDAO.Instance.GetMaxidfood();
            Deletecategory(idcategory, idfood);
            LoadDataCategory();
        }

        private void BtnEditCate_Click(object sender, EventArgs e)
        {
            string namecategory = txtCategoryName.Text;
            int idcategory = Convert.ToInt32(txtIdCategory.Text);
            EditCategory(namecategory, idcategory);
            LoadDataCategory();
        }

        private void BtnShowcate_Click(object sender, EventArgs e)
        {
            LoadDataCategory();
            
        }


        #endregion

        
    }
}
