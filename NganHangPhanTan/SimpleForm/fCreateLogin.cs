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
                    roleContent = "1. Tra cứu dữ liệu trên tất cả chi nhánh.\n2. Xem được tất cả các báo cáo.\n3. Tạo tài khoản đăng nhập hệ thống thuộc nhóm quyền NganHang.";
                    break;
                case User.GroupENM.CHI_NHANH:
                    roleContent = "1. Mọi chức năng cập nhật dữ liệu trên chi nhánh.\n2. Xem được tất cả các báo cáo.\n3. Tạo tài khoản đăng nhập hệ thống thuộc nhóm quyền ChiNhanh.";
                    break;
                default:
                    throw new Exception("User group is unidentified");
            }
            lbMessage.Text = $"Lưu ý: Bạn đang tạo tài khoản hệ thống thuộc nhóm quyền {SecurityContext.User.GetGroupName()}.\n" +
                $"Thông tin của nhóm quyền {SecurityContext.User.GetGroupName()} bao gồm:\n{roleContent}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginName = txbLoginName.Text.Trim();
            if (string.IsNullOrEmpty(loginName))
            {
                MessageBox.Show("Tên đăng nhập hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbLoginName.Focus();
                return;
            }

            string pass = txbPass.Text.Trim();
            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Mật khẩu không hợp lệ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbPass.Focus();
                return;
            }

            string employeeId = (((DataRowView)bdsEmployee[bdsEmployee.Position])[Employee.ID_HEADER]).ToString();

            string query = "EXEC dbo.usp_CreateNewLogin @LoginName , @MaNV , @Pass , @Role";
            int res = DataProvider.Instance.ExecuteNonQuery(query, new object[] {loginName, employeeId, pass, SecurityContext.User.GetGroupName()});
            if (res == -1)
            {
                MessageBox.Show("Tạo tài khoản hệ thống thành công.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reload();
            }
        }
    }
}