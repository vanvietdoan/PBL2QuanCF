using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2QuanCF.DAO
{
    public class DataProvider
    {
        private static DataProvider instacne;
        private string connet = @"Data Source=DESKTOP-2Q7653F\MSSQLSERVERD;Initial Catalog=QuanLyQuanCafe;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static DataProvider Instacne
        {
            get { if (instacne == null)
                    instacne = new DataProvider();
                return DataProvider.instacne; }
            private set {DataProvider.instacne = value; }
        }

        private DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameter =null)
        {
            DataTable dt = new DataTable();
            using (    SqlConnection cnn = new SqlConnection(connet))
            {
                cnn.Open();
                SqlCommand cnd = new SqlCommand(query, cnn);
                if(parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cnd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                        
                    }

                }


                SqlDataAdapter adapter = new SqlDataAdapter(cnd);               
                adapter.Fill(dt);
                cnn.Close();
            }
            return dt;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data=0;
            using (SqlConnection cnn = new SqlConnection(connet))
            {
                cnn.Open();
                SqlCommand cnd = new SqlCommand(query, cnn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cnd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data= cnd.ExecuteNonQuery();    
                cnn.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection cnn = new SqlConnection(connet))
            {
                cnn.Open();
                SqlCommand cnd = new SqlCommand(query, cnn);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cnd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cnd.ExecuteScalar();
                cnn.Close();
            }
            return data;
        }

    }
}
