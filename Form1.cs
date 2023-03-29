using PBL2QuanCF.DAO;
using System.Text;

namespace PBL2QuanCF
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
           
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username,password);
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {   
            string username = txbUserName.Text;
            string password = txbPassWord.Text;
            if(Login(username,password )) 
            {
                fTableManager a = new fTableManager(); ;
                this.Hide();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên Tài Khoản hoặc Mật Khẩu!", " Thông Báo");
            }
            
        }

        private void btnExit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Thoát Ứng Dụng?", "Thông báo!", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Thoát Ứng Dụng?", "Thông báo!", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}