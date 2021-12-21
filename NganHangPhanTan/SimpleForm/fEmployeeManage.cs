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
    public partial class fEmployeeManage : DevExpress.XtraEditors.XtraForm
    {
        private string gridBrandID;

        private Action<Form, bool> reqUpdateCanCloseState;
        private Action<Form> reqClose;

        private LinkedList<UserEventData> undoStack = new LinkedList<UserEventData>();
        private LinkedList<UserEventData> redoStack = new LinkedList<UserEventData>();

        private fEmployeeMove formEmployeeMove;

        public Action<Form, bool> ReqUpdateCanCloseState { get => reqUpdateCanCloseState; set => reqUpdateCanCloseState = value; }
        public Action<Form> ReqClose { get => reqClose; set => reqClose = value; }

        public fEmployeeManage()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsEmployee.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);
        }

        private void fEmployeeManage_Load(object sender, EventArgs e)
        {
            // Không báo lỗi do thiếu dữ liệu FK
            DS.EnforceConstraints = false;

            this.taEmployee.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taEmployee.Fill(this.DS.NhanVien);
            this.taMoneyTransfer.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taMoneyTransfer.Fill(this.DS.GD_CHUYENTIEN);
            this.taMoneyExchange.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taMoneyExchange.Fill(this.DS.GD_GOIRUT);

            ControlUtil.ConfigComboboxBrand(cbBrand);
            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;

            switch (SecurityContext.User.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBrand.Enabled = true;
                    btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = false;
                    btnEmployeeMove.Enabled = false;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBrand.Enabled = false;
                    btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
                    btnEmployeeMove.Enabled = bdsEmployee.Count > 0;
                    break;
                default:
                    // DEBUG
                    throw new Exception("User group is unidentified");
            }

            btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = btnUndo.Enabled = btnRedo.Enabled = false;
            pnInput.Enabled = false;
            txbId.Enabled = false;

            this.gridBrandID = BrandDAO.Instance.GetBrandIdOfSubcriber();
            cbBrand_SelectionChangeCommitted(null, null);
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsEmployee.Position;

            bdsEmployee.AddNew();

            pnInput.Enabled = true;
            txbBrandId.Text = this.gridBrandID;
            gcEmployee.Enabled = false;
            cbGender.SelectedIndex = 0;
            txbId.Enabled = true;
            txbId.Focus();
            btnEmployeeMove.Enabled = btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;

            btnSave.Tag = btnInsert;

            ReqUpdateCanCloseState.Invoke(this, false);

            // Push cancel-editing event to undo stack
            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
        }

        private void UndoUnSaveAction(UserEventData action)
        {
            bdsEmployee.CancelEdit();

            if (btnSave.Tag == btnInsert)
            {
                bdsEmployee.Position = action.GridPos;
                bdsEmployee.RemoveAt(bdsEmployee.Count - 1);
            }

            gcEmployee.Enabled = true;
            pnInput.Enabled = false;
            btnEmployeeMove.Enabled = btnInsert.Enabled = btnUpdate.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            txbId.Enabled = false;
            btnUndo.Enabled = undoStack.Count > 0;

            btnSave.Tag = null;

            btnDelete.Enabled = bdsEmployee.Count > 0;

            ReqUpdateCanCloseState.Invoke(this, true);

            btnRedo.Enabled = redoStack.Count > 0;
        }

        private bool UndoByInsertAction(UserEventData action)
        {
            if (action == null)
                throw new Exception();

            bdsEmployee.AddNew();

            txbBrandId.Text = this.gridBrandID;

            Employee employee = (Employee)action.Content;
            txbId.Text = employee.Id;
            txbLastName.Text = employee.LastName;
            txbFirstName.Text = employee.FirstName;
            txbAddress.Text = employee.Address;
            txbPhoneNum.Text = employee.PhoneNum;
            cbGender.SelectedItem = employee.Gender;

            cbGender.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsEmployee.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsEmployee.ResetCurrentItem();
                taEmployee.Update(this.DS.NhanVien);
                taEmployee.Fill(this.DS.NhanVien);
                bdsEmployee.Position = bdsEmployee.Find(Employee.ID_HEADER, employee.Id);
                btnEmployeeMove.Enabled = SecurityContext.User.Group == DTO.User.GroupENM.CHI_NHANH;
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể khôi phục nhân viên đã xóa có mã số {employee.Id}.\nChi tiết: {ex.Message}");
                return false;
            }
            return true;
        }

        private int UndoByDeleteAction(UserEventData action)
        {
            Employee employee = (Employee)action.Content;
            bdsEmployee.Position = bdsEmployee.Find(Employee.ID_HEADER, employee.Id);

            if (bdsMoneyExchange.Count > 0 || bdsMoneyTransfer.Count > 0)
            {
                MessageUtil.ShowErrorMsgDialog("Không thể xóa nhân viên đã thực hiện giao dịch cho khách hàng");
                return -1;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa nhân viên có mã số {employee.Id}?") != DialogResult.OK)
                return 0;

            try
            {
                // Xóa trên máy trước
                bdsEmployee.RemoveCurrent();
                // Xóa trên server
                taEmployee.Update(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                // Phục hồi nếu xóa không thành công
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa nhân viên. Thử thực hiện lại.\nChi tiết: {ex.Message}");
                taEmployee.Fill(this.DS.NhanVien);
                bdsEmployee.Position = bdsEmployee.Find(Employee.ID_HEADER, employee.Id);
                return 0;
            }
            btnEmployeeMove.Enabled = btnDelete.Enabled = bdsEmployee.Count != 0;
            return 1;
        }

        private bool UndoByUpdateAction(UserEventData action)
        {
            Employee updatedEmployee = (Employee)action.Content;

            bdsEmployee.Position = bdsEmployee.Find(Employee.ID_HEADER, updatedEmployee.Id);

            txbLastName.Text = updatedEmployee.LastName;
            txbFirstName.Text = updatedEmployee.FirstName;
            txbAddress.Text = updatedEmployee.Address;
            txbPhoneNum.Text = updatedEmployee.PhoneNum;
            cbGender.SelectedItem = updatedEmployee.Gender;

            cbGender.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsEmployee.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsEmployee.ResetCurrentItem();
                taEmployee.Update(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể hiệu chỉnh nhân viên.Thử thực hiện lại.\nChi tiết: {ex.Message}");
                return false;
            }
            return true;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                            int gridPos = bdsEmployee.Position;
                            if (UndoByInsertAction(action))
                            {
                                action.Type = UserEventData.EventType.DELETE;
                                action.GridPos = gridPos;
                                redoStack.AddLast(action);
                            }
                            else
                            {
                                undoStack.AddLast(action);
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
                                bdsEmployee.Position = action.GridPos;
                            }
                            else if (res == 0)
                            {
                                undoStack.AddLast(action);
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            Employee oldEmployee = new Employee(((DataRowView)bdsEmployee[bdsEmployee.Find(Employee.ID_HEADER, ((Employee)action.Content).Id)]));
                            if (UndoByUpdateAction(action))
                            {
                                action.Type = UserEventData.EventType.UPDATE;
                                action.Content = oldEmployee;
                                redoStack.AddLast(action);
                            }
                            else
                            {
                                undoStack.AddLast(action);
                            }
                            break;
                        }
                    default:
                        break;
                }
                btnRedo.Enabled = (redoStack.Count > 0);
            }
            btnUndo.Enabled = (undoStack.Count > 0);
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsEmployee.Position;
            pnInput.Enabled = true;
            gcEmployee.Enabled = false;
            btnEmployeeMove.Enabled = btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;
            btnSave.Tag = btnUpdate;

            ReqUpdateCanCloseState.Invoke(this, false);

            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
            ControlUtil.ResolveStackStorage(undoStack);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                taEmployee.Fill(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Xóa nhân viên là chỉ cần xóa sau khi kiểm tra ràng buộc
            // Còn chuyển nhân viên mới dùng tới trạng thái xóa

            // Không thể xóa nhân viên đang là user
            string employeeId = ((DataRowView)bdsEmployee[bdsEmployee.Position])[Employee.ID_HEADER].ToString();
            if (employeeId.Equals(SecurityContext.User.Username))
            {
                MessageUtil.ShowErrorMsgDialog("Bạn chỉ được thay đổi thông tin của mình, không thể xóa.");
                return;
            }

            if (bdsMoneyExchange.Count > 0 || bdsMoneyTransfer.Count > 0)
            {
                MessageUtil.ShowErrorMsgDialog("Không thể xóa nhân viên đã thực hiện giao dịch cho khách hàng");
                return;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa nhân viên có mã số {employeeId}?") == DialogResult.OK)
            {
                Employee deletedEmployee = null;
                try
                {
                    deletedEmployee = new Employee((DataRowView)bdsEmployee[bdsEmployee.Position]);
                    // Xóa trên máy trước
                    bdsEmployee.RemoveCurrent();
                    // Xóa trên server
                    taEmployee.Update(this.DS.NhanVien);
                }
                catch (Exception ex)
                {
                    // Phục hồi nếu xóa không thành công
                    MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa nhân viên. Thử thực hiện lại.\nChi tiết: {ex.Message}");
                    taEmployee.Fill(this.DS.NhanVien);
                    bdsEmployee.Position = bdsEmployee.Find(Employee.ID_HEADER, deletedEmployee.Id);
                    return;
                }

                btnDelete.Enabled = bdsEmployee.Count != 0;

                // Ignore to save grid pos
                undoStack.AddLast(new UserEventData(UserEventData.EventType.INSERT, deletedEmployee, -1));
                btnUndo.Enabled = true;
                ControlUtil.ResolveStackStorage(undoStack);
                redoStack.Clear();
                btnRedo.Enabled = false;
                btnEmployeeMove.Enabled = bdsEmployee.Count != 0;
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Save old data for undoing if save for update
            Employee oldEmployee = null;
            string employeeID = "";

            if (btnSave.Tag == btnUpdate)
            {
                oldEmployee = new Employee((DataRowView)bdsEmployee[bdsEmployee.Position]);
            }
            else
            {
                // Kiểm tra các ràng buộc
                employeeID = txbId.Text.Trim();
                if (string.IsNullOrEmpty(employeeID))
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được để trống.");
                    txbId.Focus();
                    return;
                }

                if (employeeID.Contains(" "))
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên không hợp lệ");
                    txbId.Focus();
                    return;
                }

                if (employeeID.Length > 10)
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên không được vượt quá 10 kí tự");
                    txbId.Focus();
                    return;
                }

                // Kiểm tra mã nhân viên tồn tại trên site chủ
                if (EmployeeDAO.Instance.IsEmployeeIDExisted(employeeID))
                {
                    MessageUtil.ShowErrorMsgDialog("Mã nhân viên đã tồn tại. Vui lòng chọn mã khác");
                    txbId.Focus();
                    return;
                }

                employeeID = employeeID.ToUpper();
                txbId.Text = employeeID;
            }

            string lastName = txbLastName.Text.Trim();
            if (string.IsNullOrEmpty(lastName))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên nhân viên không được để trống");
                txbLastName.Focus();
                return;
            }

            lastName = ControlUtil.RemoveDuplicateSpace(lastName);
            lastName = ControlUtil.CapitalizeFirstLetter(lastName);
            txbLastName.Text = lastName;

            string firstName = txbFirstName.Text.Trim();
            if (string.IsNullOrEmpty(firstName))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên nhân viên không được để trống");
                txbFirstName.Focus();
                return;
            }

            if (firstName.Contains(" "))
            {
                MessageUtil.ShowErrorMsgDialog("Tên nhân viên không hợp lệ");
                txbFirstName.Focus();
                return;
            }

            firstName = ControlUtil.CapitalizeFirstLetter(firstName);
            txbFirstName.Text = firstName;

            string address = txbAddress.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                MessageUtil.ShowErrorMsgDialog("Địa chỉ nhân viên không được để trống");
                txbAddress.Focus();
                return;
            }

            address = ControlUtil.RemoveDuplicateSpace(address);
            txbAddress.Text = address;

            string phoneNum = txbPhoneNum.Text.Trim();
            if (string.IsNullOrEmpty(phoneNum))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại nhân viên không được để trống");
                txbPhoneNum.Focus();
                return;
            }

            if (!phoneNum.All(Char.IsDigit))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại nhân viên không hợp lệ");
                txbPhoneNum.Focus();
                return;
            }

            if (phoneNum.Length != 10)
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại nhân viên không đúng 10 chữ số");
                txbPhoneNum.Focus();
                return;
            }

            txbPhoneNum.Text = phoneNum;

            cbGender.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsEmployee.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsEmployee.ResetCurrentItem();
                taEmployee.Update(this.DS.NhanVien);
            }
            catch (Exception ex)
            {
                string msg = btnSave.Tag == btnInsert ? "Lỗi không thể thêm nhân viên mới" : "Lỗi không thể hiệu chỉnh nhân viên";
                MessageUtil.ShowErrorMsgDialog($"{msg}.\nChi tiết: {ex.Message}");
                return;
            }

            if (btnSave.Tag == btnInsert)
            {
                taEmployee.Fill(this.DS.NhanVien);
                bdsEmployee.Position = bdsEmployee.Find(Employee.ID_HEADER, employeeID);
            }

            // Pop cancel-editing event from undo stack
            UserEventData action = undoStack.Last();
            undoStack.RemoveLast();

            if (btnSave.Tag == btnInsert)
            {
                // Nếu INSERT, thêm vào undo stack DELETE action
                action.Type = UserEventData.EventType.DELETE;
                action.Content = new Employee((DataRowView)bdsEmployee[bdsEmployee.Position]);
                // Không cần lưu action.GridPos vì là DELETE action
            }
            else
            {
                // Nếu UPDATE, thêm vào undo stack UPDATE action
                action.Type = UserEventData.EventType.UPDATE;
                action.Content = oldEmployee;
                // Không cần lưu action.GridPos vì không cần phục hồi gridPos khi UPDATE
            }

            undoStack.AddLast(action);
            ControlUtil.ResolveStackStorage(undoStack);

            btnUndo.Enabled = true;

            // Xóa redo stack
            redoStack.Clear();
            btnRedo.Enabled = false;

            gcEmployee.Enabled = true;
            pnInput.Enabled = false;
            btnEmployeeMove.Enabled = btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            btnEmployeeMove.Enabled = (cbBrand.Items.Count > 1);
            txbId.Enabled = false;
            btnSave.Tag = null;

            ReqUpdateCanCloseState.Invoke(this, true);
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
                MessageUtil.ShowErrorMsgDialog("Lỗi kết nối sang chi nhánh mới.");
                return;
            }
            // Tải dữ liệu từ site mới về
            taEmployee.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            taEmployee.Fill(this.DS.NhanVien);
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void MoveEmployeeToBrand(string brandId)
        {
            string employeeId = ((DataRowView)bdsEmployee[bdsEmployee.Position])[Employee.ID_HEADER].ToString();

            // Không thể chuyển nhân viên đang là user
            if (employeeId.Equals(SecurityContext.User.Username))
            {
                MessageUtil.ShowErrorMsgDialog("Bạn chỉ được thay đổi thông tin của mình, không thể tự chuyển sang chi nhánh khác.");
                return;
            }

            if (MessageUtil.ShowWarnConfirmDialog("Xác nhận chuyển nhân viên?") == DialogResult.OK)
            {
                string query = "EXEC dbo.usp_MoveEmployeeToBrand @MANV, @MACN";
                int rowNum = DataProvider.Instance.ExecuteNonQuery(query, new object[] { employeeId, brandId });
                if (rowNum > 0)
                {
                    MessageUtil.ShowInfoMsgDialog("Chuyển nhân viên thành công");
                    // Reload
                    this.taEmployee.Fill(this.DS.NhanVien);
                    formEmployeeMove.Close();
                }
            }
        }

        private void btnEmployeeMove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formEmployeeMove = new fEmployeeMove();
            formEmployeeMove.ReqMoveEmployeeToBrandId = MoveEmployeeToBrand;
            formEmployeeMove.ShowDialog(this);
        }

        private void fEmployeeManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ReqClose.Invoke(this);
                e.Cancel = (btnSave.Tag != null);
            }
        }

        private void btnRedo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (redoStack.Count > 0)
            {
                UserEventData action = redoStack.Last();
                redoStack.RemoveLast();
                switch (action.Type)
                {
                    case UserEventData.EventType.INSERT:
                        {
                            int gridPos = bdsEmployee.Position;
                            if (UndoByInsertAction(action))
                            {
                                action.Type = UserEventData.EventType.DELETE;
                                action.GridPos = gridPos;
                                undoStack.AddLast(action);
                            }
                            else
                            {
                                redoStack.AddLast(action);
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
                                bdsEmployee.Position = action.GridPos;
                            }
                            else if (res == 0)
                            {
                                redoStack.AddLast(action);
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            Employee oldEmployee = new Employee(((DataRowView)bdsEmployee[bdsEmployee.Find(Employee.ID_HEADER, ((Employee)action.Content).Id)]));
                            if (UndoByUpdateAction(action))
                            {
                                action.Type = UserEventData.EventType.UPDATE;
                                action.Content = oldEmployee;
                                undoStack.AddLast(action);
                            }
                            else
                            {
                                redoStack.AddLast(action);
                            }
                            break;
                        }
                    default:
                        break;
                }
                btnUndo.Enabled = (undoStack.Count > 0);
            }
            btnRedo.Enabled = (redoStack.Count > 0);
        }
    }
}