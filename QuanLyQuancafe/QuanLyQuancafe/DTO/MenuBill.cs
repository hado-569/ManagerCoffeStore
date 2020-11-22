using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuancafe.DTO
{
    public class MenuBill
    {
        private string nameFood;
        private int count;
        private float price;
        private float totalPrice;

        public string NameFood { get => nameFood; set => nameFood = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

        public MenuBill(string namefood, int count, float price, float totalprice = 0)
        {
            this.NameFood = namefood;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalprice;

        }
        public MenuBill(DataRow row)
        {
            this.NameFood = row["ten"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
    }
}
