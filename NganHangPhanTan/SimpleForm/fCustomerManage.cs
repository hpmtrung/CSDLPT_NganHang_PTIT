using DevExpress.XtraGrid.Views.Grid;
using NganHangPhanTan.DAO;
using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
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

        private void fCustomerManage_Load(object sender, EventArgs e)
        {
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

            this.gridBrandID = BrandDAO.Instance.GetBrandIdOfSubcriber();
            cbBrand_SelectionChangeCommitted(null, null);
        }
        
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Customer oldCustomer = null;
            string customerId = "";

            if (btnSave.Tag == btnUpdate)
            {
                oldCustomer = new Customer((DataRowView)bdsCustomer[bdsCustomer.Position]);
            }
            else
            {
                // Chỉ kiểm tra mã KH khi INSERT
                customerId = txbId.Text.Trim();
                if (string.IsNullOrEmpty(customerId))
                {
                    MessageUtil.ShowErrorMsgDialog("Mã khách hàng (CMND) không được để trống");
                    txbId.Focus();
                    return;
                }

                if (customerId.Contains(" ") || !Regex.Match(customerId, "\\d{10}").Success)
                {
                    MessageUtil.ShowErrorMsgDialog("Mã khách hàng (CMND) không hợp lệ hoặc chưa đủ 10 chữ số");
                    txbId.Focus();
                    return;
                }

                // Kiểm tra mã KH (CMND) đã tồn tại trong bảng KHACHHANG trên site chủ
                // Vì 1 khách hàng chỉ đăng ký thuộc 1 chi nhánh duy nhất
                if (CustomerDAO.Instance.ExistById(customerId))
                {
                    MessageUtil.ShowErrorMsgDialog("Lỗi không thể thêm vì khách hàng đã đăng ký chi nhánh khác.");
                    txbId.Focus();
                    return;
                }

                customerId = customerId.ToUpper();
                txbId.Text = customerId;
            }

            string lastName = txbLastName.Text.Trim();
            if (string.IsNullOrEmpty(lastName))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên khách hàng không được để trống");
                txbLastName.Focus();
                return;
            }

            lastName = ControlUtil.RemoveDuplicateSpace(lastName);
            lastName = ControlUtil.CapitalizeFirstLetter(lastName);
            txbLastName.Text = lastName;

            string firstName = txbFirstName.Text.Trim();
            if (string.IsNullOrEmpty(firstName))
            {
                MessageUtil.ShowErrorMsgDialog("Họ tên khách hàng không được để trống");
                txbFirstName.Focus();
                return;
            }

            if (firstName.Contains(" "))
            {
                MessageUtil.ShowErrorMsgDialog("Tên khách hàng không hợp lệ");
                txbFirstName.Focus();
                return;
            }

            firstName = ControlUtil.CapitalizeFirstLetter(firstName);
            txbFirstName.Text = firstName;

            string address = txbAddress.Text.Trim();
            if (string.IsNullOrEmpty(address))
            {
                MessageUtil.ShowErrorMsgDialog("Địa chỉ khách hàng không được để trống");
                txbAddress.Focus();
                return;
            }

            address = ControlUtil.RemoveDuplicateSpace(address);
            txbAddress.Text = address;

            string phoneNum = txbPhoneNum.Text.Trim();
            if (string.IsNullOrEmpty(phoneNum))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại khách hàng không được để trống");
                txbPhoneNum.Focus();
                return;
            }

            if (!phoneNum.All(Char.IsDigit))
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại khách hàng không hợp lệ");
                txbPhoneNum.Focus();
                return;
            }

            if (phoneNum.Length != 10)
            {
                MessageUtil.ShowErrorMsgDialog("Số điện thoại khách hàng không đúng 10 chữ số");
                txbPhoneNum.Focus();
                return;
            }

            txbPhoneNum.Text = phoneNum;

            if (deDateAccept.DateTime > DateTime.Now)
            {
                MessageUtil.ShowErrorMsgDialog("Ngày cấp CMND khách hàng không hợp lệ");
                deDateAccept.Focus();
                return;
            }

            cbGender.DataBindings[0].WriteValue();
            deDateAccept.DataBindings[0].WriteValue();

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
                MessageUtil.ShowErrorMsgDialog($"{msg}.\n{ex.Message}");
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
                // Nếu INSERT, thêm vào undo stack DELETE action
                action.Type = UserEventData.EventType.DELETE;
                action.Content = new Customer((DataRowView)bdsCustomer[bdsCustomer.Position]);
                // Không cần lưu action.GridPos vì là DELETE action
            }
            else
            {
                // Nếu UPDATE, thêm vào undo stack UPDATE action
                action.Type = UserEventData.EventType.UPDATE;
                action.Content = oldCustomer;
                // Không cần lưu action.GridPos vì không cần phục hồi gridPos khi UPDATE
            }

            undoStack.AddLast(action);
            ControlUtil.ResolveStackStorage(undoStack);

            btnUndo.Enabled = true;

            // Xóa redo stack
            redoStack.Clear();
            btnRedo.Enabled = false;

            gcCustomer.Enabled = true;
            pnInput.Enabled = false;
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            txbId.Enabled = false;
            btnSave.Tag = null;

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
            btnSave.Tag = btnUpdate;

            ReqUpdateCanCloseState.Invoke(this, false);

            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
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
                            } else
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
                                bdsCustomer.Position = action.GridPos;
                            } else if (res == 0)
                            {
                                undoStack.AddLast(action);
                            }
                            break;
                        }
                    case UserEventData.EventType.UPDATE:
                        {
                            Customer oldCustomer = new Customer((DataRowView)bdsCustomer[bdsCustomer.Find(Customer.ID_HEADER, ((Customer)action.Content).Id)]);
                            if (UndoByUpdateAction(action))
                            {
                                action.Type = UserEventData.EventType.UPDATE;
                                action.Content = oldCustomer;
                                redoStack.AddLast(action);
                            } else
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
                            } else
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
                                bdsCustomer.Position = action.GridPos;
                            } else if (res == 0)
                            {
                                redoStack.AddLast(action);
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

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                taCustomer.Fill(this.DS.KhachHang);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog(ex.Message);
                throw;
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void UndoUnSaveAction(UserEventData action)
        {
            bdsCustomer.CancelEdit();

            if (btnSave.Tag == btnInsert)
            {
                bdsCustomer.Position = action.GridPos;
                bdsCustomer.RemoveAt(bdsCustomer.Count - 1);
            }

            gcCustomer.Enabled = true;
            pnInput.Enabled = false;
            btnInsert.Enabled = btnUpdate.Enabled = btnReload.Enabled = btnExit.Enabled = true;
            btnSave.Enabled = false;
            txbId.Enabled = false;
            btnUndo.Enabled = undoStack.Count > 0;

            btnSave.Tag = null;

            btnDelete.Enabled = bdsCustomer.Count > 0;

            ReqUpdateCanCloseState.Invoke(this, true);

            btnRedo.Enabled = redoStack.Count > 0;
        }

        private bool UndoByInsertAction(UserEventData action)
        {
            if (action == null)
                throw new Exception();

            bdsCustomer.AddNew();

            txbBrandId.Text = this.gridBrandID;

            Customer customer = (Customer)action.Content;
            txbId.Text = customer.Id;
            txbLastName.Text = customer.LastName;
            txbFirstName.Text = customer.FirstName;
            txbAddress.Text = customer.Address;
            txbPhoneNum.Text = customer.PhoneNum;
            cbGender.SelectedItem = customer.Gender;
            deDateAccept.DateTime = customer.DateAccept;

            cbGender.DataBindings[0].WriteValue();
            deDateAccept.DataBindings[0].WriteValue();

            try
            {
                // Lưu thông tin trên binding source
                bdsCustomer.EndEdit();
                // Đặt thông tin nhân viên mới lên grid control
                bdsCustomer.ResetCurrentItem();
                taCustomer.Update(this.DS.KhachHang);
                taCustomer.Fill(this.DS.KhachHang);
                bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, customer.Id);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể khôi phục khách hàng đã xóa có số CMND là {customer.Id}, thử thực hiện lại.\nChi tiết: {ex.Message}");
                return false;
            }
            return true;
        }

        private int UndoByDeleteAction(UserEventData action)
        {
            Customer customer = (Customer)action.Content;
            bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, customer.Id);

            if (CustomerDAO.Instance.HavingAnyAccount(customer.Id))
            {
                MessageUtil.ShowErrorMsgDialog("Không thể xóa khách hàng đã có tài khoản. Vui lòng thực hiện xóa tài khoản trước.\n");
                return -1;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa khách hàng có số CMND {customer.Id}?") != DialogResult.OK)
                return 0;

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
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa khách hàng, vui lòng thực hiện lại.\nChi tiết: {ex.Message}");
                taCustomer.Fill(this.DS.KhachHang);
                bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, customer.Id);
                return 0;
            }

            btnDelete.Enabled = bdsCustomer.Count != 0;
            return 1;
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

            cbGender.DataBindings[0].WriteValue();
            deDateAccept.DataBindings[0].WriteValue();

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
                MessageUtil.ShowErrorMsgDialog($"Lỗi không thể hiệu chỉnh khách hàng, thử thực hiện lại.\nChi tiết: {ex.Message}");
                return false;
            }

            return true;
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

            bdsCustomer.AddNew();

            pnInput.Enabled = true;
            gcCustomer.Enabled = false;
            txbBrandId.Text = this.gridBrandID;
            cbGender.SelectedIndex = 0;
            txbId.Enabled = true;
            txbId.Focus();
            btnInsert.Enabled = btnUpdate.Enabled = btnDelete.Enabled = btnReload.Enabled = btnExit.Enabled = false;
            btnSave.Enabled = btnUndo.Enabled = true;
            btnRedo.Enabled = false;

            btnSave.Tag = btnInsert;

            ReqUpdateCanCloseState.Invoke(this, false);

            // Push cancel-editing event to undo stack
            undoStack.AddLast(new UserEventData(UserEventData.EventType.CANCEL_EDIT, null, gridPos));
            btnUndo.Enabled = true;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string customerId = ((DataRowView)bdsCustomer[bdsCustomer.Position])[Customer.ID_HEADER].ToString();
            if (CustomerDAO.Instance.HavingAnyAccount(customerId))
            {
                MessageUtil.ShowErrorMsgDialog("Không thể xóa khách hàng đã có tài khoản. Vui lòng thực hiện xóa tài khoản trước.\n");
                return;
            }

            if (MessageUtil.ShowWarnConfirmDialog($"Xác nhận xóa khách hàng có số CMND {customerId}?") == DialogResult.OK)
            {
                string deletedCustomerId = ((DataRowView)bdsCustomer[bdsCustomer.Position])[Customer.ID_HEADER].ToString();
                Customer deletedCustomer;
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
                    MessageUtil.ShowErrorMsgDialog($"Lỗi không thể xóa khách hàng. Thử thực hiện lại.\n{ex.Message}");
                    taCustomer.Fill(this.DS.KhachHang);
                    bdsCustomer.Position = bdsCustomer.Find(Customer.ID_HEADER, deletedCustomerId);
                    return;
                }

                btnDelete.Enabled = bdsCustomer.Count != 0;

                // Ignore save grid pos
                undoStack.AddLast(new UserEventData(UserEventData.EventType.INSERT, deletedCustomer, -1));
                btnUndo.Enabled = true;
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
            if (!DataProvider.Instance.CheckConnection())
            {
                MessageUtil.ShowErrorMsgDialog("Lỗi kết nối sang chi nhánh mới");
                return;
            }
            // Tải dữ liệu từ site mới về
            taCustomer.Connection.ConnectionString = DataProvider.Instance.ConnectionStr;
            taCustomer.Fill(this.DS.KhachHang);
        }

    }
}