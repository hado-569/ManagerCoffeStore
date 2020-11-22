using QuanLyQuancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuancafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance {
            get
            {
                if (instance==null)
                {
                    instance = new MenuDAO();
                }
                return MenuDAO.instance; }
            private set { MenuDAO.instance = value; } }
        private MenuDAO() { }

        public List<MenuBill> GetListMenuByTable(int id )
        {

            List<MenuBill> listMenu = new List<MenuBill>();
            string query = "select f.ten,bi.count,f.price,f.price*bi.count as totalPrice from Billinfor as bi , Bill as b , Food as f where bi.idBill = b.id and bi.idFood = f.id and b.status=0 and b.idTable = "+id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows )
            {
                MenuBill m = new MenuBill(item);
                listMenu.Add(m);
            }
            return listMenu;

        }
    }
}
