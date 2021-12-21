using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Report;
using NganHangPhanTan.SimpleForm;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NganHangPhanTan
{
    public partial class fMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Dictionary<Form, bool> mdiFormCanCloseState = new Dictionary<Form, bool>();

        public fMain()
        {
            InitializeComponent();
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
                    mdiFormCanCloseState.Remove(form);
                else
                    MessageUtil.ShowInfoMsgDialog($"Form {form.Text} không thể đóng do có tác vụ đang thực hiện.");
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
        private void UpdateUserInfo()
        {
            User user = SecurityContext.User;
            if (user == null) return;

            // Update status bar
            tssEmployeeID.Text = $"Mã nhân viên: {user.Username}";
            tssEmployeeName.Text = $"Họ tên: {user.Fullname}";
            tssEmployeeGroup.Text = $"Nhóm: {user.GetGroupName()}";

            btnLogin.Enabled = false;
            btnCreateLogin.Enabled = btnLogout.Enabled = true;

            ribCategory.Visible = ribService.Visible = ribReport.Visible = true;
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
                RequestExitProgram = () => Close(),
            };
            f.Show();
        }

        private void btnManageEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fEmployeeManage));
            if (form != null)
                form.Activate();
            else
            {
                fEmployeeManage f = new fEmployeeManage()
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
            btnCreateLogin.Enabled = btnLogout.Enabled = false;
            ribCategory.Visible = ribService.Visible = ribReport.Visible = false;
            CreateAndShowLoginForm();
        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (KeyValuePair<Form, bool> pair in mdiFormCanCloseState)
            {
                // Kiểm tra có tác vụ chưa lưu, nếu có trả về false
                if (pair.Value == false)
                {
                    MessageUtil.ShowErrorMsgDialog($"Form {pair.Key.Text} không thể đóng do có tác vụ đang thực hiện");
                    return;
                }
            }
            if (MessageUtil.ShowWarnConfirmDialog("Xác nhận đăng xuất?") == DialogResult.OK)
            {
                foreach (Form form in MdiChildren)
                {
                    form.Close();
                }
                mdiFormCanCloseState.Clear();
                CreateAndShowLoginForm();

                SecurityContext.ClearUser();

                // Clear user info in status bar
                tssEmployeeID.Text = "Mã nhân viên: trống";
                tssEmployeeName.Text = "Họ tên: trống";
                tssEmployeeGroup.Text = "Nhóm: trống";

                btnLogin.Enabled = true;
                btnCreateLogin.Enabled = btnLogout.Enabled = false;
                ribCategory.Visible = ribService.Visible = ribReport.Visible = false;
            }
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageUtil.ShowInfoConfirmDialog("Xác nhận thoát chương trình?") == DialogResult.Cancel)
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
                MessageUtil.ShowInfoMsgDialog($"Không thể thoát chương trình vì có form chưa lưu tác vụ.");
                e.Cancel = true;
            } 
            else
                e.Cancel = false;
        }

        private void btnCustomerManage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fCustomerManage));
            if (form != null)
                form.Activate();
            else
            {
                fCustomerManage f = new fCustomerManage()
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
                fCreateLogin f = new fCreateLogin()
                {
                    MdiParent = this,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }

        private void btnSendWithdrawService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fTransSendWithdrawal));
            if (form != null)
                form.Activate();
            else
            {
                fTransSendWithdrawal f = new fTransSendWithdrawal()
                {
                    MdiParent = this,
                    ReqUpdateCanCloseState = UpdateCanCloseMDIFormStatus,
                    ReqClose = CloseMDIForm,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }

        private void btnTransferService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fTransExchange));
            if (form != null)
                form.Activate();
            else
            {
                fTransExchange f = new fTransExchange()
                {
                    MdiParent = this,
                    ReqUpdateCanCloseState = UpdateCanCloseMDIFormStatus,
                    ReqClose = CloseMDIForm,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }

        private void btnAccTransactionReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fReportTransaction));
            if (form != null)
                form.Activate();
            else
            {
                fReportTransaction f = new fReportTransaction()
                {
                    MdiParent = this,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }

        private void btnOpenAccountReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fReportOpenedAccount));
            if (form != null)
                form.Activate();
            else
            {
                fReportOpenedAccount f = new fReportOpenedAccount()
                {
                    MdiParent = this,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }

        private void btnCustomerInfoReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fReportAccountDetail));
            if (form != null)
                form.Activate();
            else
            {
                fReportAccountDetail f = new fReportAccountDetail()
                {
                    MdiParent = this,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }

        private void btnOpenCustomerAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fOpenCustomerAccount));
            if (form != null)
                form.Activate();
            else
            {
                fOpenCustomerAccount f = new fOpenCustomerAccount()
                {
                    MdiParent = this,
                    ReqUpdateCanCloseState = UpdateCanCloseMDIFormStatus,
                    ReqClose = CloseMDIForm,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }

        private void btnCreateLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = ControlUtil.CheckFormExists(this, typeof(fCreateLogin));
            if (form != null)
                form.Activate();
            else
            {
                fCreateLogin f = new fCreateLogin()
                {
                    MdiParent = this,
                };
                f.Show();
                mdiFormCanCloseState.Add(f, true);
            }
        }
    }
}
