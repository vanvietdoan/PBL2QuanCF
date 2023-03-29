﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DTO
{
    public class Menu
    {
     
        private string foodName;
        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private float totalprice;
        public float TotalPrice
        {
            get { return totalprice; }
            set { totalprice = value; }
        }
        public Menu(string foodName, int count, float price, float totalprice =0) 
        {
            this.FoodName = foodName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalprice;

        }
        public Menu(DataRow row)
        {
            this.FoodName = row["Name"].ToString();
            this.Count = (int)row["count"];
            this.Price =(float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalprice"].ToString());

        }

    }
}
