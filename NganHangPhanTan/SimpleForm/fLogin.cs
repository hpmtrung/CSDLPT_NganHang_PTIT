using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {

        private Action<User> changeUserInfo;
        private Action requestExitProgram;

        public Action<User> ChangeUserInfo { get => changeUserInfo; set => changeUserInfo = value; }
        public Action RequestExitProgram { get => requestExitProgram; set => requestExitProgram = value; }

        public fLogin()
        {
            InitializeComponent();
        }

        private void LoadSubcribers()
        {
            ControlUtil.ConfigComboboxBrand(cbBrand);
        }

        private void fLogin_Load(object sender, System.EventArgs e)
        {
            // Load danh sách phân mãnh vào combobox
            LoadSubcribers();
            txbLoginName.Focus();
        }

        // XXX
        public void abc()
        {
            btnLogin_Click(null, new EventArgs());
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            string loginName = txbLoginName.Text.Trim();
            if (string.IsNullOrEmpty(loginName))
            {
                MessageBox.Show("Mã nhân viên không được trống", "", MessageBoxButtons.OK);
                return;
            }
            
            string pass = txbPass.Text.Trim();
            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Mật khẩu không được trống", "", MessageBoxButtons.OK);
                return;
            }

            string serverName = cbBrand.SelectedValue.ToString();
            DataProvider.UniqueInstance.SetServerToSubcriber(serverName, loginName, pass);

            User user = UserDAO.UniqueInstance.Login(loginName);
            if (user != null)
            {
                user.Login = loginName;
                user.Pass = pass;
                user.BrandIndex = cbBrand.SelectedIndex;
                ChangeUserInfo.Invoke(user);
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            requestExitProgram.Invoke();
        }
    }
}