using PBL2QuanCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instacne;
        public static FoodDAO Instacne
        {
            get
            {
                if (instacne == null)
                    instacne = new FoodDAO();
                return FoodDAO.instacne;
            }
            private set { FoodDAO.instacne = value; }
        }
        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "SELECT * FROM Food where idCategory= "+id+"";
            DataTable data = DataProvider.Instacne.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food f = new Food(item);
                list.Add(f);

            }

            return list;
        }
    }
}
