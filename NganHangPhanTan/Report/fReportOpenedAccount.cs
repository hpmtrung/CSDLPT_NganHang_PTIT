using DevExpress.XtraReports.UI;
using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;

namespace NganHangPhanTan.Report
{
    public partial class fReportOpenedAccount : DevExpress.XtraEditors.XtraForm
    {
        public fReportOpenedAccount()
        {
            InitializeComponent();
        }

        private void cbBrand_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            // Nếu combobox chi nhánh chưa load danh sách phân mãnh thì thoát
            if (cbBrand.SelectedValue.ToString().Equals("System.Data.RowView"))
                return;
            string serverName = cbBrand.SelectedValue.ToString();
            User user = SecurityContext.User;
            if (cbBrand.SelectedIndex != user.BrandIndex)
                DataProvider.Instance.SetServerToRemote(serverName);
            else
                DataProvider.Instance.SetServerToSubcriber(serverName, user.Login, user.Pass);
            if (DataProvider.Instance.CheckConnection() == false)
            {
                MessageUtil.ShowErrorMsgDialog("Lỗi kết nối sang chi nhánh mới.");
                return;
            }
        }

        private void fReportOpenedAccount_Load(object sender, System.EventArgs e)
        {
            ControlUtil.ConfigComboboxBrand(cbBrand);
            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;

            dpDateFrom.DateTime = dpDateTo.DateTime = DateTime.Now;
            rbtChooseBrand.Checked = true;
            cbBrand_SelectionChangeCommitted(null, null);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dpDateFrom.DateTime > dpDateTo.DateTime)
                {
                    MessageUtil.ShowErrorMsgDialog("Chọn ngày không hợp lệ");
                    return;
                }

                if (rbtChooseBrand.Checked)
                {
                    ReportOpenedAccountByBrand report = new ReportOpenedAccountByBrand(dpDateFrom.DateTime, dpDateTo.DateTime, cbBrand.Text);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.ShowPreviewDialog();
                } else
                {
                    ReportOpenedAccountAllBrand report = new ReportOpenedAccountAllBrand(dpDateFrom.DateTime, dpDateTo.DateTime);
                    ReportPrintTool printTool = new ReportPrintTool(report);
                    printTool.ShowPreviewDialog();
                }
            }
            catch (System.Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw ex;
            }
        }
    }
}