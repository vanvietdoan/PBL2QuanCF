using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DTO
{
    public class BillInfo
    {
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private int foodID;
        public int FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int idBill;
        public int ÌDBill
        {
            get { return idBill; }
            set { idBill = value; }
        }
        public BillInfo(int id,int BillID, int foodID,  int count)
        {
            this.ID = id;
            this.FoodID = foodID;
            this.idBill = BillID;
            this.Count = count;

        }
        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.ÌDBill = (int)row["idBill"];
            this.FoodID = (int)row["idfood"];
            this.Count = (int)row["count"]; 


        }
    }
}
