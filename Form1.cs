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
            // if (txbUserName.Text =="Doan Van Viet" && txbPassWord.Text =="12345") { 
            fTableManager a = new fTableManager(); ;
            this.Hide();
            a.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Sai Mật Khẩu");
            //  }
            // this.Show();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Thoát Ứng Dụng?", "Thông báo!", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}