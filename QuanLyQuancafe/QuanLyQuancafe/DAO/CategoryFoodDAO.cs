using QuanLyQuancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuancafe.DAO
{
    public class CategoryFoodDAO
    {
        private static CategoryFoodDAO instance;

        public static CategoryFoodDAO Instance {
            get {
                if (instance==null)
                {
                    instance = new CategoryFoodDAO();
                }
                return CategoryFoodDAO.instance; }
            private set { CategoryFoodDAO.instance = value; } }
        private CategoryFoodDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> List = new List<Category>();

            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from FoodCategory ");
            foreach (DataRow item in data.Rows)
            {
                Category c = new Category(item);

                List.Add(c);
            }

            return List;
        }
        public Category GetCategoryByID(int id)
        {
            Category category = null;

            DataTable data = DataProvider.Instance.ExcuteQuery("select * from FoodCategory where id = "+id);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;

            }
            return category;
        }
        public bool InsertCategory(string namecategory)
        {
            string query = string.Format("insert into FoodCategory (namefood) values(N'{0} ') ", namecategory);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateCategory(int idcategory , string namecategory)
        {
            string query = string.Format("update FoodCategory set namefood = N'{0}' where id = {1}", namecategory, idcategory);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCategory(int idcategory, int idfood)
        {

            BillInforDAO.Instance.DeleteBillinfoByFood(idfood);
            FoodDAO.Instance.DeleteFoodByidCategory(idcategory);

            string query = string.Format("delete FoodCategory where id = {0} ", idcategory);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;

        }

    }
}
