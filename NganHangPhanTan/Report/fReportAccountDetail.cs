using DevExpress.XtraReports.UI;
using NganHangPhanTan.Util;
using System;

namespace NganHangPhanTan.Report
{
    public partial class fReportAccountDetail : DevExpress.XtraEditors.XtraForm
    {
        public fReportAccountDetail()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ReportAccountDetail report = new ReportAccountDetail();
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }
            catch (System.Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw ex;
            }
        }
    }
}