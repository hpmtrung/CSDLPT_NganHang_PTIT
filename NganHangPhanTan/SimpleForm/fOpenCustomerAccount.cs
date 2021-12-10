using DevExpress.XtraGrid.Views.Grid;
using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fOpenCustomerAccount : DevExpress.XtraEditors.XtraForm
    {
        private User user;
        private string gridBrandID;

        private Action<Form, bool> reqUpdateCanCloseState;
        private Action<Form> reqClose;

        private LinkedList<UserEventData> undoStack = new LinkedList<UserEventData>();
        private LinkedList<UserEventData> redoStack = new LinkedList<UserEventData>();
        public Action<Form, bool> ReqUpdateCanCloseState { get => reqUpdateCanCloseState; set => reqUpdateCanCloseState = value; }
        public Action<Form> ReqClose { get => reqClose; set => reqClose = value; }

        private bool acceptFocusedRowChanging;

        private DataTable bufferAccountDataTable;

        private MyCache accountUnAllowChangeCache = new MyCache(Account.ID_HEADER);

        public fOpenCustomerAccount(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void khachHangBindingNavigatorSaveItem_Click(object sender, System.EventArgs e)
        {
            this.Validate();
            this.bdsCustomer.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);
        }

        private bool IsAccountIdExistedInGridView(string accountId)
        {
            foreach (DataRowView row in bdsAccount)
            {
                if (row[Account.ID_HEADER].ToString().Equals(accountId))
                    return true;
            }
            return false;
        }

        private void fOpenCustomerAccount_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.KhachHang' table. You can move, or remove it, as needed.
            this.taCustomer.Connection.ConnectionString = DataProvider.UniqueInstance.ConnectionStr;
            this.taCustomer.Fill(this.DS.KhachHang);
            // TODO: This line of code loads data into the 'DS.TaiKhoan' table. You can move, or remove it, as needed.
            this.taAccount.Connection.ConnectionString = DataProvider.UniqueInstance.ConnectionStr;

            ControlUtil.ConfigComboboxBrand(cbBrand);
            cbBrand.SelectedIndex = this.user.BrandIndex;

            switch (this.user.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBrand.Enabled = true;
                    btnInsertAcc.Enabled = btnDeleteAcc.Enabled = false;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBrand.Enabled = false;
                    btnInsertAcc.Enabled = btnDeleteAcc.Enabled = true;

                    if (bdsCustomer.Count > 0)
                        this.gridBrandID = ((DataRowView)bdsCustomer[0])[Brand.ID_HEADER].ToString();
                    else
                        this.gridBrandID = BrandDAO.UniqueInstance.GetBrandIdOfSubcriber();

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
            acceptFocusedRowChanging = true;
        }

        private void LoadAccountFromCustomer()
        {
            // DEBUG
            //if (btnSave.Enabled == true)
            //    throw new Exception();

            if (bdsCustomer.Count > 0)
            {
                string customerId = ((DataRowView)bdsCustomer[bdsCustomer.Position])[Customer.ID_HEADER].ToString();
                try
                {
                    this.taAccount.Fill(this.DS.usp_GetAccountByCustomerId, customerId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                bdsAccount.Clear();
            }

            undoStack.Clear();
            redoStack.Clear();
            btnDeleteAcc.Enabled = (bdsAccount.Count > 0);
            btnSave.Enabled = btnUndo.Enabled = btnRedo.Enabled = false;

            accountUnAllowChangeCache.Clear();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (acceptFocusedRowChanging == false)
                return;

            if (btnSave.Enabled == true)
            {
                DialogResult res = MessageBox.Show("Lưu các thay đổi trên danh sách tài khoản của khách hàng hiện tại?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    btnSave_Click(null, new EventArgs());
                }
                else if (res == DialogResult.Cancel)
                {
                    if (e.PrevFocusedRowHandle >= 0)
                    {
                        acceptFocusedRowChanging = false;
                        gvCustomer.FocusedRowHandle = e.PrevFocusedRowHandle;
                        acceptFocusedRowChanging = true;
                    }
                    return;
                }
            }
            LoadAccountFromCustomer();
        }

        private void cbBrand_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Nếu combobox chi nhánh chưa load danh sách phân mãnh thì thoát
            if (cbBrand.SelectedValue.ToString().Equals("System.Data.RowView"))
                return;
            string serverName = cbBrand.SelectedValue.ToString();
            if (cbBrand.SelectedIndex != this.user.BrandIndex)
                DataProvider.UniqueInstance.SetServerToRemote(serverName);
            else
                DataProvider.UniqueInstance.SetServerToSubcriber(serverName, user.Login, user.Pass);
            if (DataProvider.UniqueInstance.TestConnection() == false)
            {
                MessageBox.Show("Lỗi kết nối sang chi nhánh mới.");
                return;
            }
            // Tải dữ liệu từ site mới về
            taCustomer.Connection.ConnectionString = DataProvider.UniqueInstance.ConnectionStr;
            taCustomer.Fill(this.DS.KhachHang);
            this.taAccount.Connection.ConnectionString = DataProvider.UniqueInstance.ConnectionStr;

            if (bdsCustomer.Count > 0)
                this.gridBrandID = ((DataRowView)bdsCustomer[0])[Brand.ID_HEADER].ToString();
            else
                this.gridBrandID = BrandDAO.UniqueInstance.GetBrandIdOfSubcriber();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                DialogResult res = MessageBox.Show("Bạn đang muốn xem lại danh sách tài khoản mới nhất của khách hàng.\nLưu các thay đổi hiện tại?", "Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    btnSave_Click(null, new EventArgs());
                }
                else if (res == DialogResult.Cancel)
                    return;
            }
            LoadAccountFromCustomer();
        }

        private void btnInsertAcc_Click(object sender, EventArgs e)
        {
            int gridPos = bdsAccount.Position;
            bdsAccount.AddNew();

            //DataRowView row = (DataRowView)bdsAccount[bdsAccount.Position];
            //row[Account.BALANCE_HEADER] = 0;
            //row[Account.BRAND_ID_HEADER] = this.gridBrandID;
            //row[Account.OPEN_DATE_HEADER] = DateTime.Now;

            gvAccount.SetRowCellValue(bdsAccount.Position, Account.BALANCE_HEADER, 0);
            gvAccount.SetRowCellValue(bdsAccount.Position, Account.BRAND_ID_HEADER, this.gridBrandID);
            gvAccount.SetRowCellValue(bdsAccount.Position, Account.OPEN_DATE_HEADER, DateTime.Now);

            gvAccount.Columns[Account.ID_HEADER].OptionsColumn.ReadOnly = false;
            gvAccount.Columns[Account.BALANCE_HEADER].OptionsColumn.ReadOnly = false;

            gvAccount.FocusedColumn = gvAccount.Columns[Account.ID_HEADER];
            gvAccount.ShowEditor();

            btnInsertAcc.Enabled = btnDeleteAcc.Enabled = btnReload.Enabled = false;
            btnUndo.Enabled = true;

            btnRedo.Enabled = false;

            ReqUpdateCanCloseState.Invoke(this, false);

            // Push cancel-editing event to undo stack
            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
        }

        private void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            Account deletedAccount = new Account((DataRowView)bdsAccount[bdsAccount.Position]);
            if (MessageBox.Show($"Xác nhận xóa tài khoản mã số {deletedAccount.Id}?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    // Xóa trên máy trước
                    bdsAccount.RemoveCurrent();
                }
                catch (Exception ex)
                {
                    // Phục hồi nếu xóa không thành công
                    MessageBox.Show($"Lỗi không thể xóa tài khoản mã số {deletedAccount.Id}. Thử thực hiện lại.\n{ex.Message}", "", MessageBoxButtons.OK);
                    bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, deletedAccount.Id);
                    return;
                }

                btnDeleteAcc.Enabled = (bdsAccount.Count > 0);

                // Ignore to save grid pos
                undoStack.AddLast(new UserEventData(UserEventData.EventType.INSERT, deletedAccount, -1));
                ControlUtil.ResolveStackStorage(undoStack);
                redoStack.Clear();
                btnRedo.Enabled = false;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string customerId = ((DataRowView)bdsCustomer[bdsCustomer.Position])[Customer.ID_HEADER].ToString();
            foreach (DataRowView row in bdsAccount)
            {
                bufferAccountDataTable.Rows.Add(row[Account.ID_HEADER], customerId,
                    row[Account.BALANCE_HEADER], row[Account.BRAND_ID_HEADER], row[Account.OPEN_DATE_HEADER]);
            }

            int res = DataProvider.UniqueInstance.ExecuteNonQuery("EXEC dbo.usp_UpdateCustomerAccounts @UpdatedAccounts", new object[] { bufferAccountDataTable });

            if (res > 0)
            {
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                ReqUpdateCanCloseState.Invoke(this, true);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
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
                            break;
                        }
                    case UserEventData.EventType.DELETE:
                        {
                            if (UndoByDeleteAction(action))
                            {
                                action.Type = UserEventData.EventType.INSERT;
                                redoStack.AddLast(action);
                                bdsAccount.Position = action.GridPos;
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            UpdateDataCell updatedCell = action.Content as UpdateDataCell;
                            object oldValue = UndoByUpdateAction(action);
                            updatedCell.Content = oldValue;
                            redoStack.AddLast(action);
                            break;
                        }
                    default:
                        break;
                }
                btnRedo.Enabled = (redoStack.Count > 0);
            }
            btnUndo.Enabled = (undoStack.Count > 0);
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
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
                            break;
                        }
                    case UserEventData.EventType.DELETE:
                        {
                            if (UndoByDeleteAction(action))
                            {
                                action.Type = UserEventData.EventType.INSERT;
                                undoStack.AddLast(action);
                                bdsAccount.Position = action.GridPos;
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            UpdateDataCell updatedCell = action.Content as UpdateDataCell;
                            //updatedCell.Content = UndoByUpdateAction(action);
                            object oldValue = UndoByUpdateAction(action);
                            if (oldValue == null)
                                oldValue = Activator.CreateInstance(gvAccount.Columns[updatedCell.FieldName].ColumnType);
                            updatedCell.Content = oldValue;
                            undoStack.AddLast(action);
                            break;
                        }
                    default:
                        break;
                }
                btnUndo.Enabled = (undoStack.Count > 0);
            }
            btnRedo.Enabled = (redoStack.Count > 0);
        }

        private void fOpenCustomerAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ReqClose.Invoke(this);
                e.Cancel = (btnSave.Enabled == false);
            }
        }

        private void UndoUnSaveAction(UserEventData action)
        {
            bdsAccount.CancelEdit();
            bdsAccount.Position = action.GridPos;

            btnInsertAcc.Enabled = btnReload.Enabled = true;
            btnDeleteAcc.Enabled = (bdsAccount.Count > 0);
            btnUndo.Enabled = (undoStack.Count > 0);
            btnRedo.Enabled = (redoStack.Count > 0);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không thể khôi phục tài khoản mã số {account.Id} đã xóa trước đó.\n{ex.Message}", "", MessageBoxButtons.OK);
                return false;
            }

            bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, account.Id);
            return true;
        }

        private bool UndoByDeleteAction(UserEventData action)
        {
            Account account = (Account)action.Content;
            bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, account.Id);

            bool accountHavingTransation = (bool)DataProvider.UniqueInstance.ExecuteScalar($"SELECT dbo.udf_CheckAccountHavingTransaction(N'{account.Id}')");

            if (accountHavingTransation)
            {
                MessageBox.Show($"Không thể xóa tài khoản mã số {account.Id} vì đã thực hiện giao dịch.\n", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (MessageBox.Show($"Xác nhận xóa tài khoản mã số {account.Id}?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    bdsAccount.RemoveCurrent();
                }
                catch (Exception ex)
                {
                    // Phục hồi nếu xóa không thành công
                    MessageBox.Show($"Lỗi không thể xóa tài khoản mã số {account.Id}. Thử thực hiện lại.\n{ex.Message}", "", MessageBoxButtons.OK);
                    bdsAccount.Position = bdsAccount.Find(Account.ID_HEADER, account.Id);
                    return false;
                }

                if (bdsAccount.Count == 0)
                    btnDeleteAcc.Enabled = false;

                return true;
            }
            return false;
        }

        /// <summary>
        /// Undo by update action and return previous data in cell.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private object UndoByUpdateAction(UserEventData action)
        {
            UpdateDataCell updatedCell = action.Content as UpdateDataCell;
            string updatedAccountId = updatedCell.RowId.ToString();
            string fieldName = updatedCell.FieldName;
            object content = null;
            for (int i = 0; i < bdsAccount.Count; i++)
            {
                DataRowView row = (DataRowView)bdsAccount[i];
                if (row[Account.ID_HEADER].Equals(updatedAccountId))
                {
                    content = row[fieldName];
                    row.BeginEdit();
                    row[fieldName] = updatedCell.Content;
                    gvAccount.FocusedRowHandle = i;
                    gvAccount.FocusedColumn = gvAccount.Columns[fieldName];
                    gvAccount.ShowEditor();
                    break;
                }
            }
            // DEBUG
            if (content == null)
                throw new Exception();

            return content;
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

                if (AccountDAO.UniqueInstance.IsAccountIdExisted(accountId))
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
                    e.ErrorText = "Số dư tài khoản không được âm.";
                    return;
                }
            }
        }

        private void btnUpdateAcc_Click(object sender, EventArgs e)
        {
            string accountId = ((DataRowView)bdsAccount[bdsAccount.Position])[Account.ID_HEADER].ToString();

            if (AccountDAO.UniqueInstance.IsAccountIdExisted(accountId))
            {
                MessageBox.Show("Không thể hiệu chỉnh trên tài khoản đã lưu vào cơ sở dữ liệu.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int gridPos = bdsAccount.Position;

            gvAccount.Columns[Account.ID_HEADER].OptionsColumn.ReadOnly = false;
            gvAccount.Columns[Account.BALANCE_HEADER].OptionsColumn.ReadOnly = false;

            gvAccount.ShowEditor();

            btnInsertAcc.Enabled = btnDeleteAcc.Enabled = btnReload.Enabled = false;
            btnUndo.Enabled = true;
            btnRedo.Enabled = false;

            ReqUpdateCanCloseState.Invoke(this, false);

            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            ControlUtil.ResolveStackStorage(undoStack);
        }

        private void gvAccount_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            // If user click undo
            if (btnUndo.Focused)
                return;

            // Save old data for undoing if save for update
            if (btnInsertAcc.Enabled == false)
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
                else if (AccountDAO.UniqueInstance.IsAccountIdExisted(accountId))
                {
                    e.Valid = false;
                    e.ErrorText = "Mã số tài khoản đã tồn tại. Vui lòng chọn mã khác.";
                }

                if (e.Valid == false)
                {
                    gvAccount.FocusedColumn = gvAccount.Columns[Account.ID_HEADER];
                    return;
                }

                decimal accountBalance = decimal.Parse(row[Account.BALANCE_HEADER].ToString());
                if (accountBalance < 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Số dư tài khoản không được âm.";
                }

                if (e.Valid == false)
                {
                    gvAccount.FocusedColumn = gvAccount.Columns[Account.BALANCE_HEADER];
                    return;
                }
            }

            bdsAccount.EndEdit();
            bdsAccount.ResetCurrentItem();

            redoStack.Clear();
            btnRedo.Enabled = false;

            btnInsertAcc.Enabled = btnDeleteAcc.Enabled = btnReload.Enabled = true;
            btnSave.Enabled = true;
        }

        // Fires when a row fails validation or when it cannot be saved to the data source.
        private void gvAccount_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            // 
            if (btnUndo.Focused)
            {
                btnUndo_Click(null, new EventArgs());
                return;
            }
            MessageBox.Show($"{e.ErrorText}.\nVui lòng điền lại thông tin hoặc chọn Undo để thoát.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            gvAccount.ShowEditor();
        }

        private void gvAccount_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            MessageBox.Show("gvAccount_RowDeleted", "");
        }

        private void gvAccount_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            MessageBox.Show("gvAccount_RowDeleting", "");
        }

        private void gvAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                e.Handled = true;
        }

        private void gvAccount_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bdsAccount.Count == 0 || e.FocusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle)
                return;
            bool accountIdExisted = AccountDAO.UniqueInstance.IsAccountIdExisted(gvAccount.GetRowCellValue(e.FocusedRowHandle, Account.ID_HEADER).ToString());
            gvAccount.Columns[Account.ID_HEADER].OptionsColumn.ReadOnly = accountIdExisted;
            gvAccount.Columns[Account.BALANCE_HEADER].OptionsColumn.ReadOnly = accountIdExisted;
        }

        // The event does not fire when a cell value changes on a data source level
        private void gvAccount_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string fieldName = e.Column.FieldName;
            if (!fieldName.Equals(Account.ID_HEADER) && !fieldName.Equals(Account.BALANCE_HEADER))
                return;

            object o = gvAccount.GetRowCellValue(e.RowHandle, Account.ID_HEADER);
            if (o == null)
                return;
            
            string updatedAccountId = o.ToString();

            object oldValue = gvAccount.ActiveEditor.OldEditValue;
            //if (oldValue == null)
            //    oldValue = Activator.CreateInstance(e.Column.ColumnType);

            UpdateDataCell updatedCell = new UpdateDataCell(updatedAccountId, fieldName, oldValue);
            undoStack.AddLast(new UserEventData(UserEventData.EventType.UPDATE, updatedCell, -1));
            btnUndo.Enabled = true;
            redoStack.Clear();
            btnRedo.Enabled = false;
        }

        private void gvAccount_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Unchanged" && e.IsGetData)
            {
                object accountId = gvAccount.GetRowCellValue(e.ListSourceRowIndex, Account.ID_HEADER);
                // When insert new row
                if (accountId == null || accountId is System.DBNull)
                    return;

                object value = accountUnAllowChangeCache.GetValue(e.Row);
                if (value != null)
                    e.Value = value;
                else
                {
                    bool accountIdExisted = AccountDAO.UniqueInstance.IsAccountIdExisted(accountId.ToString());
                    value = accountIdExisted ? "" : "*";
                    accountUnAllowChangeCache.SetValue(e.Row, value);
                    e.Value = value;
                }
            }
        }
    }
}