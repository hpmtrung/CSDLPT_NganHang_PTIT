using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Data;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fEmployeeMove : DevExpress.XtraEditors.XtraForm
    {
        public fEmployeeMove()
        {
            InitializeComponent();
        }

        public Action<string> ReqMoveEmployeeToBrandId;

        private void btnMove_Click(object sender, EventArgs e)
        {
            string selectedBrandId = ((DataRowView)bdsBrandOption[bdsBrandOption.Position])[Brand.ID_HEADER].ToString();
            ReqMoveEmployeeToBrandId.Invoke(selectedBrandId);
        }

        private void fEmployeeMove_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.usp_GetOtherBrandFromSubcriber' table. You can move, or remove it, as needed.
            this.usp_GetOtherBrandFromSubcriberTableAdapter.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.usp_GetOtherBrandFromSubcriberTableAdapter.Fill(this.dS.usp_GetOtherBrandFromSubcriber);
            if (bdsBrandOption.Count > 0)
                bdsBrandOption.Position = 0;
            btnMove.Enabled = bdsBrandOption.Count > 0;
        }
    }
}