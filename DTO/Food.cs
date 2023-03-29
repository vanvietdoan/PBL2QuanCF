﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DTO
{
    public class Food
    {
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int categoryID;
        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }
        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public Food( int iD, string name, int categoryID, float price)
        {
            this.ID = iD;
            
            this.Name = name;
           
            this.CategoryID = categoryID;
          
            this.Price = price;
        }
        public Food(DataRow row)
        {
            this.ID = (int)row["iD"];

            this.Name = row["Name"].ToString();
            this.CategoryID = (int)row["IDcategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            
        }
    }
}