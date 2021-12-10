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
        private User user;
        private string gridBrandID;

        private Action<Form, bool> reqUpdateCanCloseState;
        private Action<Form> reqClose;

        private LinkedList<UserEventData> undoStack = new LinkedList<UserEventData>();
        private LinkedList<UserEventData> redoStack = new LinkedList<UserEventData>();

        private fEmployeeMove formEmployeeMove;

        public Action<Form, bool> ReqUpdateCanCloseState { get => reqUpdateCanCloseState; set => reqUpdateCanCloseState = value; }
        public Action<Form> ReqClose { get => reqClose; set => reqClose = value; }

        public fEmployeeManage(User user)
        {
            InitializeComponent();
            this.user = user;
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

            this.taEmployee.Connection.ConnectionString = DataProvider.UniqueInstance.ConnectionStr;
            this.taEmployee.Fill(this.DS.NhanVien);
            this.taMoneyTransfer.Connection.ConnectionString = DataProvider.UniqueInstance.ConnectionStr;
            this.taMoneyTransfer.Fill(this.DS.GD_CHUYENTIEN);
            this.taMoneyExchange.Connection.ConnectionString = DataProvider.UniqueInstance.ConnectionStr;
            this.taMoneyExchange.Fill(this.DS.GD_GOIRUT);

            ControlUtil.ConfigComboboxBrand(cbBrand);
            cbBrand.SelectedIndex = this.user.BrandIndex;

            switch (this.user.Group)
            {
                case DTO.User.GroupENM.NGAN_HANG:
                    cbBrand.Enabled = true;
                    btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = false;
                    break;
                case DTO.User.GroupENM.CHI_NHANH:
                    cbBrand.Enabled = false;
                    btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = true;
                    break;
                default:
                    // DEBUG
                    throw new Exception("User group is unidentified");
            }
            btnReload.Enabled = btnExit.Enabled = true;
            btnEmployeeMove.Enabled = btnSave.Enabled = btnUndo.Enabled = btnRedo.Enabled = false;
            pnInput.Enabled = false;
            txbId.Enabled = false;
            ControlUtil.ConfigComboboxGender(cbGender);

            if (bdsEmployee.Count > 0)
            {
                this.gridBrandID = ((DataRowView)bdsEmployee[0])[Brand.ID_HEADER].ToString();
                btnEmployeeMove.Enabled = true;
            }
            else
            {
                this.gridBrandID = BrandDAO.UniqueInstance.GetBrandIdOfSubcriber();
                btnEmployeeMove.Enabled = false;
            }
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsEmployee.Position;
            pnInput.Enabled = true;
            bdsEmployee.AddNew();
            txbBrandId.Text = this.gridBrandID;
            gcEmployee.Enabled = false;
            cbGender.SelectedIndex = 0;
            txbId.Enabled = true;
            txbId.Focus();
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;

            btnSave.Tag = btnUndo.Tag = btnInsert;

            ReqUpdateCanCloseState.Invoke(this, false);

            // Push cancel-editing event to undo stack
            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
        }

        private void UndoUnSaveAction(UserEventData action)
        {
            bdsEmployee.CancelEdit();
            if (btnUndo.Tag == btnInsert)
            {
                bdsEmployee.Position = action.GridPos;
                bdsEmployee.RemoveAt(bdsEmployee.Count - 1);
            }
            gcEmployee.Enabled = true;
            pnInput.Enabled = false;
            btnInsert.Enabled = btnUpdate.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            txbId.Enabled = false;
            if (undoStack.Count > 0)
                btnUndo.Enabled = true;
            btnSave.Tag = btnUndo.Tag = null;

            if (bdsEmployee.Count > 0)
                btnDelete.Enabled = true;

            ReqUpdateCanCloseState.Invoke(this, true);

            if (redoStack.Count > 0)
                btnRedo.Enabled = true;
        }

        private bool UndoByInsertAction(UserEventData action)
        {
            if (action == null)
                throw new Exception();
            bdsEmployee.AddNew();
            txbBrandId.Text = this.gridBrandID;
            //cbGender.SelectedIndex = 0;
            Employee employee = (Employee)action.Content;
            txbId.Text = employee.Id;
            txbLastName.Text = employee.LastName;
            txbFirstName.Text = employee.FirstName;
            txbAddress.Text = employee.Address;
            txbPhoneNum.Text = employee.PhoneNum;
            cbGender.SelectedItem = employee.Gender;

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
                MessageBox.Show($"Lỗi không thể thêm nhân viên mới.\n{ex.Message}", "", MessageBoxButtons.OK);
                return false;
            }
            btnEmployeeMove.Enabled = (cbBrand.Items.Count > 1);
            taEmployee.Fill(this.DS.NhanVien);
            bdsEmployee.Position = bdsEmployee.Find(Employee.ID_HEADER, employee.Id);
            return true;
        }

        private bool UndoByDeleteAction(UserEventData action)
        {
            Employee employee = (Employee)action.Content;
            bdsEmployee.Position = bdsEmployee.Find(Employee.ID_HEADER, employee.Id);

            if (bdsMoneyExchange.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên đã giao dịch gửi/rút tiền.\n", "", MessageBoxButtons.OK);
                return false;
            }

            if (bdsMoneyTransfer.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên đã giao dịch chuyển tiền.", "", MessageBoxButtons.OK);
                return false;
            }

            if (MessageBox.Show("Xác nhận xóa nhân viên?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
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
                    MessageBox.Show($"Lỗi không thể xóa nhân viên. Thử thực hiện lại.\n{ex.Message}", "", MessageBoxButtons.OK);
                    taEmployee.Fill(this.DS.NhanVien);
                    bdsEmployee.Position = bdsEmployee.Find(Employee.ID_HEADER, employee.Id);
                    return false;
                }
                if (bdsEmployee.Count == 0)
                {
                    btnDelete.Enabled = false;
                    btnEmployeeMove.Enabled = false;
                }
                return true;
            }
            return false;
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
                MessageBox.Show($"Lỗi không thể hiệu chỉnh nhân viên.\n{ex.Message}", "", MessageBoxButtons.OK);
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
                            break;
                        }
                    case UserEventData.EventType.DELETE:
                        {
                            if (UndoByDeleteAction(action))
                            {
                                action.Type = UserEventData.EventType.INSERT;
                                redoStack.AddLast(action);
                                bdsEmployee.Position = action.GridPos;
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
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;
            btnSave.Tag = btnUndo.Tag = btnUpdate;

            ReqUpdateCanCloseState.Invoke(this, false);

            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            ControlUtil.ResolveStackStorage(undoStack);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            taEmployee.Fill(this.DS.NhanVien);
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Không thể xóa nhân viên đang là user
            if (((DataRowView)bdsEmployee[bdsEmployee.Position])[Employee.ID_HEADER].ToString().Equals(user.Username))
            {
                MessageBox.Show("Bạn chỉ được thay đổi thông tin của mình, không thể xóa.", "", MessageBoxButtons.OK);
                return;
            }

            if (bdsMoneyExchange.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên đã giao dịch gửi/rút tiền.", "", MessageBoxButtons.OK);
                return;
            }

            if (bdsMoneyTransfer.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên đã giao dịch chuyển tiền.", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Xác nhận xóa nhân viên?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                    MessageBox.Show($"Lỗi không thể xóa nhân viên. Thử thực hiện lại.\n{ex.Message}", "", MessageBoxButtons.OK);
                    taEmployee.Fill(this.DS.NhanVien);
                    bdsEmployee.Position = bdsEmployee.Find(Employee.ID_HEADER, deletedEmployee.Id);
                    return;
                }
                if (bdsEmployee.Count == 0)
                    btnDelete.Enabled = false;

                // Ignore to save grid pos
                undoStack.AddLast(new UserEventData(UserEventData.EventType.INSERT, deletedEmployee, -1));
                ControlUtil.ResolveStackStorage(undoStack);
                redoStack.Clear();
                btnRedo.Enabled = false;
                if (bdsEmployee.Count == 0)
                    btnEmployeeMove.Enabled = false;
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Save old data for undoing if save for update
            Employee oldEmployee = null;
            string employeeID = "";
            if (btnSave.Tag == btnUpdate)
            {
                oldEmployee = new Employee(((DataRowView)bdsEmployee[bdsEmployee.Position]));
            }
            else
            {
                // Kiểm tra các ràng buộc
                employeeID = txbId.Text.Trim();
                if (string.IsNullOrEmpty(employeeID))
                {
                    MessageBox.Show("Mã nhân viên không được để trống.", "", MessageBoxButtons.OK);
                    txbId.Focus();
                    return;
                }

                if (employeeID.Contains(" "))
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ.", "", MessageBoxButtons.OK);
                    txbId.Focus();
                    return;
                }

                if (employeeID.Length > 10)
                {
                    MessageBox.Show("Mã nhân viên không được vượt quá 10 kí tự.", "", MessageBoxButtons.OK);
                    txbId.Focus();
                    return;
                }

                employeeID = employeeID.ToUpper();
                txbId.Text = employeeID;
            }

            string lastName = txbLastName.Text.Trim();
            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Họ tên nhân viên không được để trống.", "", MessageBoxButtons.OK);
                txbLastName.Focus();
                return;
            }

            lastName = ControlUtil.RemoveDuplicateSpace(lastName);
            lastName = ControlUtil.CapitalizeFirstLetter(lastName);
            txbLastName.Text = lastName;

            string firstName = txbFirstName.Text.Trim();
            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Họ tên nhân viên không được để trống.", "", MessageBoxButtons.OK);
                txbFirstName.Focus();
                return;
            }

            if (firstName.Contains(" "))
            {
                MessageBox.Show("Tên nhân viên không hợp lệ.", "", MessageBoxButtons.OK);
                txbFirstName.Focus();
                return;
            }

            firstName = ControlUtil.CapitalizeFirstLetter(firstName);
            txbFirstName.Text = firstName;

            string address = txbAddress.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Địa chỉ nhân viên không được để trống.", "", MessageBoxButtons.OK);
                txbAddress.Focus();
                return;
            }

            address = ControlUtil.RemoveDuplicateSpace(address);
            txbAddress.Text = address;

            string phoneNum = txbPhoneNum.Text.Trim();
            if (string.IsNullOrEmpty(phoneNum))
            {
                MessageBox.Show("Số điện thoại nhân viên không được để trống.", "", MessageBoxButtons.OK);
                txbPhoneNum.Focus();
                return;
            }

            if (!phoneNum.All(Char.IsDigit))
            {
                MessageBox.Show("Số điện thoại nhân viên không hợp lệ.", "", MessageBoxButtons.OK);
                txbPhoneNum.Focus();
                return;
            }

            if (phoneNum.Length != 10)
            {
                MessageBox.Show("Số điện thoại nhân viên không đúng 10 chữ số.", "", MessageBoxButtons.OK);
                txbPhoneNum.Focus();
                return;
            }

            txbPhoneNum.Text = phoneNum;

            if (btnSave.Tag == btnInsert && EmployeeDAO.UniqueInstance.isEmployeeIDExisted(employeeID))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng chọn mã nhân viên khác.", "", MessageBoxButtons.OK);
                txbId.Focus();
                return;
            }

            // KT mã NV tồn tại trên bsdNV nếu có ghi đồng loạt các NV được thêm
            /*
                int indexMaNV = bdsNV.Find("MANV", txtMaNV.Text);

                int indexCurrent = bdsNV.Position;
                if (result_value_MANV == 1 && (indexMaNV != indexCurrent))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
             */
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
                MessageBox.Show($"{msg}.\n{ex.Message}", "", MessageBoxButtons.OK);
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
                action.Type = UserEventData.EventType.DELETE;
                action.Content = new Employee((DataRowView)bdsEmployee[bdsEmployee.Position]);
                // action.GridPos giữ nguyên
            }
            else
            {
                action.Type = UserEventData.EventType.UPDATE;
                action.Content = oldEmployee;
                // action.GridPos: không cần
            }

            undoStack.AddLast(action);
            ControlUtil.ResolveStackStorage(undoStack);
            btnUndo.Enabled = true;

            redoStack.Clear();
            btnRedo.Enabled = false;

            gcEmployee.Enabled = true;
            pnInput.Enabled = false;
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            btnEmployeeMove.Enabled = (cbBrand.Items.Count > 1);
            txbId.Enabled = false;
            btnSave.Tag = btnUndo.Tag = null;

            ReqUpdateCanCloseState.Invoke(this, true);
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
            taEmployee.Connection.ConnectionString = DataProvider.UniqueInstance.ConnectionStr;
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
            if (employeeId.Equals(user.Username))
            {
                MessageBox.Show("Bạn chỉ được thay đổi thông tin của mình, không thể tự chuyển sang chi nhánh khác.", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Xác nhận chuyển nhân viên?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string query = "EXEC dbo.usp_MoveEmployeeToBrand @MANV , @MACN";
                int rowNum = DataProvider.UniqueInstance.ExecuteNonQuery(query, new object[] { employeeId, brandId });
                if (rowNum > 0)
                {
                    MessageBox.Show("Chuyển nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            break;
                        }
                    case UserEventData.EventType.DELETE:
                        {
                            if (UndoByDeleteAction(action))
                            {
                                action.Type = UserEventData.EventType.INSERT;
                                undoStack.AddLast(action);
                                bdsEmployee.Position = action.GridPos;
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