using QuanLyQuancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuancafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance {
            get
            {
                if (instance==null)
                {
                    instance = new BillDAO();
                }
                return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        public int GetUnCheckBillBYTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from Bill where idTable= "+id+"and status = 0");
            if (data.Rows.Count>0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
           ;
        }
        public void InsertBill(int id )
        {
            DataProvider.Instance.ExcuteNonQuery("exec USP_insertBill @idTable ", new object[] { id});
        }

        public int GETMAXID()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteSaclar("select max(id) from Bill");
            }
            catch (Exception)
            {

                return 1;
            }
        }

        public void CheckOut(int id,int discount,float totalPrice)
        {
            string query = "update Bill Set Datecheckout = GETDATE() , status = 1, " + " Discount = " +discount + ", totalPrice = "+ totalPrice + " where id = "+id ;
            DataProvider.Instance.ExcuteNonQuery(query);

        }

        public DataTable GetListBillByDate(DateTime checkin,DateTime checkout)
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_GetListBillByDate @Checkin , @Checkout ",new object[] { checkin,checkout});
        }

        public void DeleteBillByTable(int id)
        {

            DataProvider.Instance.ExcuteQuery("Delete Bill where idTable = " + id);
        }
    }
}
