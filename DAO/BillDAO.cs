using PBL2QuanCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DAO
{
    internal class BillDAO
    {
        private static BillDAO instacne;
        public static BillDAO Instacne
        {
            get
            {
                if (instacne == null)
                    instacne = new BillDAO();
                return BillDAO.instacne;
            }
            private set { BillDAO.instacne = value; }
        }
        private BillDAO() { }
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable dt = DataProvider.Instacne.ExecuteQuery("SELECT * From Bill WHERE idTable = "+id+" AND status =0");
            if(dt.Rows.Count > 0)
            {
                Bill bill = new Bill(dt.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void InsertBill(int id)
        {
            DataProvider.Instacne.ExecuteQuery("EXEC USP_InsertBill @idTable", new object[] { id });
        }
    }
}
