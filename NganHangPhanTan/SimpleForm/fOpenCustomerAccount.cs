using DevExpress.XtraGrid.Views.Grid;
using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fOpenCustomerAccount : DevExpress.XtraEditors.XtraForm
    {
        private string gridBrandID;

        private Action<Form, bool> reqUpdateCanCloseState;
        private Action<Form> reqClose;

        private LinkedList<UserEventData> undoStack = new LinkedList<UserEventData>();
        private LinkedList<UserEventData> redoStack = new LinkedList<UserEventData>();
        public Action<Form, bool> ReqUpdateCanCloseState { get => reqUpdateCanCloseState; set => reqUpdateCanCloseState = value; }
        public Action<Form> ReqClose { get => reqClose; set => reqClose = value; }

        private bool acceptGvFocusedRowChanging;
        private DataTable bufferAccountDataTable;
        private HashSet<string> unAllowChangeAccountId = new HashSet<string>();

        public fOpenCustomerAccount()
        {
            InitializeComponent();
        }

        private void fOpenCustomerAccount_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.KhachHang' table. You can move, or remove it, as needed.
            this.taCustomer.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taCustomer.Fill(this.DS.KhachHang);
            // TODO: This line of code loads data into the 'DS.TaiKhoan' table. You can move, or remove it, as needed.
            this.taAccount.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;

            ControlUtil.ConfigComboboxBrand(cbBrand);
            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;

            switch (SecurityContext.User.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBrand.Enabled = true;
                    btnInsertAcc.Enabled = btnDeleteAcc.Enabled = false;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBrand.Enabled = false;
                    btnInsertAcc.Enabled = btnDeleteAcc.Enabled = true;

                    this.gridBrandID = BrandDAO.Instance.GetBrandIdOfSubcriber();

                    // Tao cac cot cho data table luu du lieu
                    bufferAccountDataTable = new DataTable();
                    bufferAccountDataTable.Columns.Add(Account.ID_HEADER, typeof(string));
                    bufferAccountDataTable.Columns.Add(Account.CUSTOMER_ID_HEADER, typeof(string));
                    bufferAccountDataTable.Columns.Add(Account.BALANCE_HEADER, typeof(decimal));
                    bufferAccountDataTable.Columns.Add(Account.BRAND_ID_HEADER, typeof(string));
                    bufferAccountDataTable.Columns.Add(Account.OPEN_DATE_HEADER, typeof(DateTime));

                    break;
                default:
                    // DEBUG
                    throw new Exception("User group is unidentified");
            }

            btnReload.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = btnRedo.Enabled = false;
            acceptGvFocusedRowChanging = true;
            cbBrand_SelectionChangeCommitted(null, null);
        }

        private void LoadAccountFromCustomer()
        {
            unAllowChangeAccountId.Clear();

            if (bdsCustomer.Count > 0)
            {
                string customerId = ((DataRowView)bdsCustomer[bdsCustomer.Position])[Customer.ID_HEADER].ToString();
                try
                {
                    // Fill makes gvAccount fires focus row change to the first row
                    this.taAccount.Fill(this.DS.usp_GetAccountByCustomerId, customerId);
                    foreach (DataRowView row in bdsAccount)
                    {
                        unAllowChangeAccountId.Add((string)row[Account.ID_HEADER]);
                    }
                }
                catch (Exception ex)
                {
                    MessageUtil.ShowErrorMsgDialog(ex.Message);
                }
            }

            undoStack.Clear();
            redoStack.Clear();
            if (SecurityContext.User.Group == User.GroupENM.CHI_NHANH)
                btnDeleteAcc.Enabled = (bdsAccount.Count > 0);
            btnSave.Enabled = btnUndo.Enabled = btnRedo.Enabled = false;
            gvAccount.Columns[Account.ID_HEADER].OptionsColumn.ReadOnly = true;
            gvAccount.Columns[Account.BALANCE_HEADER].OptionsColumn.ReadOnly = true;
        }

        private void gvCustomer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (acceptGvFocusedRowChanging == false)
                return;

            if (!btnSave.Enabled)
            {
                LoadAccountFromCustomer();
                return;
            }

            DialogResult res = MessageBox.Show("Lưu các thay đổi trên danh sách tài khoản của khách hàng hiện tại?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                SaveAccountData();
            else if (res == DialogResult.No)
                LoadAccountFromCustomer();
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
            taCustomer.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            taCustomer.Fill(this.DS.KhachHang);

            this.taAccount.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;

            this.gridBrandID = BrandDAO.Instance.GetBrandIdOfSubcriber();

            // Load lại dữ liệu tài khoản theo khách hàng
            LoadAccountFromCustomer();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (!btnSave.Enabled)
            {
                LoadAccountFromCustomer();
                return;
            }
            DialogResult res = MessageBox.Show("Bạn đang muốn xem lại danh sách tài khoản mới nhất của khách hàng.\nLưu các thay đổi hiện tại?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                SaveAccountData();
            else if (res == DialogResult.No)
                LoadAccountFromCustomer();
        }

        private void btnInsertAcc_Click(object sender, EventArgs e)
        {
            int gridPos = bdsAccount.Position;
            // bdsAccount.Count tăng lên 1
            bdsAccount.AddNew();

            DataRowView row = (DataRowView)bdsAccount[bdsAccount.Position];
            row[Account.BALANCE_HEADER] = 0;
            row[Account.BRAND_ID_HEADER] = this.gridBrandID;
            row[Account.OPEN_DATE_HEADER] = DateTime.Now;

            // Open for editting
            gvAccount.Columns[Account.ID_HEADER].OptionsColumn.ReadOnly = false;
            gvAccount.Columns[Account.BALANCE_HEADER].OptionsColumn.ReadOnly = false;

            gvAccount.FocusedColumn = gvAccount.Columns[Account.ID_HEADER];
            gvAccount.ShowEditor();

            btnSave.Enabled = btnInsertAcc.Enabled = btnDeleteAcc.Enabled = btnRedo.Enabled = btnReload.Enabled = false;

            ReqUpdateCanCloseState.Invoke(this, false);

            // Push cancel-editing event to undo stack
            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
        }

        private void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            Account deletedAccount = new Account((DataRowView)bdsAccount[bdsAccount.Position]);

            bool accountHavingTransation = AccountDAO.Instance.HavingAnyTransaction(deletedAccount.Id);

            if (accountHavingTransation)
            {
                MessageUtil.ShowErrorMsgDialog($"Không thể xóa tài khoản mã số {deletedAccount.Id} vì đã thực hiện giao dịch.\n");
                return;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa tài khoản mã số {deletedAccount.Id}?") == DialogResult.OK)
            {
                try
                {
                    // Xóa accountId trong set unAllowChangeAccountId
                    unAllowChangeAccountId.Remove(deletedAccount.Id);
                    // Xóa trên máy trước
                    bdsAccount.RemoveCurrent();
                }
                catch (Exception ex)
                {
                    // Phục hồi nếu xóa không thành công
                    unAllowChangeAccountId.Add(deletedAccount.Id);
                    bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, deletedAccount.Id);
                    MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa tài khoản mã số {deletedAccount.Id}. Thử thực hiện lại.\nChi tiết: {ex.Message}");
                    return;
                }

                btnDeleteAcc.Enabled = (bdsAccount.Count > 0);

                // Ignore to save grid pos
                undoStack.AddLast(new UserEventData(UserEventData.EventType.INSERT, deletedAccount, -1));
                btnUndo.Enabled = true;
                ControlUtil.ResolveStackStorage(undoStack);
                redoStack.Clear();
                btnRedo.Enabled = false;
                btnSave.Enabled = true;
            }
        }

        /// <summary>
        /// Save all accounts modified
        /// </summary>
        private void SaveAccountData()
        {
            string customerId = ((DataRowView)bdsCustomer[bdsCustomer.Position])[Customer.ID_HEADER].ToString();
            foreach (DataRowView row in bdsAccount)
            {
                bufferAccountDataTable.Rows.Add(
                    row[Account.ID_HEADER],
                    customerId, //CMND
                    row[Account.BALANCE_HEADER],
                    row[Account.BRAND_ID_HEADER],
                    row[Account.OPEN_DATE_HEADER]);
            }

            int rowAffected = CustomerDAO.Instance.UpdateAccount(bufferAccountDataTable);

            if (rowAffected > 0)
            {
                MessageUtil.ShowInfoMsgDialog("Lưu thay đổi tài khoản của khách hàng thành công");
                btnSave.Enabled = false;
                ReqUpdateCanCloseState.Invoke(this, true);
                // reload accounts
                LoadAccountFromCustomer();
            }
            else if (rowAffected == 0)
            {
                MessageUtil.ShowInfoMsgDialog("Không tìm thấy thay đổi trong dữ liệu tài khoản khách hàng");
                btnSave.Enabled = false;
                ReqUpdateCanCloseState.Invoke(this, true);
            }

            bufferAccountDataTable.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAccountData();
        }

        private void Undo()
        {
            bool undo = true;
            UserEventData action = undoStack.Last();
            undoStack.RemoveLast();
            switch (action.Type)
            {
                case UserEventData.EventType.CANCEL_EDIT:
                    {
                        UndoUnSaveAction(action);
                        break;
                    }
                case UserEventData.EventType.INSERT:
                    {
                        int gridPos = bdsAccount.Position;
                        if (UndoByInsertAction(action))
                        {
                            action.Type = UserEventData.EventType.DELETE;
                            action.GridPos = gridPos;
                            redoStack.AddLast(action);
                        }
                        else
                        {
                            undoStack.AddLast(action);
                            undo = false;
                        }
                        break;
                    }
                case UserEventData.EventType.DELETE:
                    {
                        int res = UndoByDeleteAction(action);
                        if (res == 1)
                        {
                            action.Type = UserEventData.EventType.INSERT;
                            redoStack.AddLast(action);
                            bdsAccount.Position = action.GridPos;
                        }
                        else if (res == 0)
                        {
                            undoStack.AddLast(action);
                            undo = false;
                        }
                        break;
                    }
                case UserEventData.EventType.UPDATE:
                    {
                        Account oldAccount = new Account((DataRowView)bdsAccount[bdsAccount.Find(Account.ID_HEADER, ((Account)action.Content).Id)]);
                        if (UndoByUpdateAction(action))
                        {
                            action.Type = UserEventData.EventType.UPDATE;
                            action.Content = oldAccount;
                            redoStack.AddLast(action);
                        }
                        else
                        {
                            undoStack.AddLast(action);
                            undo = false;
                        }
                        break;
                    }
                default:
                    break;
            }
            if (undo)
            {
                btnDeleteAcc.Enabled = (bdsAccount.Count > 0);
                btnRedo.Enabled = (redoStack.Count > 0);

                // Nút save enabled khi còn tác vụ chưa lưu, hay undo stack khác rỗng
                btnSave.Enabled = btnUndo.Enabled = (undoStack.Count > 0);

                // Nếu nút save enabled thì không thể đóng form
                ReqUpdateCanCloseState.Invoke(this, !btnSave.Enabled);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            bool redo = true;
            UserEventData action = redoStack.Last();
            redoStack.RemoveLast();
            switch (action.Type)
            {
                case UserEventData.EventType.INSERT:
                    {
                        int gridPos = bdsAccount.Position;
                        if (UndoByInsertAction(action))
                        {
                            action.Type = UserEventData.EventType.DELETE;
                            action.GridPos = gridPos;
                            undoStack.AddLast(action);
                        }
                        else
                        {
                            redoStack.AddLast(action);
                            redo = false;
                        }
                        break;
                    }
                case UserEventData.EventType.DELETE:
                    {
                        int res = UndoByDeleteAction(action);
                        if (res == 1)
                        {
                            action.Type = UserEventData.EventType.INSERT;
                            undoStack.AddLast(action);
                            bdsAccount.Position = action.GridPos;
                        }
                        else if (res == 0)
                        {
                            redoStack.AddLast(action);
                            redo = false;
                        }
                        break;
                    }
                case UserEventData.EventType.UPDATE:
                    {
                        Account oldAccount = new Account((DataRowView)bdsAccount[bdsAccount.Find(Account.ID_HEADER, ((Account)action.Content).Id)]);
                        if (UndoByUpdateAction(action))
                        {
                            action.Type = UserEventData.EventType.UPDATE;
                            action.Content = oldAccount;
                            undoStack.AddLast(action);
                        }
                        else
                        {
                            redoStack.AddLast(action);
                            redo = false;
                        }
                        break;
                    }
                default:
                    break;
            }
            if (redo)
            {
                btnDeleteAcc.Enabled = (bdsAccount.Count > 0);
                btnRedo.Enabled = (redoStack.Count > 0);

                // Nút save enabled khi còn tác vụ chưa lưu, hay undo stack khác rỗng
                btnSave.Enabled = btnUndo.Enabled = (undoStack.Count > 0);

                // Nếu nút save enabled thì không thể đóng form
                ReqUpdateCanCloseState.Invoke(this, !btnSave.Enabled);
            }
        }

        private void fOpenCustomerAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ReqClose.Invoke(this);
                e.Cancel = btnSave.Enabled;
            }
        }

        private void UndoUnSaveAction(UserEventData action)
        {
            bdsAccount.RemoveCurrent();
            gvAccount.CloseEditor();
            btnInsertAcc.Enabled = btnReload.Enabled = true;
            btnDeleteAcc.Enabled = (bdsAccount.Count > 0);
        }

        private bool UndoByInsertAction(UserEventData action)
        {
            if (action == null)
                throw new Exception();

            bdsAccount.AddNew();
            Account account = (Account)action.Content;

            DataRowView row = (DataRowView)bdsAccount[bdsAccount.Position];
            row[Account.ID_HEADER] = account.Id;
            row[Account.BALANCE_HEADER] = account.Balance;
            row[Account.BRAND_ID_HEADER] = account.BrandId;
            row[Account.OPEN_DATE_HEADER] = account.OpenDate;

            try
            {
                // Lưu thông tin trên binding source
                bdsAccount.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsAccount.ResetCurrentItem();
                bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, account.Id);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể khôi phục tài khoản mã số {account.Id} đã xóa trước đó.\n{ex.Message}");
                return false;
            }

            return true;
        }

        private int UndoByDeleteAction(UserEventData action)
        {
            Account account = (Account)action.Content;
            bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, account.Id);

            bool accountHavingTransation = (bool)DataProvider.Instance.ExecuteScalar($"SELECT dbo.udf_CheckAccountHavingTransaction(N'{account.Id}')");

            if (accountHavingTransation)
            {
                MessageUtil.ShowErrorMsgDialog($"Không thể xóa tài khoản mã số {account.Id} vì đã thực hiện giao dịch.\n");
                return -1;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa tài khoản mã số {account.Id}?") != DialogResult.OK)
                return 0;

            try
            {
                bdsAccount.RemoveCurrent();
            }
            catch (Exception ex)
            {
                // Phục hồi nếu xóa không thành công
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa tài khoản mã số {account.Id}. Thử thực hiện lại.\nChi tiết: {ex.Message}");
                bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, account.Id);
                return 0;
            }

            btnDeleteAcc.Enabled = bdsAccount.Count != 0;
            return 1;
        }

        /// <summary>
        /// (UNUSED)
        /// Undo by update action and return previous row data.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private bool UndoByUpdateAction(UserEventData action)
        {
            Account updatedAccount = (Account)action.Content;

            bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, updatedAccount.Id);

            DataRowView row = (DataRowView)bdsAccount[bdsAccount.Position];
            row[Account.ID_HEADER] = updatedAccount.Id;
            row[Account.BALANCE_HEADER] = updatedAccount.Balance;
            row[Account.BRAND_ID_HEADER] = updatedAccount.BrandId;
            row[Account.OPEN_DATE_HEADER] = updatedAccount.OpenDate;

            try
            {
                // Lưu thông tin trên binding source
                bdsAccount.EndEdit();
                // Đặt thông tin tài khoản mới lên grid control
                bdsAccount.ResetCurrentItem();
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể hiệu chỉnh tài khoản.\nChi tiết: {ex.Message}");
                return false;
            }
            return true;
        }

        private void gvAccount_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedColumn == view.Columns[Account.ID_HEADER])
            {
                string accountId = ((string)e.Value).Trim().ToUpper();
                if (string.IsNullOrEmpty(accountId))
                {
                    e.Valid = false;
                    e.ErrorText = "Mã số tài khoản không được trống";
                    return;
                }

                if (accountId.Length > 9)
                {
                    e.Valid = false;
                    e.ErrorText = "Mã số tài khoản không được vượt quá 9 kí tự";
                    return;
                }

                if (accountId.Contains(" "))
                {
                    e.Valid = false;
                    e.ErrorText = "Mã số tài khoản không hợp lệ vì chứa kí tự trắng";
                    return;
                }

                // Kiểm tra mã tài khoản có tồn tại trên các site (TaiKhoan được nhân bản)
                if (AccountDAO.Instance.ExistById(accountId))
                {
                    e.Valid = false;
                    e.ErrorText = "Mã số tài khoản đã tồn tại. Vui lòng chọn mã khác.";
                    return;
                }

                e.Value = accountId;
            }
            else if (view.FocusedColumn == view.Columns[Account.BALANCE_HEADER])
            {
                decimal accountBalance = decimal.Parse(e.Value.ToString());
                if (accountBalance < 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Số dư tài khoản không hợp lệ";
                    return;
                }

                if (accountBalance < 100000)
                {
                    e.Valid = false;
                    e.ErrorText = "Số dư tài khoản phải ít nhất 100.000 đ";
                    return;
                }
            }
        }

        /// <summary>
        /// Tiến hành validate khi đang edit gvAccount nhưng focus nơi khác.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvAccount_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            // Nếu chọn undo thì không validate
            if (btnUndo.Focused) return;

            bool insertMode = e.RowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle;

            // Validate cho row đang INSERT
            if (insertMode)
            {
                DataRowView row = (DataRowView)e.Row;

                string accountId = row[Account.ID_HEADER].ToString().Trim().ToUpper();
                if (string.IsNullOrEmpty(accountId))
                {
                    e.Valid = false;
                    e.ErrorText = "Mã số tài khoản không được trống";
                }
                else if (accountId.Length > 9)
                {
                    e.Valid = false;
                    e.ErrorText = "Mã số tài khoản không được vượt quá 9 kí tự";
                }
                else if (accountId.Contains(" "))
                {
                    e.Valid = false;
                    e.ErrorText = "Mã số tài khoản không hợp lệ vì chứa kí tự trắng";
                }
                else if (AccountDAO.Instance.ExistById(accountId))
                {
                    e.Valid = false;
                    e.ErrorText = "Mã số tài khoản đã tồn tại. Vui lòng chọn mã khác.";
                }

                if (e.Valid == false)
                {
                    gvAccount.FocusedColumn = gvAccount.Columns[Account.ID_HEADER];
                    gvAccount.ShowEditor();
                    return;
                }

                decimal accountBalance = decimal.Parse(row[Account.BALANCE_HEADER].ToString());
                if (accountBalance < 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Số dư tài khoản không hợp lệ";
                }

                if (accountBalance < 100000)
                {
                    e.Valid = false;
                    e.ErrorText = "Số dư tài khoản phải ít nhất 100.000 đ";
                }

                if (e.Valid == false)
                {
                    gvAccount.FocusedColumn = gvAccount.Columns[Account.BALANCE_HEADER];
                    gvAccount.ShowEditor();
                    return;
                }
            }

            // Dữ liệu tài khoản được thêm hoặc update trên bdsAccount
            bdsAccount.EndEdit();
            bdsAccount.ResetCurrentItem();

            if (undoStack.Count > 0)
            {
                // Pop cancel-editing event from undo stack
                UserEventData action = undoStack.Last();
                //undoStack.RemoveLast();

                // Insert mode
                if (insertMode)
                {
                    // Nếu INSERT, thêm vào undo stack DELETE action
                    action.Type = UserEventData.EventType.DELETE;
                    action.Content = new Account((DataRowView)bdsAccount.Current);
                    // Không cần lưu action.GridPos vì là DELETE action
                }
            }

            //undoStack.AddLast(action);
            //ControlUtil.ResolveStackStorage(undoStack);

            //btnUndo.Enabled = true;

            // Xóa redo stack
            redoStack.Clear();
            btnRedo.Enabled = false;

            btnInsertAcc.Enabled = btnDeleteAcc.Enabled = btnReload.Enabled = true;
            btnSave.Enabled = true;
        }

        /// <summary>
        /// Thực thi khi có lỗi validation trên row gvAccount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvAccount_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            if (btnUndo.Focused)
                Undo();
            else
                MessageUtil.ShowErrorMsgDialog($"{e.ErrorText}.\nVui lòng điền đủ thông tin hoặc chọn Undo để thoát.");
        }

        private void gvAccount_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsAccount.Count == 0 || e.FocusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle
                || e.FocusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle - 1) return;

            string accountId = gvAccount.GetRowCellValue(e.FocusedRowHandle, Account.ID_HEADER).ToString();

            bool accountIdExisted = unAllowChangeAccountId.Contains(accountId);

            gvAccount.Columns[Account.ID_HEADER].OptionsColumn.ReadOnly = accountIdExisted;
            gvAccount.Columns[Account.BALANCE_HEADER].OptionsColumn.ReadOnly = accountIdExisted;
        }

    }
}