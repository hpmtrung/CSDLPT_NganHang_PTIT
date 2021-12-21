using DevExpress.XtraReports.UI;
using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NganHangPhanTan.Report
{
    public partial class fReportTransaction : DevExpress.XtraEditors.XtraForm
    {
        private readonly static Dictionary<string, string> transTypeMap = new Dictionary<string, string>
        {
            {"Tất cả", ""},
            {"Rút tiền", "RT"},
            {"Gửi tiền", "GT"},
            {"Chuyển tiền", "CT"}
        };

        public fReportTransaction()
        {
            InitializeComponent();
        }

        private void fReportTransaction_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.usp_GetCustomerAccounts' table. You can move, or remove it, as needed.
            this.taGetCustomerAccounts.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taGetCustomerAccounts.Fill(this.DS.usp_GetCustomerAccounts);

            ControlUtil.ConfigComboboxBrand(cbBrand);
            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;

            switch (SecurityContext.User.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBrand.Enabled = true;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBrand.Enabled = false;
                    break;
            }

            
            cbTransType.DataSource = new BindingSource(transTypeMap, null);
            cbTransType.DisplayMember = "Key";
            cbTransType.ValueMember = "Value";

            dpDateFrom.DateTime = dpDateTo.DateTime = DateTime.Now;
            cbBrand_SelectionChangeCommitted(null, null);
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (bsGetCustomerAccounts.Count == 0)
                {
                    MessageUtil.ShowErrorMsgDialog("Không thể xem báo cáo vì danh sách tài khoản rỗng");
                    return;
                }
                if (dpDateFrom.DateTime > dpDateTo.DateTime)
                {
                    MessageUtil.ShowErrorMsgDialog("Chọn ngày không hợp lệ");
                    return;
                }

                string accountId = ((DataRowView)bsGetCustomerAccounts[bsGetCustomerAccounts.Position])["SOTK"].ToString();
                string transType = cbTransType.SelectedValue.ToString();
                ReportTransaction report = new ReportTransaction(accountId, dpDateFrom.DateTime, dpDateTo.DateTime, transType,
                    ControlUtil.GetTextInCombobox(cbTransType),  cbBrand.Text);
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }
            catch (System.Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw ex;
            }
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
            // Tải dữ liệu từ site mới về
            taGetCustomerAccounts.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            taGetCustomerAccounts.Fill(this.DS.usp_GetCustomerAccounts);
        }
    }
}