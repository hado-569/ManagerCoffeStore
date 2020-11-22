using QuanLyQuancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuancafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance {
            get
            {
                if (instance==null)
                {
                    instance = new TableDAO();
                }
                return TableDAO.instance; }
            set { TableDAO.instance = value; }
        }

        public void SwitchTable(int id1,int id2)
        {
            DataProvider.Instance.ExcuteQuery("USP_SwitchTable @idTable1 , @idTable2 ",new object[] { id1,id2});
        }

        public static int TableWdith = 90;
        public static int TableHeight = 90;
        private TableDAO() { }
        public List<Table> LoadTBList()
        {
            List<Table> tablelist = new List<Table>();
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablelist.Add(table);
            }
            return tablelist;

        }
        public bool InsertTable(string nametable)
        {
            string query = string.Format("insert into TBFood (ten) values(N'{0} ') ",nametable );
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(int id, string namefood)
        {
            string query = string.Format("update TBFood set ten= N'{0}' where id = {1}", namefood , id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int idtable,int idbill)
        {
            
            BillInforDAO.Instance.DeleteBillinfoByBill(idbill);
            BillDAO.Instance.DeleteBillByTable(idtable);

            string query = string.Format("delete TBFood where id = {0} ", idtable);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;

        }
    }
}
