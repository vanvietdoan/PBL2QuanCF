using PBL2QuanCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instacne;
        public static MenuDAO Instacne
        {
            get
            {
                if (instacne == null)
                    instacne = new MenuDAO();
                return MenuDAO.instacne;
            }
            private set { MenuDAO.instacne = value; }
        }
        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> list = new List<Menu>();
            string query = "SELECT f.name, bi.count, f.price, f.price*bi.count as TotalPrice From Bill as b, BillInfo as bi, Food as f where bi.idBill = b.id AND b.status =0 AND bi.idFood = f.id AND idTable= "+id+"";
            DataTable data = DataProvider.Instacne.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                list.Add(menu);

            }

            return list;
        }
    }
}
