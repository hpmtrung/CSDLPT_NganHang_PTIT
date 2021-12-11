using NganHangPhanTan.DAO;
using System;

namespace NganHangPhanTan.Report
{
    public partial class ReportTransaction : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportTransaction()
        {
            InitializeComponent();
        }

        public ReportTransaction(string accountId, DateTime dateFrom, DateTime dateTo, string type, string typeName, string brandName)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            var query = this.sqlDataSource1.Queries[0];
            query.Parameters[0].Value = accountId;
            query.Parameters[1].Value = dateFrom.Date.ToString("yyyy-MM-dd");
            query.Parameters[2].Value = dateTo.Date.ToString("yyyy-MM-dd");
            query.Parameters[3].Value = type;
            this.sqlDataSource1.Fill();

            lbBrandName.Text = brandName;
            lbTransType.Text = typeName;
            lbAccountId.Text = accountId;
            lbDate.Text = dateFrom.Date.ToString("d") + " - " + dateTo.Date.ToString("d");
        }

    }
}
