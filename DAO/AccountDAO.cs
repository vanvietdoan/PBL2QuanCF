using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PBL2QuanCF.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            // string query = " USP_Login @userName , @passWord";
            string query = " USP_Login  @useName  ,  @passWord" ;
            DataTable result = DataProvider.Instacne.ExecuteQuery(query, new Object[]{ username , password });
            return result.Rows.Count > 0;
        }
    }
}
 