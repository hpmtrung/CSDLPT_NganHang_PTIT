using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fTransExchange : DevExpress.XtraEditors.XtraForm
    {
        private Action<Form, bool> reqUpdateCanCloseState;
        private Action<Form> reqClose;
        
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

                    // Enpoint list is empty, so unable to commit
                    btnCommit.Enabled = false;
                    break;
                default:
                    // DEBUG
                    throw new Exception("User group is unidentified");
            }
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
            LoadAccountFromCustomer();
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
            LoadTransFromAccount();
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

        private void btnReload_Click(object sender, EventArgs e)
        {
            // Reload customer data
            string customerId = ((DataRowView)bdsCustomer.Current)[Customer.ID_HEADER].ToString();
            this.taCustomer.Fill(this.DS.usp_GetCustomerHavingAccountInSubcriber);
            bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, customerId);

            // Reload account data
            string accountId = ((DataRowView)bdsAccount.Current)[Account.ID_HEADER].ToString();
            this.taAccount.Fill(this.DS.usp_GetAccountByCustomerId, customerId);
            bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, accountId);

            LoadTransFromAccount();
        }

        private void btnChangeEndpoints_Click(object sender, EventArgs e)
        {

        }

        private void btnCommit_Click(object sender, EventArgs e)
        {

        }
    }
}