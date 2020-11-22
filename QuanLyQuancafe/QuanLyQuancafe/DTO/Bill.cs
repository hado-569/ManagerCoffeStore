using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuancafe.DTO
{
    public class Bill
    {
        private int id;
        private DateTime? dateCheckin;
        private DateTime? dateCheckOut;
        private int satus;
        private int discount;
        public Bill(int id ,DateTime? dateCheckin,DateTime?dateCheckOut,int satus,int discount)
        {
            this.Id = id;
            this.DateCheckin = dateCheckin;
            this.DateCheckOut = dateCheckOut;
            this.Satus = satus;
            this.Discount = discount;

        }
        public Bill(DataRow row)
        {
            this.Id = (int)row["id"];
            this.DateCheckin = (DateTime?)row["dateCheckin"];
            var dateCheckOutTemp= row["dateCheckOut"];
            if (dateCheckOutTemp.ToString()!= "")
            {
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            }

            this.Satus = (int)row["status"];
            if (row["Discount"].ToString()!="")
            {
                this.Discount = (int)row["Discount"];
            }
            
        }

        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckin { get => dateCheckin; set => dateCheckin = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Satus { get => satus; set => satus = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
