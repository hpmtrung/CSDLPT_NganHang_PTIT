using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.SimpleForm;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class fMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private User user;

        private Dictionary<Form, bool> mdiFormCanCloseState = new Dictionary<Form, bool>();

        public fMain()
        {
            InitializeComponent();
        }

        private void ShowUserInfo()
        {
            if (user != null)
            {
                tssEmployeeID.Text = $"Mã nhân viên: {user.Username}";
                tssEmployeeName.Text = $"Họ tên: {user.Fullname}";
                tssEmployeeGroup.Text = $"Nhóm: {user.GetGroupName()}";
            }
            else
            {
                tssEmployeeID.Text = "Mã nhân viên: trống";
                tssEmployeeName.Text = "Họ tên: trống";
                tssEmployeeGroup.Text = "Nhóm: trống";
            }
        }

        private void UpdateCanCloseMDIFormStatus(Form form, bool canClose)
        {
            if (mdiFormCanCloseState.ContainsKey(form))
            {
                if (mdiFormCanCloseState[form] != canClose)
                {
                    if (canClose)
                        form.Text = form.Text.Substring(0, form.Text.Length - 1);
                    else
                        form.Text += "*";
                    mdiFormCanCloseState[form] = canClose;
                }
            }
        }

        private void CloseMDIForm(Form form)
        {
            if (mdiFormCanCloseState.ContainsKey(form))
            {
                if (mdiFormCanCloseState[form])
                {
                    mdiFormCanCloseState.Remove(form);
                }
                else
                    MessageBox.Show($"Form {form.Text} không thể đóng do có tác vụ đang thực hiện.", "", MessageBoxButtons.OK);
            }
            else
            {
                // DEBUG
                throw new Exception("Không tìm thấy form MDI để đóng");
            }
        }

        /// <summary>
        /// Execute when user logins successfully
        /// </summary>
        /// <param name="user"></param>
        private void UpdateUserInfo(User user)
        {
            if (user == null)
                return;
            this.user = user;

            // Update status bar
            ShowUserInfo();

            btnLogin.Enabled = false;
            btnCreateAccount.Enabled = true;
            btnLogout.Enabled = true;
            ribCategory.Visible = true;
            ribService.Visible = true;
            ribReport.Visible = true;
        }

        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fLogin));
            if (form != null)
                form.Activate();
            else
                CreateAndShowLoginForm();
        }

        private void CreateAndShowLoginForm()
        {
            fLogin f = new fLogin
            {
                MdiParent = this,
                ChangeUserInfo = UpdateUserInfo,
                RequestExitProgram = () => { this.Close(); },
            };
            f.Show();
            // XXX
            f.abc();
        }

        private void btnManageEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fEmployeeManage));
            if (form != null)
                form.Activate();
            else
            {
                fEmployeeManage f = new fEmployeeManage(user)
                {
                    MdiParent = this,
                    ReqUpdateCanCloseState = UpdateCanCloseMDIFormStatus,
                    ReqClose = CloseMDIForm,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            btnCreateAccount.Enabled = false;
            btnLogout.Enabled = false;
            ribCategory.Visible = false;
            ribService.Visible = false;
            ribReport.Visible = false;
            CreateAndShowLoginForm();
            btnOpenCustomerAccount_ItemClick(null, null);
        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (KeyValuePair<Form, bool> pair in mdiFormCanCloseState)
            {
                // Kiểm tra có tác vụ chưa lưu, nếu có trả về false
                if (pair.Value == false)
                {
                    MessageBox.Show($"Form {pair.Key.Text} không thể đóng do có tác vụ đang thực hiện.", "", MessageBoxButtons.OK);
                    return;
                }
            }
            if (MessageBox.Show("Xác nhận đăng xuất?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (Form form in MdiChildren)
                {
                    form.Close();
                }
                mdiFormCanCloseState.Clear();
                CreateAndShowLoginForm();
                this.user = null;
                ShowUserInfo();
                btnLogin.Enabled = true;
                btnCreateAccount.Enabled = false;
                btnLogout.Enabled = false;
                ribCategory.Visible = false;
                ribService.Visible = false;
                ribReport.Visible = false;
            }
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Xác nhận thoát chương trình?", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            bool formUnSavedExisted = false;
            foreach (KeyValuePair<Form, bool> pair in mdiFormCanCloseState)
            {
                if (pair.Value == false)
                {
                    formUnSavedExisted = true;
                    break;
                }
            }
            if (formUnSavedExisted)
            {
                MessageBox.Show($"Không thể thoát chương trình vì có form chưa lưu tác vụ.");
                e.Cancel = true;
            } 
            else
            {
                e.Cancel = false;
            }
        }

        private void btnCustomerManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fCustomerManage));
            if (form != null)
                form.Activate();
            else
            {
                fCustomerManage f = new fCustomerManage(user)
                {
                    MdiParent = this,
                    ReqUpdateCanCloseState = UpdateCanCloseMDIFormStatus,
                    ReqClose = CloseMDIForm,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }

        private void btnCreateAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fCreateLogin));
            if (form != null)
                form.Activate();
            else
            {
                fCreateLogin f = new fCreateLogin(user)
                {
                    MdiParent = this,
                };
                f.Show();
            }
        }

        private void btnSendWithdrawService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnTransferService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnAccTransactionReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnOpenAccountReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnCustomerInfoReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnOpenCustomerAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fOpenCustomerAccount));
            if (form != null)
                form.Activate();
            else
            {
                fOpenCustomerAccount f = new fOpenCustomerAccount(user)
                {
                    MdiParent = this,
                    ReqUpdateCanCloseState = UpdateCanCloseMDIFormStatus,
                    ReqClose = CloseMDIForm,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }
    }
}
