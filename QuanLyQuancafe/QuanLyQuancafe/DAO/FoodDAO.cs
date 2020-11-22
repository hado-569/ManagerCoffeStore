using QuanLyQuancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuancafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodDAO();
                }
                return FoodDAO.instance;
            }
            private set { FoodDAO.instance = value; }
        }
        private FoodDAO() { }

        public List<Food> GetFoodListByidCategory(int id)
        {
            List<Food> listF = new List<Food>();

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from Food where idCategory = "+id );

            foreach (DataRow item in data.Rows)
            {
                Food f = new Food(item);

                listF.Add(f);

            }

            return listF;
        }
        public List<Food> GetlistFood()
        {
            List<Food> listf = new List<Food>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from Food");
            foreach (DataRow item in data.Rows)
            {
                Food f = new Food(item);

                listf.Add(f);

            }
            return listf;
        }
        public bool InsertFood(string namefood,int idcategory,float price)
        {
            string query = string.Format("insert into Food(ten, idCategory, price) values(N'{0}', {1}, {2}) ", namefood, idcategory, price);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFood(int id,string namefood, int idcategory, float price)
        {
            string query = string.Format("update Food set ten= N'{0}', idCategory= {1}, price= {2} where id= {3}", namefood, idcategory, price, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFood(int id)
        {
            BillInforDAO.Instance.DeleteBillinfoByFood(id);

            string query = string.Format("delete Food where id = {0} ", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public List<Food> SearchFood(string name)
        {
            List<Food> listf = new List<Food>();
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("Select * from Food where ten like N'%{0}%'",name));
            foreach (DataRow item in data.Rows)
            {
                Food f = new Food(item);

                listf.Add(f);

            }
            return listf;

        }
        public void DeleteFoodByidCategory(int idcategory)
        {
            DataProvider.Instance.ExcuteQuery("delete Food where idCategory = "+ idcategory);
        }
        public int GetMaxidfood()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteSaclar("select max(id) from Food");
            }
            catch (Exception)
            {

                return 1;
            }
        }
    }
}
