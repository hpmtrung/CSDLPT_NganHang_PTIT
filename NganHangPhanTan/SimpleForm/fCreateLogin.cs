using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fCreateLogin : DevExpress.XtraEditors.XtraForm
    {
        public fCreateLogin()
        {
            InitializeComponent();
        }

        private void Reload()
        {
            this.taEmployee.Fill(this.DS.usp_GetEmployeeNotHavingAccountOfSubcriber);

            if (bdsEmployee.Count > 0)
            {
                lbHeader.Text = "Chọn nhân viên để tạo tài khoản đăng nhập hệ thống:";
                pnInput.Enabled = gcEmployee.Enabled = true;
            }
            else
            {
                lbHeader.Text = "Hiện tất cả nhân viên trong chi nhánh đã có tài khoản đăng nhập.";
                pnInput.Enabled = gcEmployee.Enabled = false;
            }

            txbLoginName.Clear();
            txbPass.Clear();
        }

        private void fCreateLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.usp_GetEmployeeNotHavingAccountOfSubcriber' table. You can move, or remove it, as needed.
            this.taEmployee.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            Reload();

            string roleContent = "";
            switch (SecurityContext.User.Group)
            {
                case User.GroupENM.NGAN_HANG:
                    roleContent = "1. Tra cứu dữ liệu trên tất cả chi nhánh.\n2. Xem được tất cả các báo cáo.\n3. Tạo tài khoản đăng nhập hệ thống thuộc nhóm quyền tương tự (NganHang).";
                    break;
                case User.GroupENM.CHI_NHANH:
                    roleContent = "1. Toàn quyền cập nhật dữ liệu trên chi nhánh thuộc về.\n2. Xem được tất cả các báo cáo.\n3. Tạo tài khoản đăng nhập hệ thống thuộc nhóm quyền tương tự (ChiNhanh).";
                    break;
                default:
                    throw new Exception("User group is unidentified");
            }
            lbMessage.Text = $"Lưu ý: Bạn đang tạo tài khoản hệ thống thuộc nhóm quyền {SecurityContext.User.GetGroupName()}.\n" +
                $"Nhóm quyền {SecurityContext.User.GetGroupName()} được thực hiện các chức năng sau:\n{roleContent}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginName = txbLoginName.Text.Trim();
            if (string.IsNullOrEmpty(loginName))
            {
                MessageUtil.ShowErrorMsgDialog("Tên đăng nhập hợp lệ");
                txbLoginName.Focus();
                return;
            }

            string pass = txbPass.Text.Trim();
            if (string.IsNullOrEmpty(pass))
            {
                MessageUtil.ShowErrorMsgDialog("Mật khẩu không hợp lệ");
                txbPass.Focus();
                return;
            }

            string employeeId = (((DataRowView)bdsEmployee[bdsEmployee.Position])[Employee.ID_HEADER]).ToString();

            string query = "EXEC dbo.usp_CreateNewLogin @LoginName, @MaNV, @Pass, @Role";
            int res = DataProvider.Instance.ExecuteNonQuery(query, new object[] {loginName, employeeId, pass, SecurityContext.User.GetGroupName()});
            if (res == -1)
            {
                MessageUtil.ShowInfoMsgDialog("Tạo tài khoản hệ thống thành công");
                Reload();
            }
        }
    }
}