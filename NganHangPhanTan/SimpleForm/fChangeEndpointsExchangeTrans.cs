using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fChangeEndpointsExchangeTrans : DevExpress.XtraEditors.XtraForm
    {
        private ExchangeTransaction exchangeTransaction;

        private Action reqChangeEndpoints;

        private string senderAccountId;

        public Action ReqChangeEnpoints { get => reqChangeEndpoints; set => reqChangeEndpoints = value; }
        public string SenderAccountId { get => senderAccountId; set => senderAccountId = value; }

        private bool validateError = false;

        public fChangeEndpointsExchangeTrans(ExchangeTransaction exchangeTransaction)
        {
            InitializeComponent();
            this.exchangeTransaction = exchangeTransaction;
            gcEndpoints.DataSource = exchangeTransaction.Endpoints;
            ConfigGridEnpoint();
        }

        private void ConfigGridEnpoint()
        {
            gvEndpoints.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gvEndpoints.Appearance.HeaderPanel.Options.UseFont = true;
            gvEndpoints.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gvEndpoints.Appearance.Row.Options.UseFont = true;

            gvEndpoints.Columns[ExchangeEndpoint.ACCOUNT_ID_IDX].OptionsColumn.ReadOnly = true;
            gvEndpoints.Columns[ExchangeEndpoint.FULLNAME_IDX].OptionsColumn.ReadOnly = true;
            gvEndpoints.Columns[ExchangeEndpoint.CUSTOMER_ID_IDX].OptionsColumn.ReadOnly = true;
            gvEndpoints.Columns[ExchangeEndpoint.EXCHANGE_MONEY_IDX].OptionsColumn.ReadOnly = false;

            gvEndpoints.Columns[ExchangeEndpoint.EXCHANGE_MONEY_IDX].DisplayFormat.FormatString = "{0:c0}";
            gvEndpoints.Columns[ExchangeEndpoint.EXCHANGE_MONEY_IDX].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            
            // Alignment
            gvEndpoints.Columns[ExchangeEndpoint.ACCOUNT_ID_IDX].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvEndpoints.Columns[ExchangeEndpoint.ACCOUNT_ID_IDX].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvEndpoints.Columns[ExchangeEndpoint.FULLNAME_IDX].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvEndpoints.Columns[ExchangeEndpoint.CUSTOMER_ID_IDX].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvEndpoints.Columns[ExchangeEndpoint.CUSTOMER_ID_IDX].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvEndpoints.Columns[ExchangeEndpoint.EXCHANGE_MONEY_IDX].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            // Reload customer data
            string customerId = ((DataRowView)bdsCustomer.Current)[Customer.ID_HEADER].ToString();
            this.taCustomer.Fill(this.DS.usp_GetCustomerHavingAccountAll, this.senderAccountId);

            try
            {
                bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, customerId);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowInfoMsgDialog("Xãy ra lỗi khi reload: Khách hàng đã chọn trước đó không tồn tại trong danh sách.\nChi tiết: " + ex.Message);
                return;
            }

            LoadAccountFromCustomer();
        }

        private void fChangeEndpointsExchangeTrans_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.usp_GetCustomerHavingAccountAll' table. You can move, or remove it, as needed.
            this.taCustomer.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taCustomer.Fill(this.DS.usp_GetCustomerHavingAccountAll, this.senderAccountId);

            this.taAccount.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;

            btnDelete.Enabled = btnDeleteAll.Enabled = gvEndpoints.RowCount > 0;

            teRemainBalance.EditValue = this.exchangeTransaction.RemainBalance;
        }

        private void DeleteEndpoint()
        {
            // Delete endpoint
            ExchangeEndpoint selectEndpoint = (ExchangeEndpoint)gvEndpoints.GetFocusedRow();

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa TK cần chuyển là {selectEndpoint.AccountId}?") != DialogResult.OK)
                return;

            try
            {
                exchangeTransaction.RemoveEndpoint(gvEndpoints.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                return;
            }

            btnDelete.Enabled = btnDeleteAll.Enabled = gvEndpoints.RowCount > 0;
            validateError = false;
            teRemainBalance.EditValue = this.exchangeTransaction.RemainBalance;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEndpoint();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            // Kiểm tra số tài khoản đã có
            string accountId = ((DataRowView)bdsAccount.Current)[Account.ID_HEADER].ToString();

            foreach (ExchangeEndpoint endpoint in exchangeTransaction.Endpoints)
            {
                if (endpoint.AccountId.Equals(accountId))
                {
                    MessageUtil.ShowErrorMsgDialog($"Tài khoản {accountId} đã được chọn, vui lòng hiệu chỉnh số tiền cần chuyển.");
                    return;
                }
            }

            string customerId = ((DataRowView)bdsCustomer.Current)[Customer.ID_HEADER].ToString();
            string customerFullname = ((DataRowView)bdsCustomer.Current)["HOTEN"].ToString();

            exchangeTransaction.AddEnpoint(new ExchangeEndpoint(accountId, customerFullname, customerId, 0));

            btnDelete.Enabled = btnDeleteAll.Enabled = true;
        }

        private void LoadAccountFromCustomer()
        {
            if (bdsCustomer.Count > 0)
            {
                string customerId = ((DataRowView)bdsCustomer.Current)[Customer.ID_HEADER].ToString();
                try
                {
                    this.taAccount.Fill(this.DS.usp_GetAccountByCustomerId, customerId);
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                }
            }
            btnChoose.Enabled = bdsAccount.Count > 0;
        }

        private void gvCustomer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadAccountFromCustomer();
        }

        private void DeleteAllEndpoints()
        {
            if (MessageUtil.ShowWarnConfirmDialog("Xác nhận xóa danh sách tài khoản cần chuyển?") != DialogResult.OK)
                return;

            exchangeTransaction.Clear();
            btnDelete.Enabled = btnDeleteAll.Enabled = false;
            validateError = false;
            teRemainBalance.EditValue = this.exchangeTransaction.RemainBalance;
        }

        /// <summary>
        /// Delete all select endpoints
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DeleteAllEndpoints();
        }

        private void fChangeEndpointsExchangeTrans_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (validateError)
            {
                e.Cancel = true;
                return;
            }
            // Commit
            reqChangeEndpoints.Invoke();
        }

        private void gvEndpoints_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (btnDelete.Focused)
            {
                DeleteEndpoint();
                return;
            }

            if (btnDeleteAll.Focused)
            {
                DeleteAllEndpoints();
                return;
            }
            validateError = false;
            try
            {
                ExchangeEndpoint endpoint = (ExchangeEndpoint)e.Row;
                exchangeTransaction.UpdateRemainBalance();
                teRemainBalance.EditValue = this.exchangeTransaction.RemainBalance;
            }
            catch (Exception ex)
            {
                e.Valid = false;
                e.ErrorText = ex.Message;
                validateError = true;
                return;
            }
        }

        private void gvEndpoints_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            MessageUtil.ShowErrorMsgDialog(e.ErrorText);
        }

        private void gvEndpoints_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (btnDelete.Focused || btnDeleteAll.Focused)
                return;
            validateError = false;
            GridView view = sender as GridView;
            if (view.FocusedColumn == view.Columns[ExchangeEndpoint.EXCHANGE_MONEY_IDX])
            {
                try
                {
                    exchangeTransaction.Endpoints[gvEndpoints.FocusedRowHandle].ExchangeMoney = (double)e.Value;
                    exchangeTransaction.UpdateRemainBalance();
                    teRemainBalance.EditValue = this.exchangeTransaction.RemainBalance;
                }
                catch (Exception ex)
                {
                    e.Valid = false;
                    e.ErrorText = ex.Message;
                    validateError = true;
                    return;
                }
            }
        }
    }
}