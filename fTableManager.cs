using PBL2QuanCF.DAO;
using PBL2QuanCF.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace PBL2QuanCF
{
    public partial class fTableManager : Form
    {
       // private EventHandler btn_Click;

        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
            Loadcategory(); 
        }
        #region Method
        void Loadcategory()
        {
            List<Category> list = CategoryDAO.Instacne.GetListCategory();
            cbCategory.DataSource= list; 
            cbCategory.DisplayMember= "Name";
        }
        void loadFoodListByCategoryID(int id)
        {
            List<Food> foods = FoodDAO.Instacne.GetFoodByCategoryID(id);
            cbFood.DataSource= foods;
            cbFood.DisplayMember= "Name";
        }
        void LoadTable()
        {
            List<Table> li= TableDAO.Instacne.LoadTableList();
            foreach (Table item in li)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth , Height = TableDAO.TableHight };
                btn.Text= item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightBlue ;
                        break;

                }
                flpTable.Controls.Add(btn);
            }
        }
        void ShowBill(int id)
        {   
            lsvBill.Items.Clear();
            List<Menu> listBill= MenuDAO.Instacne.GetListMenuByTable(id);
            float totalprice = 0;
            foreach(Menu item in listBill)
            {
                ListViewItem listItem = new ListViewItem(item.FoodName.ToString());
                listItem.SubItems.Add(item.Count.ToString());
                listItem.SubItems.Add(item.Price.ToString());
                listItem.SubItems.Add(item.TotalPrice.ToString());
                totalprice += item.TotalPrice;
                lsvBill.Items.Add(listItem);
            }
            CultureInfo culture= new CultureInfo("vi-VN");
           
            txbTotalPrice.Text = totalprice.ToString("c", culture);

        }
        #endregion

        #region Events
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void btn_Click( object sender, EventArgs e)
        {
            int tableID = ((sender as Button ).Tag as Table ).ID;
            lsvBill.Tag = (sender as Button).Tag as;
            ShowBill(tableID);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fAdmin f= new fAdmin();
            f.ShowDialog();    
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
       

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb= sender as ComboBox;
            if (cb.Items != null) return;
            Category selected  = cb.SelectedItem as Category;
            id = selected.ID;
            loadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
