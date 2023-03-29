using PBL2QuanCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DAO
{
    internal class TableDAO
    {
        private static TableDAO instacne;
        public static TableDAO Instacne
        {
            get
            {
                if (instacne == null)
                    instacne = new TableDAO();
                return TableDAO.instacne;
            }
            private set { TableDAO.instacne = value; }
        }
        private TableDAO() { }
        public List<Table> LoadTableList()
        {
            List<Table> list = new List<Table>();
            DataTable data = DataProvider.Instacne.ExecuteQuery(" USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table  table= new Table(item);
                list.Add(table);

            }

            return list;
        }
        public static int TableWidth = 110;
        public static int TableHight = 110;
    }
}
