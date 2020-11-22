using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuancafe.DTO
{
    public class Food
    {
        private int id;
        private string nameFood;
        private int idCategory;
        private float price;

        public Food(int id ,string nameFood,int idcategory,float price)
        {
            this.Id = id;
            this.NameFood = nameFood;
            this.IdCategory = idcategory;
            this.Price = price;

        }

        public Food(DataRow row)
        {
            this.Id = (int)row["id"];
            this.NameFood = row["ten"].ToString();
            this.IdCategory = (int)row["idcategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString()) ;

        }

        public int Id { get => id; set => id = value; }
        public string NameFood { get => nameFood; set => nameFood = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}
