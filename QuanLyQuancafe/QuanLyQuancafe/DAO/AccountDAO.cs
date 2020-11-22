using QuanLyQuancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuancafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance {
            get
            {
                if (instance==null)
                {
                    instance = new AccountDAO();
                }
                return AccountDAO.instance; }
            private set { AccountDAO.instance = value; } }
        private AccountDAO() { }

        public bool Login (string userName,string passWord)
        {
            string query = " USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExcuteQuery(query,new object[] { userName,passWord});

            return result.Rows.Count>0;
        }

        public Account GetAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from Acc where Username =  '"+username+"'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;

        }
        public bool UpdateAccount(string username,string displayname,string pass,string newpass)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("exec USP_updateACC @username , @displayname , @password  , @newpass ",new object[] {  username, displayname,  pass,  newpass });

            return result > 0;
        }
        public DataTable GetlistAccount()
        {
            return DataProvider.Instance.ExcuteQuery("select Username,DisplayName,type from Acc");
            
        }
        public bool InsertAccount(string name, string diplayname, int type )
        {
            string query = string.Format("insert into Acc (UserName, DisplayName, type) values(N'{0}', N'{1}', {2}) ", name, diplayname, type);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateACC(string name, string diplayname, int type)
        {
            string query = string.Format("update Acc set DisplayName= N'{1}', type= {2} where UserName= N'{0}'", name, diplayname, type);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteACC(string name)
        {
            string query = string.Format("delete Acc where UserName= N'{0}' ", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool RepassACC(string name)
        {
            string query = string.Format("update Acc set PassWord = N'0' where UserName= N'{0}' ", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

    }
}
