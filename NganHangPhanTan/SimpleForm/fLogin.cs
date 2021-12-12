using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;

namespace NganHangPhanTan
{
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        private Action changeUserInfo;
        private Action requestExitProgram;

        public Action ChangeUserInfo { get => changeUserInfo; set => changeUserInfo = value; }
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
                MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được trống");
                return;
            }
            
            string pass = txbPass.Text.Trim();
            if (string.IsNullOrEmpty(pass))
            {
                MessageUtil.ShowErrorMsgDialog("Mật khẩu không được trống");
                return;
            }

            string serverName = cbBrand.SelectedValue.ToString();
            DataProvider.Instance.SetServerToSubcriber(serverName, loginName, pass);

            User user = UserDAO.Instance.Login(loginName);
            if (user != null)
            {
                user.Login = loginName;
                user.Pass = pass;
                user.BrandIndex = cbBrand.SelectedIndex;
                SecurityContext.User = user;
                ChangeUserInfo.Invoke();
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            requestExitProgram.Invoke();
        }
    }
}