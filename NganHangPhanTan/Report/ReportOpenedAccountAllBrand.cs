using NganHangPhanTan.DAO;
using System;

namespace NganHangPhanTan.Report
{
    public partial class ReportOpenedAccountAllBrand : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportOpenedAccountAllBrand()
        {
            InitializeComponent();
        }

        public ReportOpenedAccountAllBrand(DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            var query = this.sqlDataSource1.Queries[0];
            query.Parameters[0].Value = dateFrom.Date.ToString("yyyy-MM-dd");
            query.Parameters[1].Value = dateTo.Date.ToString("yyyy-MM-dd");
            this.sqlDataSource1.Fill();

            lbDate.Text = dateFrom.Date.ToString("d") + " - " + dateTo.Date.ToString("d");
        }
    }
}
