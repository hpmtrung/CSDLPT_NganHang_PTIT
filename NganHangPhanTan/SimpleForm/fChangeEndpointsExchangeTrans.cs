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

        public fChangeEndpointsExchangeTrans(ExchangeTransaction exchangeTransaction)
        {
            InitializeComponent();
            this.exchangeTransaction = exchangeTransaction;
            gcEndpoints.DataSource = exchangeTransaction.Endpoints;
            ConfigGridEnpoint();
        }

        private void ConfigGridEnpoint()
        {
            gvEndpoints.Columns[ExchangeEndpoint.ACCOUNT_ID_IDX].OptionsColumn.ReadOnly = true;
            gvEndpoints.Columns[ExchangeEndpoint.FULLNAME_IDX].OptionsColumn.ReadOnly = true;
            gvEndpoints.Columns[ExchangeEndpoint.CUSTOMER_ID_IDX].OptionsColumn.ReadOnly = true;
            gvEndpoints.Columns[ExchangeEndpoint.EXCHANGE_MONEY_IDX].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvEndpoints.Columns[ExchangeEndpoint.EXCHANGE_MONEY_IDX].DisplayFormat.FormatString = "0:c0";
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
                MessageUtil.ShowErrorMsgDialog("Xãy ra lỗi khi reload: Khách hàng đang chọn không tồn tại.\nChi tiết: " + ex.Message);
                return;
            }

            // Reload account data
            string accountId = ((DataRowView)bdsAccount.Current)[Account.ID_HEADER].ToString();
            LoadAccountFromCustomer();

            try
            {
                bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, accountId);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog("Xãy ra lỗi khi reload: Tài khoản đang chọn không tồn tại.\nChi tiết: " + ex.Message);
            }
        }

        private void fChangeEndpointsExchangeTrans_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.usp_GetCustomerHavingAccountAll' table. You can move, or remove it, as needed.
            this.taCustomer.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taCustomer.Fill(this.DS.usp_GetCustomerHavingAccountAll, this.senderAccountId);

            this.taAccount.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;

            btnDelete.Enabled = btnReset.Enabled = gvEndpoints.RowCount > 0;

            teRemainBalance.EditValue = this.exchangeTransaction.RemainBalance;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete endpoint
            ExchangeEndpoint selectEndpoint = (ExchangeEndpoint)gvEndpoints.GetFocusedRow();

            if (MessageUtil.ShowWarnConfirmDialog($"Bạn có chắc muốn xóa TK chuyển {selectEndpoint.AccountId}?") != DialogResult.OK)
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

            btnDelete.Enabled = btnReset.Enabled = gvEndpoints.RowCount > 0;
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
                    MessageUtil.ShowErrorMsgDialog("Tài khoản đã được chọn, vui lòng điều chỉnh số tiền cần chuyển.");
                    return;
                }
            }

            string customerId = ((DataRowView)bdsCustomer.Current)[Customer.ID_HEADER].ToString();
            string customerFullname = ((DataRowView)bdsCustomer.Current)["HOTEN"].ToString();

            exchangeTransaction.AddEnpoint(new ExchangeEndpoint(accountId, customerFullname, customerId, 0));

            btnDelete.Enabled = btnReset.Enabled = true;
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

        /// <summary>
        /// Delete all select endpoints
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageUtil.ShowWarnConfirmDialog("Xác nhận làm mới danh sách tài khoản cần chuyển?") != DialogResult.OK)
                return;

            exchangeTransaction.Clear();
            btnDelete.Enabled = btnReset.Enabled = false;
        }

        private void fChangeEndpointsExchangeTrans_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Commit
            reqChangeEndpoints.Invoke();
        }

        private void gvEndpoints_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                ExchangeEndpoint endpoint = (ExchangeEndpoint)e.Row;
                //double exchangeMoney = endpoint.ExchangeMoney;
                //if (exchangeMoney < 0)
                //    throw new Exception("Số tiền chuyển không hợp lệ");
                exchangeTransaction.UpdateRemainBalance();
                teRemainBalance.EditValue = this.exchangeTransaction.RemainBalance;
            }
            catch (Exception ex)
            {
                e.Valid = false;
                e.ErrorText = ex.Message;
                return;
            }
        }

        private void gvEndpoints_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            MessageUtil.ShowErrorMsgDialog($"{e.ErrorText}");
        }

        private void gvEndpoints_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn == view.Columns[ExchangeEndpoint.EXCHANGE_MONEY_IDX])
            {
                try
                {
                    //double exchangeMoney = (double) e.Value;
                    //if (exchangeMoney < 0)
                    //    throw new Exception("Số tiền chuyển không hợp lệ");
                    exchangeTransaction.Endpoints[gvEndpoints.FocusedRowHandle].ExchangeMoney = (double)e.Value;
                    exchangeTransaction.UpdateRemainBalance();
                    teRemainBalance.EditValue = this.exchangeTransaction.RemainBalance;
                }
                catch (Exception ex)
                {
                    e.Valid = false;
                    e.ErrorText = ex.Message;
                    return;
                }
            }
        }
    }
}