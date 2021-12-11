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
    public partial class fCustomerManage : DevExpress.XtraEditors.XtraForm
    {
        private string gridBrandID;

        private Action<Form, bool> reqUpdateCanCloseState;
        private Action<Form> reqClose;

        private LinkedList<UserEventData> undoStack = new LinkedList<UserEventData>();
        private LinkedList<UserEventData> redoStack = new LinkedList<UserEventData>();

        public Action<Form, bool> ReqUpdateCanCloseState { get => reqUpdateCanCloseState; set => reqUpdateCanCloseState = value; }
        public Action<Form> ReqClose { get => reqClose; set => reqClose = value; }

        public fCustomerManage()
        {
            InitializeComponent();
        }

        private void khachHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsCustomer.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);
        }

        private void fCustomerManage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.TaiKhoan' table. You can move, or remove it, as needed.
            this.taAccount.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taAccount.Fill(this.DS.TaiKhoan);
            // TODO: This line of code loads data into the 'dS.KhachHang' table. You can move, or remove it, as needed.
            this.taCustomer.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            this.taCustomer.Fill(this.DS.KhachHang);

            ControlUtil.ConfigComboboxBrand(cbBrand);
            cbBrand.SelectedIndex = SecurityContext.User.BrandIndex;

            switch (SecurityContext.User.Group)
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
            btnSave.Enabled = btnUndo.Enabled = btnRedo.Enabled = false;
            pnInput.Enabled = false;
            txbId.Enabled = false;
            ControlUtil.ConfigComboboxGender(cbGender);

            if (bdsCustomer.Count > 0)
                this.gridBrandID = ((DataRowView)bdsCustomer[0])[Brand.ID_HEADER].ToString();
            else
                this.gridBrandID = BrandDAO.UniqueInstance.GetBrandIdOfSubcriber();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customer oldCustomer = null;
            string customerId = "";
            if (btnSave.Tag == btnUpdate)
            {
                oldCustomer = new Customer(((DataRowView)bdsCustomer[bdsCustomer.Position]));
            }
            else
            {
                // Kiểm tra các ràng buộc
                customerId = txbId.Text.Trim();
                if (string.IsNullOrEmpty(customerId))
                {
                    MessageBox.Show("Mã khách hàng (CMND) không được để trống.", "", MessageBoxButtons.OK);
                    txbId.Focus();
                    return;
                }

                if (customerId.Contains(" "))
                {
                    MessageBox.Show("Mã khách hàng (CMND) không hợp lệ.", "", MessageBoxButtons.OK);
                    txbId.Focus();
                    return;
                }

                if (customerId.Length > 10)
                {
                    MessageBox.Show("Mã khách hàng (CMND) không được vượt quá 10 kí tự.", "", MessageBoxButtons.OK);
                    txbId.Focus();
                    return;
                }
            }

            string lastName = txbLastName.Text.Trim();
            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống.", "", MessageBoxButtons.OK);
                txbLastName.Focus();
                return;
            }

            lastName = ControlUtil.RemoveDuplicateSpace(lastName);
            lastName = ControlUtil.CapitalizeFirstLetter(lastName);
            txbLastName.Text = lastName;

            string firstName = txbFirstName.Text.Trim();
            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống.", "", MessageBoxButtons.OK);
                txbFirstName.Focus();
                return;
            }

            if (firstName.Contains(" "))
            {
                MessageBox.Show("Tên khách hàng không hợp lệ.", "", MessageBoxButtons.OK);
                txbFirstName.Focus();
                return;
            }

            firstName = ControlUtil.CapitalizeFirstLetter(firstName);
            txbFirstName.Text = firstName;

            string address = txbAddress.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Địa chỉ khách hàng không được để trống.", "", MessageBoxButtons.OK);
                txbAddress.Focus();
                return;
            }

            address = ControlUtil.RemoveDuplicateSpace(address);
            txbAddress.Text = address;

            string phoneNum = txbPhoneNum.Text.Trim();
            if (string.IsNullOrEmpty(phoneNum))
            {
                MessageBox.Show("Số điện thoại khách hàng không được để trống.", "", MessageBoxButtons.OK);
                txbPhoneNum.Focus();
                return;
            }

            if (!phoneNum.All(Char.IsDigit))
            {
                MessageBox.Show("Số điện thoại khách hàng không hợp lệ.", "", MessageBoxButtons.OK);
                txbPhoneNum.Focus();
                return;
            }

            if (phoneNum.Length != 10)
            {
                MessageBox.Show("Số điện thoại khách hàng không đúng 10 chữ số.", "", MessageBoxButtons.OK);
                txbPhoneNum.Focus();
                return;
            }

            txbPhoneNum.Text = phoneNum;

            // KT mã KH tồn tại trên bsdNV nếu có ghi đồng loạt các KH được thêm
            /*
                int indexMaKH = bdsCustomer.Find("MAKH", txtMaNV.Text);

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
                bdsCustomer.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsCustomer.ResetCurrentItem();
                taCustomer.Update(this.DS.KhachHang);
            }
            catch (Exception ex)
            {
                string msg = btnSave.Tag == btnInsert ? "Lỗi không thể thêm khách hàng mới" : "Lỗi không thể hiệu chỉnh khách hàng";
                MessageBox.Show($"{msg}.\n{ex.Message}", "", MessageBoxButtons.OK);
                return;
            }

            if (btnSave.Tag == btnInsert)
            {
                taCustomer.Fill(this.DS.KhachHang);
                bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, customerId);
            }

            // Pop cancel-editing event from undo stack
            UserEventData action = undoStack.Last();
            undoStack.RemoveLast();

            if (btnSave.Tag == btnInsert)
            {
                action.Type = UserEventData.EventType.DELETE;
                action.Content = new Customer((DataRowView)bdsCustomer[bdsCustomer.Position]);
                // action.GridPos giữ nguyên
            }
            else
            {
                action.Type = UserEventData.EventType.UPDATE;
                action.Content = oldCustomer;
                // action.GridPos: không cần
            }

            undoStack.AddLast(action);
            ControlUtil.ResolveStackStorage(undoStack);
            btnUndo.Enabled = true;

            redoStack.Clear();
            btnRedo.Enabled = false;

            gcCustomer.Enabled = true;
            pnInput.Enabled = false;
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            txbId.Enabled = false;
            btnSave.Tag = btnUndo.Tag = null;

            ReqUpdateCanCloseState.Invoke(this, true);
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsCustomer.Position;
            pnInput.Enabled = true;
            gcCustomer.Enabled = false;
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;
            btnSave.Tag = btnUndo.Tag = btnUpdate;

            ReqUpdateCanCloseState.Invoke(this, false);

            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            ControlUtil.ResolveStackStorage(undoStack);
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
                            int gridPos = bdsCustomer.Position;
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
                                bdsCustomer.Position = action.GridPos;
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            Customer oldCustomer = new Customer(((DataRowView)bdsCustomer[bdsCustomer.Find(Customer.ID_HEADER, ((Customer)action.Content).Id)]));
                            if (UndoByUpdateAction(action))
                            {
                                action.Type = UserEventData.EventType.UPDATE;
                                action.Content = oldCustomer;
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
                            int gridPos = bdsCustomer.Position;
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
                                bdsCustomer.Position = action.GridPos;
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            Customer oldCustomer = new Customer(((DataRowView)bdsCustomer[bdsCustomer.Find(Customer.ID_HEADER, ((Customer)action.Content).Id)]));
                            if (UndoByUpdateAction(action))
                            {
                                action.Type = UserEventData.EventType.UPDATE;
                                action.Content = oldCustomer;
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

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            taCustomer.Fill(this.DS.KhachHang);
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void UndoUnSaveAction(UserEventData action)
        {
            bdsCustomer.CancelEdit();
            if (btnUndo.Tag == btnInsert)
            {
                bdsCustomer.Position = action.GridPos;
                bdsCustomer.RemoveAt(bdsCustomer.Count - 1);
            }
            gcCustomer.Enabled = true;
            pnInput.Enabled = false;
            btnInsert.Enabled = btnUpdate.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            txbId.Enabled = false;
            if (undoStack.Count > 0)
                btnUndo.Enabled = true;
            btnSave.Tag = btnUndo.Tag = null;

            if (bdsCustomer.Count > 0)
                btnDelete.Enabled = true;

            ReqUpdateCanCloseState.Invoke(this, true);

            if (redoStack.Count > 0)
                btnRedo.Enabled = true;
        }

        private bool UndoByInsertAction(UserEventData action)
        {
            if (action == null)
                throw new Exception();
            bdsCustomer.AddNew();
            txbBrandId.Text = this.gridBrandID;
            cbGender.SelectedIndex = 0;
            Customer customer = (Customer)action.Content;
            txbId.Text = customer.Id;
            txbLastName.Text = customer.LastName;
            txbFirstName.Text = customer.FirstName;
            txbAddress.Text = customer.Address;
            txbPhoneNum.Text = customer.PhoneNum;
            cbGender.SelectedItem = customer.Gender;
            deDateAccept.DateTime = customer.DateAccept;
            try
            {
                // Lưu thông tin trên binding source
                bdsCustomer.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsCustomer.ResetCurrentItem();
                taCustomer.Update(this.DS.KhachHang);
            }
            catch (Exception ex)
            {
                string msg = btnSave.Tag == btnInsert ? "Lỗi không thể thêm khách hàng mới" : "Lỗi không thể hiệu chỉnh khách hàng";
                MessageBox.Show($"{msg}.\n{ex.Message}", "", MessageBoxButtons.OK);
                return false;
            }
            taCustomer.Fill(this.DS.KhachHang);
            bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, customer.Id);
            return true;
        }

        private bool UndoByDeleteAction(UserEventData action)
        {
            Customer customer = (Customer)action.Content;
            bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, customer.Id);

            int accountIdx = bdsAccount.Find(Customer.ID_HEADER, customer.Id);
            if (accountIdx >= 0)
            {
                MessageBox.Show("Không thể xóa khách hàng đã có tài khoản.\nVui lòng thực hiện xóa tài khoản trước.\n", "", MessageBoxButtons.OK);
                return false;
            }

            if (MessageBox.Show("Xác nhận xóa khách hàng?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    // Xóa trên máy trước
                    bdsCustomer.RemoveCurrent();
                    // Xóa trên server
                    taCustomer.Update(this.DS.KhachHang);
                }
                catch (Exception ex)
                {
                    // Phục hồi nếu xóa không thành công
                    MessageBox.Show($"Lỗi không thể xóa khách hàng. Thử thực hiện lại.\n{ex.Message}", "", MessageBoxButtons.OK);
                    taCustomer.Fill(this.DS.KhachHang);
                    bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, customer.Id);
                    return false;
                }
                if (bdsCustomer.Count == 0)
                {
                    btnDelete.Enabled = false;
                }
                return true;
            }
            return false;
        }


        private bool UndoByUpdateAction(UserEventData action)
        {
            Customer updatedCustomer = (Customer)action.Content;
            bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, updatedCustomer.Id);
            txbLastName.Text = updatedCustomer.LastName;
            txbFirstName.Text = updatedCustomer.FirstName;
            txbAddress.Text = updatedCustomer.Address;
            txbPhoneNum.Text = updatedCustomer.PhoneNum;
            cbGender.SelectedItem = updatedCustomer.Gender;
            deDateAccept.DateTime = updatedCustomer.DateAccept;
            try
            {
                // Lưu thông tin trên binding source
                bdsCustomer.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsCustomer.ResetCurrentItem();
                taCustomer.Update(this.DS.KhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không thể hiệu chỉnh khách hàng.\n{ex.Message}", "", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
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
            // Tải dữ liệu từ site mới về
            taCustomer.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            taCustomer.Fill(this.DS.KhachHang);
        }

        private void fCustomerManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ReqClose.Invoke(this);
                e.Cancel = (btnSave.Tag != null);
            }
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gridPos = bdsCustomer.Position;
            pnInput.Enabled = true;
            bdsCustomer.AddNew();
            txbBrandId.Text = this.gridBrandID;
            gcCustomer.Enabled = false;
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

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string customerId = ((DataRowView)bdsCustomer[bdsCustomer.Position])[Customer.ID_HEADER].ToString();
            int accountIdx = bdsAccount.Find(Customer.ID_HEADER, customerId);
            if (accountIdx >= 0)
            {
                MessageBox.Show("Không thể xóa khách hàng đã có tài khoản.\nVui lòng thực hiện xóa tài khoản trước.\n", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Xác nhận xóa khách hàng?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Customer deletedCustomer = null;
                string deletedCustomerId = ((DataRowView)bdsCustomer[bdsCustomer.Position])[Customer.ID_HEADER].ToString();
                try
                {
                    deletedCustomer = new Customer((DataRowView)bdsCustomer[bdsCustomer.Position]);
                    // Xóa trên máy trước
                    bdsCustomer.RemoveCurrent();
                    // Xóa trên server
                    taCustomer.Update(this.DS.KhachHang);
                }
                catch (Exception ex)
                {
                    // Phục hồi nếu xóa không thành công
                    MessageBox.Show($"Lỗi không thể xóa khách hàng. Thử thực hiện lại.\n{ex.Message}", "", MessageBoxButtons.OK);
                    taCustomer.Fill(this.DS.KhachHang);
                    bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, deletedCustomerId);
                    return;
                }
                if (bdsCustomer.Count == 0)
                    btnDelete.Enabled = false;

                // Ignore to save grid pos
                undoStack.AddLast(new UserEventData(UserEventData.EventType.INSERT, deletedCustomer, -1));
                ControlUtil.ResolveStackStorage(undoStack);
                redoStack.Clear();
                btnRedo.Enabled = false;
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns[Customer.ID_HEADER], "");
            view.SetRowCellValue(e.RowHandle, view.Columns[Customer.LASTNAME_HEADER], "");
            view.SetRowCellValue(e.RowHandle, view.Columns[Customer.FIRSTNAME_HEADER], "");
            view.SetRowCellValue(e.RowHandle, view.Columns[Customer.ADDRESS_HEADER], "");
            view.SetRowCellValue(e.RowHandle, view.Columns[Customer.DATE_ACCEPT_HEADER], DateTime.Today);
            view.SetRowCellValue(e.RowHandle, view.Columns[Customer.PHONENUM_HEADER], "");
        }
    }
}