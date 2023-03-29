using PBL2QuanCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instacne;
        public static BillInfoDAO Instacne
        {
            get
            {
                if (instacne == null)
                    instacne = new BillInfoDAO();
                return BillInfoDAO.instacne;
            }
            private set { BillInfoDAO.instacne = value; }
        }
        private BillInfoDAO() { }
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> list = new List<BillInfo>();
            DataTable data = DataProvider.Instacne.ExecuteQuery(" SELECT *FROM BillInfo WHERE idBill=" + id + "");
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                list.Add(info);

            }

            return list;
        }
        public void InsertBillInfo(int id)
        {
            DataProvider.Instacne.ExecuteQuery("EXEC USP_InsertBill @idTable", new object[] { id });
        }
    }
}
