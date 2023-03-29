using PBL2QuanCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instacne;
        public static CategoryDAO Instacne
        {
            get
            {
                if (instacne == null)
                    instacne = new CategoryDAO();
                return CategoryDAO.instacne;
            }
            private set { CategoryDAO.instacne = value; }
        }
        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "SELECT *FROM FoodCategory";
            DataTable data = DataProvider.Instacne.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);

            }

            return list;
        }
    }
}
