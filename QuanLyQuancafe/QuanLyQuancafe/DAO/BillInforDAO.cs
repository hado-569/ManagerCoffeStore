using QuanLyQuancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuancafe.DAO
{
   public class BillInforDAO
    {
        private static BillInforDAO instance;

        public static BillInforDAO Instance {
            get
            {
                if (instance==null)
                {
                    instance = new BillInforDAO();
                }
                return BillInforDAO.instance; }
            private set { BillInforDAO.instance = value; } }
        private BillInforDAO() { }
        public List<BillIfor> GetListBillInfor(int id)
        {
            List<BillIfor> listBillInfor = new List<BillIfor>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from Billinfor where idBill= "+id);
            foreach (DataRow item in data.Rows)
            {
                BillIfor infor = new BillIfor(item);
                listBillInfor.Add(infor);
            }
            return listBillInfor;
        }
        public void InsertBillInfo(int idbill , int idfood,int count )
        {
            DataProvider.Instance.ExcuteNonQuery(" exec USP_insertBillInfo @idBill , @idFood , @count " , new object[] { idbill , idfood, count });
        }
        public void DeleteBillinfoByFood(int id)
        {
            DataProvider.Instance.ExcuteQuery("Delete Billinfor where idFood = "+id);
        }
        public void DeleteBillinfoByBill(int id)
        {
            DataProvider.Instance.ExcuteQuery("Delete Billinfor where idBill = " + id);
        }

    }

}
