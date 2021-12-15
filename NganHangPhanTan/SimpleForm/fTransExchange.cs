﻿using DevExpress.XtraGrid.Views.Grid;
using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fTransExchange : DevExpress.XtraEditors.XtraForm
    {
        private Action<Form, bool> reqUpdateCanCloseState;
        private Action<Form> reqClose;

        private fChangeEndpointsExchangeTrans changeEndpointForm;

        private ExchangeTransaction exchangeTransaction;

        private DataTable bufferExchangeTransDataTable;

        private bool acceptGvFocusedRowChanging = true;
        private bool delegateFromCustomerFocusedRowChanging = false;
        private bool reloadData = false;

        public Action<Form, bool> ReqUpdateCanCloseState { get => reqUpdateCanCloseState; set => reqUpdateCanCloseState = value; }
        public Action<Form> ReqClose { get => reqClose; set => reqClose = value; }

        public fTransExchange()
        {
            InitializeComponent();
        }

        private void fTransExchange_Load(object sender, EventArgs e)
        {
            this.taCustomer.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taCustomer.Fill(this.DS.usp_GetCustomerHavingAccountInSubcriber);

            this.taAccount.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;

            this.taTrans.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;

            ControlUtil.ConfigComboboxBrand(cbBrand);
            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;

            switch (SecurityContext.User.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBrand.Enabled = true;
                    gcEditEnpoint.Enabled = false;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBrand.Enabled = false;
                    gcEditEnpoint.Enabled = true;

                    exchangeTransaction = new ExchangeTransaction();
                    gcEndpoints.DataSource = exchangeTransaction.Endpoints;
                    ConfigGridEnpoint();

                    // Tao cac cot cho data table luu du lieu
                    bufferExchangeTransDataTable = new DataTable();
                    bufferExchangeTransDataTable.Columns.Add("SOTK_NHAN", typeof(string));
                    bufferExchangeTransDataTable.Columns.Add("SOTIEN", typeof(double));

                    // Enpoint list is empty, so unable to commit
                    btnCommit.Enabled = false;
                    break;
                default:
                    // DEBUG
                    throw new Exception("User group is unidentified");
            }
        }

        private void ConfigGridEnpoint()
        {
            gvEndpoints.Columns[ExchangeEndpoint.ACCOUNT_ID_IDX].OptionsColumn.ReadOnly = true;
            gvEndpoints.Columns[ExchangeEndpoint.FULLNAME_IDX].OptionsColumn.ReadOnly = true;
            gvEndpoints.Columns[ExchangeEndpoint.CUSTOMER_ID_IDX].OptionsColumn.ReadOnly = true;
            gvEndpoints.Columns[ExchangeEndpoint.EXCHANGE_MONEY_IDX].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gvEndpoints.Columns[ExchangeEndpoint.EXCHANGE_MONEY_IDX].DisplayFormat.FormatString = "0:c0";
        }

        private void fTransExchange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ReqClose.Invoke(this);
                e.Cancel = btnCommit.Enabled;
            }
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
        }

        private void gvCustomer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!acceptGvFocusedRowChanging || reloadData)
                return;

            if (!btnCommit.Enabled)
            {
                LoadAccountFromCustomer();
                return;
            }

            DialogResult res = MessageBox.Show("Lưu giao dịch hiện tại?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                CommitTransaction();
            else if (res == DialogResult.No)
            {
                delegateFromCustomerFocusedRowChanging = true;
                LoadAccountFromCustomer();
            }
            else
            {
                // Return to previous row in customer table
                if (e.PrevFocusedRowHandle >= 0)
                {
                    acceptGvFocusedRowChanging = false;
                    gvCustomer.FocusedRowHandle = e.PrevFocusedRowHandle;
                    acceptGvFocusedRowChanging = true;
                }
            }
        }

        private void LoadTransFromAccount()
        {
            if (bdsAccount.Count > 0)
            {
                string accountId = ((DataRowView)bdsAccount.Current)[Account.ID_HEADER].ToString();
                try
                {
                    this.taTrans.Fill(this.DS.usp_GetTransExchangeByAccountId, accountId);
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                }
            }
        }

        private void gvAccount_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (reloadData) return;

            if (delegateFromCustomerFocusedRowChanging == false)
            {
                if (acceptGvFocusedRowChanging == false)
                    return;

                if (btnCommit.Enabled == false)
                {
                    ResetTransaction();
                    LoadTransFromAccount();
                    return;
                }

                DialogResult res = MessageBox.Show("Lưu giao dịch hiện tại?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                    CommitTransaction();
                else if (res == DialogResult.No)
                {
                    // Xóa dữ liệu phiên giao dịch cũ nếu có
                    ResetTransaction();
                    teRemainBalance.EditValue = teInitBalance.EditValue = null;
                    btnCommit.Enabled = false;
                    LoadTransFromAccount(); 
                }
                else
                {
                    // Return to previous row in customer table
                    if (e.PrevFocusedRowHandle >= 0)
                    {
                        acceptGvFocusedRowChanging = false;
                        gvCustomer.FocusedRowHandle = e.PrevFocusedRowHandle;
                        acceptGvFocusedRowChanging = true;
                    }
                }
            }
            else
            {
                // Xóa dữ liệu phiên giao dịch cũ nếu có
                ResetTransaction();
                teRemainBalance.EditValue = teInitBalance.EditValue = null;
                btnCommit.Enabled = false;
                LoadTransFromAccount();
                delegateFromCustomerFocusedRowChanging = false;
            }
        }

        private void ResetTransaction()
        {
            exchangeTransaction.Clear();
            if (bdsAccount.Current != null)
                exchangeTransaction.InitBalance = double.Parse(((DataRowView)bdsAccount.Current)[Account.BALANCE_HEADER].ToString());
        }

        private void cbBrand_SelectionChangeCommitted(object sender, EventArgs e)
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
                MessageBox.Show("Lỗi kết nối sang chi nhánh mới.");
                return;
            }

            // Load lại dữ liệu khách hàng
            this.taCustomer.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taCustomer.Fill(this.DS.usp_GetCustomerHavingAccountInSubcriber);

            this.taAccount.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;

            this.taTrans.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;

            // Load lại dữ liệu tài khoản theo khách hàng
            LoadAccountFromCustomer();
            // Load lại dữ liệu giao dich theo tài khoản
            LoadTransFromAccount();
        }

        /// <summary>
        /// Reload lại dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            reloadData = true;
            bool errorFound = false;

            // Reload customer data
            string customerId = ((DataRowView)bdsCustomer.Current)[Customer.ID_HEADER].ToString();
            this.taCustomer.Fill(this.DS.usp_GetCustomerHavingAccountInSubcriber);
            try
            {
                bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, customerId);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog("Xãy ra lỗi khi reload: Khách hàng đang chọn không tồn tại.\nChi tiết: " + ex.Message);
                errorFound = true;
            }
            // Reload account data
            string accountId = ((DataRowView)bdsAccount.Current)[Account.ID_HEADER].ToString();
            this.taAccount.Fill(this.DS.usp_GetAccountByCustomerId, customerId);
            try
            {
                bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, accountId);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog("Xãy ra lỗi khi reload: Tài khoản đang chọn không tồn tại.\nChi tiết: " + ex.Message);
                errorFound = true;
            }

            LoadTransFromAccount();

            if (errorFound)
            {
                ResetTransaction();
                teRemainBalance.EditValue = teInitBalance.EditValue = null;
                btnCommit.Enabled = false;
            }
            reloadData = false;
        }

        private void btnChangeEndpoints_Click(object sender, EventArgs e)
        {
            if (changeEndpointForm == null)
            {
                changeEndpointForm = new fChangeEndpointsExchangeTrans(exchangeTransaction)
                {
                    ReqChangeEnpoints = LoadChangeEnpoints
                };
            }

            changeEndpointForm.SenderAccountId = ((DataRowView)bdsAccount.Current)[Account.ID_HEADER].ToString();
            changeEndpointForm.ShowDialog();
        }

        private void LoadChangeEnpoints()
        {
            if (!exchangeTransaction.IsAvailable())
                return;

            teInitBalance.EditValue = exchangeTransaction.InitBalance;
            teRemainBalance.EditValue = exchangeTransaction.RemainBalance;
            btnCommit.Enabled = true;
        }

        private void CommitTransaction()
        {
            foreach (var item in exchangeTransaction.Endpoints)
            {
                bufferExchangeTransDataTable.Rows.Add(item.AccountId, item.ExchangeMoney);
            }

            string employeeId = SecurityContext.User.Username;
            string senderAccountId = ((DataRowView)bdsAccount.Current)[Account.ID_HEADER].ToString();

            SqlParameter param0 = new SqlParameter("@SOTK_CHUYEN", senderAccountId);
            SqlParameter param1 = new SqlParameter("@NGAYGD", DateTime.Now);
            SqlParameter param2 = new SqlParameter("@MULTI_EXCHANGE_TABLE", bufferExchangeTransDataTable);
            param2.SqlDbType = SqlDbType.Structured;
            param2.TypeName = "dbo.TBTYPE_MultiExchangeTransaction";
            SqlParameter param3 = new SqlParameter("@MANV", employeeId);
            
            int rowAffected = DataProvider.Instance.ExecuteNonQuery(
                "dbo.usp_InsertTransExchange",
                new SqlParameter[] {param0, param1, param2, param3}
            );

            if (rowAffected > 0)
            {
                MessageUtil.ShowInfoMsgDialog("Lưu giao dịch thành công");
                ReqUpdateCanCloseState.Invoke(this, true);
                teRemainBalance.EditValue = teInitBalance.EditValue = null;
                // Reload account
                btnCommit.Enabled = false;
                LoadAccountFromCustomer();
            }

            bufferExchangeTransDataTable.Clear();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            CommitTransaction();
        }

        private void gvEndpoints_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                ExchangeEndpoint endpoint = (ExchangeEndpoint)e.Row;
                double exchangeMoney = endpoint.ExchangeMoney;
                if (exchangeMoney < 0)
                    throw new ArgumentException("Số tiền chuyển không hợp lệ");
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
                    double exchangeMoney = (double)e.Value;
                    if (exchangeMoney < 0)
                        throw new Exception("Số tiền chuyển không hợp lệ");
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