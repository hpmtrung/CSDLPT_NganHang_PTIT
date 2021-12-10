
namespace NganHangPhanTan.SimpleForm
{
    partial class fOpenCustomerAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fOpenCustomerAccount));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new NganHangPhanTan.DS();
            this.bdsCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.taCustomer = new NganHangPhanTan.DSTableAdapters.KhachHangTableAdapter();
            this.tableAdapterManager = new NganHangPhanTan.DSTableAdapters.TableAdapterManager();
            this.gcCustomer = new DevExpress.XtraGrid.GridControl();
            this.gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPHAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYCAP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcAccount = new DevExpress.XtraGrid.GridControl();
            this.bdsAccount = new System.Windows.Forms.BindingSource(this.components);
            this.gvAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Unchanged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colSODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colMACN1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYMOTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnRedo = new DevExpress.XtraEditors.SimpleButton();
            this.btnUndo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteAcc = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsertAcc = new DevExpress.XtraEditors.SimpleButton();
            this.taAccount = new NganHangPhanTan.DSTableAdapters.usp_GetAccountByCustomerIdTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbBrand);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1273, 74);
            this.panelControl1.TabIndex = 6;
            // 
            // cbBrand
            // 
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(93, 24);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(391, 24);
            this.cbBrand.TabIndex = 1;
            this.cbBrand.SelectionChangeCommitted += new System.EventHandler(this.cbBrand_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh:";
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsCustomer
            // 
            this.bdsCustomer.DataMember = "KhachHang";
            this.bdsCustomer.DataSource = this.DS;
            // 
            // taCustomer
            // 
            this.taCustomer.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KhachHangTableAdapter = this.taCustomer;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.TaiKhoanTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NganHangPhanTan.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gcCustomer
            // 
            this.gcCustomer.DataSource = this.bdsCustomer;
            this.gcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCustomer.Location = new System.Drawing.Point(2, 28);
            this.gcCustomer.MainView = this.gvCustomer;
            this.gcCustomer.Name = "gcCustomer";
            this.gcCustomer.Size = new System.Drawing.Size(1269, 373);
            this.gcCustomer.TabIndex = 7;
            this.gcCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomer});
            // 
            // gvCustomer
            // 
            this.gvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCMND,
            this.colHO,
            this.colTEN,
            this.colDIACHI,
            this.colPHAI,
            this.colNGAYCAP,
            this.colSODT,
            this.colMACN});
            this.gvCustomer.GridControl = this.gcCustomer;
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colCMND
            // 
            this.colCMND.Caption = "CMND";
            this.colCMND.FieldName = "CMND";
            this.colCMND.MinWidth = 25;
            this.colCMND.Name = "colCMND";
            this.colCMND.OptionsColumn.AllowEdit = false;
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 0;
            this.colCMND.Width = 94;
            // 
            // colHO
            // 
            this.colHO.Caption = "Họ";
            this.colHO.FieldName = "HO";
            this.colHO.MinWidth = 25;
            this.colHO.Name = "colHO";
            this.colHO.OptionsColumn.AllowEdit = false;
            this.colHO.Visible = true;
            this.colHO.VisibleIndex = 1;
            this.colHO.Width = 94;
            // 
            // colTEN
            // 
            this.colTEN.Caption = "Tên";
            this.colTEN.FieldName = "TEN";
            this.colTEN.MinWidth = 25;
            this.colTEN.Name = "colTEN";
            this.colTEN.OptionsColumn.AllowEdit = false;
            this.colTEN.Visible = true;
            this.colTEN.VisibleIndex = 2;
            this.colTEN.Width = 94;
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "Địa chỉ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 25;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.OptionsColumn.AllowEdit = false;
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 3;
            this.colDIACHI.Width = 94;
            // 
            // colPHAI
            // 
            this.colPHAI.Caption = "Phái";
            this.colPHAI.FieldName = "PHAI";
            this.colPHAI.MinWidth = 25;
            this.colPHAI.Name = "colPHAI";
            this.colPHAI.OptionsColumn.AllowEdit = false;
            this.colPHAI.Visible = true;
            this.colPHAI.VisibleIndex = 4;
            this.colPHAI.Width = 94;
            // 
            // colNGAYCAP
            // 
            this.colNGAYCAP.Caption = "Ngày cấp";
            this.colNGAYCAP.FieldName = "NGAYCAP";
            this.colNGAYCAP.MinWidth = 25;
            this.colNGAYCAP.Name = "colNGAYCAP";
            this.colNGAYCAP.OptionsColumn.AllowEdit = false;
            this.colNGAYCAP.Visible = true;
            this.colNGAYCAP.VisibleIndex = 5;
            this.colNGAYCAP.Width = 94;
            // 
            // colSODT
            // 
            this.colSODT.Caption = "Số ĐT";
            this.colSODT.FieldName = "SODT";
            this.colSODT.MinWidth = 25;
            this.colSODT.Name = "colSODT";
            this.colSODT.OptionsColumn.AllowEdit = false;
            this.colSODT.Visible = true;
            this.colSODT.VisibleIndex = 6;
            this.colSODT.Width = 94;
            // 
            // colMACN
            // 
            this.colMACN.Caption = "Mã CN";
            this.colMACN.FieldName = "MACN";
            this.colMACN.MinWidth = 25;
            this.colMACN.Name = "colMACN";
            this.colMACN.OptionsColumn.AllowEdit = false;
            this.colMACN.Visible = true;
            this.colMACN.VisibleIndex = 7;
            this.colMACN.Width = 94;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcCustomer);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 74);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1273, 403);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Khách hàng";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcAccount);
            this.groupControl2.Controls.Add(this.panel1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 477);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1273, 454);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "Danh sách tài khoản";
            // 
            // gcAccount
            // 
            this.gcAccount.DataSource = this.bdsAccount;
            this.gcAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAccount.Location = new System.Drawing.Point(2, 63);
            this.gcAccount.MainView = this.gvAccount;
            this.gcAccount.Name = "gcAccount";
            this.gcAccount.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gcAccount.Size = new System.Drawing.Size(1269, 389);
            this.gcAccount.TabIndex = 10;
            this.gcAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAccount});
            // 
            // bdsAccount
            // 
            this.bdsAccount.DataMember = "usp_GetAccountByCustomerId";
            this.bdsAccount.DataSource = this.DS;
            // 
            // gvAccount
            // 
            this.gvAccount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Unchanged,
            this.colSOTK,
            this.colSODU,
            this.colMACN1,
            this.colNGAYMOTK});
            this.gvAccount.GridControl = this.gcAccount;
            this.gvAccount.Name = "gvAccount";
            this.gvAccount.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvAccount_FocusedRowChanged);
            this.gvAccount.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvAccount_CellValueChanged);
            this.gvAccount.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvAccount_InvalidRowException);
            this.gvAccount.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvAccount_ValidateRow);
            this.gvAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvAccount_KeyDown);
            this.gvAccount.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvAccount_ValidatingEditor);
            // 
            // Unchanged
            // 
            this.Unchanged.AppearanceCell.Options.UseTextOptions = true;
            this.Unchanged.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Unchanged.Caption = " ";
            this.Unchanged.FieldName = "Unchanged";
            this.Unchanged.MaxWidth = 25;
            this.Unchanged.MinWidth = 25;
            this.Unchanged.Name = "Unchanged";
            this.Unchanged.OptionsColumn.AllowEdit = false;
            this.Unchanged.OptionsColumn.AllowFocus = false;
            this.Unchanged.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.Unchanged.OptionsColumn.AllowIncrementalSearch = false;
            this.Unchanged.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.Unchanged.Visible = true;
            this.Unchanged.VisibleIndex = 0;
            this.Unchanged.Width = 25;
            // 
            // colSOTK
            // 
            this.colSOTK.Caption = "Mã số TK";
            this.colSOTK.ColumnEdit = this.repositoryItemTextEdit2;
            this.colSOTK.FieldName = "SOTK";
            this.colSOTK.MinWidth = 25;
            this.colSOTK.Name = "colSOTK";
            this.colSOTK.OptionsColumn.ReadOnly = true;
            this.colSOTK.Visible = true;
            this.colSOTK.VisibleIndex = 1;
            this.colSOTK.Width = 300;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Mask.BeepOnError = true;
            this.repositoryItemTextEdit2.Mask.EditMask = "[a-zA-Z0-9]{0,9}";
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // colSODU
            // 
            this.colSODU.Caption = "Số dư";
            this.colSODU.ColumnEdit = this.repositoryItemTextEdit1;
            this.colSODU.FieldName = "SODU";
            this.colSODU.MinWidth = 25;
            this.colSODU.Name = "colSODU";
            this.colSODU.OptionsColumn.ReadOnly = true;
            this.colSODU.Visible = true;
            this.colSODU.VisibleIndex = 2;
            this.colSODU.Width = 293;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.BeepOnError = true;
            this.repositoryItemTextEdit1.Mask.EditMask = "c0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // colMACN1
            // 
            this.colMACN1.Caption = "Mã CN";
            this.colMACN1.FieldName = "MACN";
            this.colMACN1.MinWidth = 25;
            this.colMACN1.Name = "colMACN1";
            this.colMACN1.OptionsColumn.ReadOnly = true;
            this.colMACN1.Visible = true;
            this.colMACN1.VisibleIndex = 3;
            this.colMACN1.Width = 309;
            // 
            // colNGAYMOTK
            // 
            this.colNGAYMOTK.Caption = "Ngày mở TK";
            this.colNGAYMOTK.FieldName = "NGAYMOTK";
            this.colNGAYMOTK.MinWidth = 25;
            this.colNGAYMOTK.Name = "colNGAYMOTK";
            this.colNGAYMOTK.OptionsColumn.ReadOnly = true;
            this.colNGAYMOTK.Visible = true;
            this.colNGAYMOTK.VisibleIndex = 4;
            this.colNGAYMOTK.Width = 314;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnInsertAcc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1269, 35);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReload);
            this.panel2.Controls.Add(this.btnRedo);
            this.panel2.Controls.Add(this.btnUndo);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnDeleteAcc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(94, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 35);
            this.panel2.TabIndex = 19;
            // 
            // btnReload
            // 
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReload.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.Image")));
            this.btnReload.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnReload.Location = new System.Drawing.Point(376, 0);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(94, 35);
            this.btnReload.TabIndex = 22;
            this.btnReload.Text = "Xem lại";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRedo.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnRedo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.ImageOptions.Image")));
            this.btnRedo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnRedo.Location = new System.Drawing.Point(282, 0);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(94, 35);
            this.btnRedo.TabIndex = 21;
            this.btnRedo.Text = "Redo";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUndo.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnUndo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.ImageOptions.Image")));
            this.btnUndo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnUndo.Location = new System.Drawing.Point(188, 0);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(94, 35);
            this.btnUndo.TabIndex = 20;
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnSave.ImageOptions.Image = global::NganHangPhanTan.Properties.Resources.diskette;
            this.btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnSave.Location = new System.Drawing.Point(94, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteAcc
            // 
            this.btnDeleteAcc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeleteAcc.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnDeleteAcc.ImageOptions.Image = global::NganHangPhanTan.Properties.Resources.delete;
            this.btnDeleteAcc.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnDeleteAcc.Location = new System.Drawing.Point(0, 0);
            this.btnDeleteAcc.Name = "btnDeleteAcc";
            this.btnDeleteAcc.Size = new System.Drawing.Size(94, 35);
            this.btnDeleteAcc.TabIndex = 18;
            this.btnDeleteAcc.Text = "Xóa";
            this.btnDeleteAcc.Click += new System.EventHandler(this.btnDeleteAcc_Click);
            // 
            // btnInsertAcc
            // 
            this.btnInsertAcc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInsertAcc.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnInsertAcc.ImageOptions.Image = global::NganHangPhanTan.Properties.Resources.add;
            this.btnInsertAcc.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnInsertAcc.Location = new System.Drawing.Point(0, 0);
            this.btnInsertAcc.Name = "btnInsertAcc";
            this.btnInsertAcc.Size = new System.Drawing.Size(94, 35);
            this.btnInsertAcc.TabIndex = 11;
            this.btnInsertAcc.Text = "Thêm";
            this.btnInsertAcc.Click += new System.EventHandler(this.btnInsertAcc_Click);
            // 
            // taAccount
            // 
            this.taAccount.ClearBeforeFill = true;
            // 
            // fOpenCustomerAccount
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 931);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fOpenCustomerAccount";
            this.Text = "Mở tài khoản khách hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fOpenCustomerAccount_FormClosing);
            this.Load += new System.EventHandler(this.fOpenCustomerAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.Label label1;
        private DS DS;
        private System.Windows.Forms.BindingSource bdsCustomer;
        private DSTableAdapters.KhachHangTableAdapter taCustomer;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnInsertAcc;
        private System.Windows.Forms.BindingSource bdsAccount;
        private DSTableAdapters.usp_GetAccountByCustomerIdTableAdapter taAccount;
        private DevExpress.XtraGrid.GridControl gcAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTK;
        private DevExpress.XtraGrid.Columns.GridColumn colSODU;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN1;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYMOTK;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colHO;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colPHAI;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYCAP;
        private DevExpress.XtraGrid.Columns.GridColumn colSODT;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.SimpleButton btnRedo;
        private DevExpress.XtraEditors.SimpleButton btnUndo;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDeleteAcc;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Unchanged;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
    }
}