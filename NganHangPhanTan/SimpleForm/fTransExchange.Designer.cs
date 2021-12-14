
namespace NganHangPhanTan.SimpleForm
{
    partial class fTransExchange
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.usp_GetCustomerHavingAccountInSubcriberGridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new NganHangPhanTan.DS();
            this.gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYCAP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnBody = new System.Windows.Forms.Panel();
            this.pnTrans = new DevExpress.XtraEditors.GroupControl();
            this.gcTrans = new DevExpress.XtraGrid.GridControl();
            this.bdsTrans = new System.Windows.Forms.BindingSource(this.components);
            this.gvTrans = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.usp_GetAccountByCustomerIdGridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsAccount = new System.Windows.Forms.BindingSource(this.components);
            this.gvAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSOTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYMOTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEditEnpoint = new DevExpress.XtraEditors.GroupControl();
            this.pnInput = new System.Windows.Forms.Panel();
            this.gcEndpoints = new DevExpress.XtraGrid.GridControl();
            this.gvEndpoints = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.teModifiedBalance = new DevExpress.XtraEditors.TextEdit();
            this.btnChangeEndpoints = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.teInitBalance = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.taTrans = new NganHangPhanTan.DSTableAdapters.usp_GetTransExchangeByAccountIdTableAdapter();
            this.tableAdapterManager = new NganHangPhanTan.DSTableAdapters.TableAdapterManager();
            this.taCustomer = new NganHangPhanTan.DSTableAdapters.usp_GetCustomerHavingAccountInSubcriberTableAdapter();
            this.taAccount = new NganHangPhanTan.DSTableAdapters.usp_GetAccountByCustomerIdTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usp_GetCustomerHavingAccountInSubcriberGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.pnBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTrans)).BeginInit();
            this.pnTrans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usp_GetAccountByCustomerIdGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEditEnpoint)).BeginInit();
            this.gcEditEnpoint.SuspendLayout();
            this.pnInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEndpoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEndpoints)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teModifiedBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teInitBalance.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.usp_GetCustomerHavingAccountInSubcriberGridControl);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 74);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1147, 230);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "Danh sách khách hàng đăng ký tài khoản thuộc chi nhánh";
            // 
            // usp_GetCustomerHavingAccountInSubcriberGridControl
            // 
            this.usp_GetCustomerHavingAccountInSubcriberGridControl.DataSource = this.bdsCustomer;
            this.usp_GetCustomerHavingAccountInSubcriberGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usp_GetCustomerHavingAccountInSubcriberGridControl.Location = new System.Drawing.Point(2, 28);
            this.usp_GetCustomerHavingAccountInSubcriberGridControl.MainView = this.gvCustomer;
            this.usp_GetCustomerHavingAccountInSubcriberGridControl.Name = "usp_GetCustomerHavingAccountInSubcriberGridControl";
            this.usp_GetCustomerHavingAccountInSubcriberGridControl.Size = new System.Drawing.Size(1143, 200);
            this.usp_GetCustomerHavingAccountInSubcriberGridControl.TabIndex = 0;
            this.usp_GetCustomerHavingAccountInSubcriberGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCustomer});
            // 
            // bdsCustomer
            // 
            this.bdsCustomer.AllowNew = true;
            this.bdsCustomer.DataMember = "usp_GetCustomerHavingAccountInSubcriber";
            this.bdsCustomer.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gvCustomer
            // 
            this.gvCustomer.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvCustomer.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvCustomer.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvCustomer.Appearance.Row.Options.UseFont = true;
            this.gvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCMND,
            this.colHOTEN,
            this.colDIACHI,
            this.colNGAYCAP,
            this.colSODT});
            this.gvCustomer.GridControl = this.usp_GetCustomerHavingAccountInSubcriberGridControl;
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCustomer_FocusedRowChanged);
            // 
            // colCMND
            // 
            this.colCMND.FieldName = "CMND";
            this.colCMND.MinWidth = 25;
            this.colCMND.Name = "colCMND";
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 0;
            this.colCMND.Width = 94;
            // 
            // colHOTEN
            // 
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.MinWidth = 25;
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 1;
            this.colHOTEN.Width = 94;
            // 
            // colDIACHI
            // 
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 25;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 2;
            this.colDIACHI.Width = 94;
            // 
            // colNGAYCAP
            // 
            this.colNGAYCAP.FieldName = "NGAYCAP";
            this.colNGAYCAP.MinWidth = 25;
            this.colNGAYCAP.Name = "colNGAYCAP";
            this.colNGAYCAP.Visible = true;
            this.colNGAYCAP.VisibleIndex = 3;
            this.colNGAYCAP.Width = 94;
            // 
            // colSODT
            // 
            this.colSODT.FieldName = "SODT";
            this.colSODT.MinWidth = 25;
            this.colSODT.Name = "colSODT";
            this.colSODT.Visible = true;
            this.colSODT.VisibleIndex = 4;
            this.colSODT.Width = 94;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbBrand);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1147, 74);
            this.panelControl1.TabIndex = 11;
            // 
            // cbBrand
            // 
            this.cbBrand.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(140, 24);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(391, 31);
            this.cbBrand.TabIndex = 1;
            this.cbBrand.SelectionChangeCommitted += new System.EventHandler(this.cbBrand_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh:";
            // 
            // pnBody
            // 
            this.pnBody.Controls.Add(this.pnTrans);
            this.pnBody.Controls.Add(this.groupControl3);
            this.pnBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBody.Location = new System.Drawing.Point(0, 304);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(1147, 229);
            this.pnBody.TabIndex = 16;
            // 
            // pnTrans
            // 
            this.pnTrans.Controls.Add(this.gcTrans);
            this.pnTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTrans.Location = new System.Drawing.Point(673, 0);
            this.pnTrans.Name = "pnTrans";
            this.pnTrans.Size = new System.Drawing.Size(474, 229);
            this.pnTrans.TabIndex = 14;
            this.pnTrans.Text = "Giao dịch chuyển tiền của tài khoản";
            // 
            // gcTrans
            // 
            this.gcTrans.DataSource = this.bdsTrans;
            this.gcTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTrans.Location = new System.Drawing.Point(2, 28);
            this.gcTrans.MainView = this.gvTrans;
            this.gcTrans.Name = "gcTrans";
            this.gcTrans.Size = new System.Drawing.Size(470, 199);
            this.gcTrans.TabIndex = 0;
            this.gcTrans.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTrans});
            // 
            // bdsTrans
            // 
            this.bdsTrans.DataMember = "usp_GetTransExchangeByAccountId";
            this.bdsTrans.DataSource = this.DS;
            // 
            // gvTrans
            // 
            this.gvTrans.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTrans.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvTrans.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTrans.Appearance.Row.Options.UseFont = true;
            this.gvTrans.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAGD,
            this.colSOTIEN,
            this.colMANV,
            this.colNGAYGD});
            this.gvTrans.GridControl = this.gcTrans;
            this.gvTrans.Name = "gvTrans";
            // 
            // colMAGD
            // 
            this.colMAGD.AppearanceCell.Options.UseTextOptions = true;
            this.colMAGD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMAGD.AppearanceHeader.Options.UseTextOptions = true;
            this.colMAGD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMAGD.Caption = "Mã GD";
            this.colMAGD.FieldName = "MAGD";
            this.colMAGD.MinWidth = 25;
            this.colMAGD.Name = "colMAGD";
            this.colMAGD.OptionsColumn.ReadOnly = true;
            this.colMAGD.Visible = true;
            this.colMAGD.VisibleIndex = 0;
            this.colMAGD.Width = 94;
            // 
            // colSOTIEN
            // 
            this.colSOTIEN.AppearanceCell.Options.UseTextOptions = true;
            this.colSOTIEN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSOTIEN.AppearanceHeader.Options.UseTextOptions = true;
            this.colSOTIEN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSOTIEN.Caption = "Số tiền";
            this.colSOTIEN.FieldName = "SOTIEN";
            this.colSOTIEN.MinWidth = 25;
            this.colSOTIEN.Name = "colSOTIEN";
            this.colSOTIEN.OptionsColumn.ReadOnly = true;
            this.colSOTIEN.Visible = true;
            this.colSOTIEN.VisibleIndex = 1;
            this.colSOTIEN.Width = 94;
            // 
            // colMANV
            // 
            this.colMANV.AppearanceCell.Options.UseTextOptions = true;
            this.colMANV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMANV.AppearanceHeader.Options.UseTextOptions = true;
            this.colMANV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMANV.Caption = "Mã NV";
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.OptionsColumn.ReadOnly = true;
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 2;
            this.colMANV.Width = 94;
            // 
            // colNGAYGD
            // 
            this.colNGAYGD.AppearanceCell.Options.UseTextOptions = true;
            this.colNGAYGD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNGAYGD.AppearanceHeader.Options.UseTextOptions = true;
            this.colNGAYGD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNGAYGD.Caption = "Ngày GD";
            this.colNGAYGD.FieldName = "NGAYGD";
            this.colNGAYGD.MinWidth = 25;
            this.colNGAYGD.Name = "colNGAYGD";
            this.colNGAYGD.OptionsColumn.ReadOnly = true;
            this.colNGAYGD.Visible = true;
            this.colNGAYGD.VisibleIndex = 3;
            this.colNGAYGD.Width = 94;
            // 
            // groupControl3
            // 
            this.groupControl3.AllowTouchScroll = true;
            this.groupControl3.Controls.Add(this.usp_GetAccountByCustomerIdGridControl);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(673, 229);
            this.groupControl3.TabIndex = 13;
            this.groupControl3.Text = "Danh sách tài khoản của khách hàng";
            // 
            // usp_GetAccountByCustomerIdGridControl
            // 
            this.usp_GetAccountByCustomerIdGridControl.DataSource = this.bdsAccount;
            this.usp_GetAccountByCustomerIdGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usp_GetAccountByCustomerIdGridControl.Location = new System.Drawing.Point(2, 28);
            this.usp_GetAccountByCustomerIdGridControl.MainView = this.gvAccount;
            this.usp_GetAccountByCustomerIdGridControl.Name = "usp_GetAccountByCustomerIdGridControl";
            this.usp_GetAccountByCustomerIdGridControl.Size = new System.Drawing.Size(669, 199);
            this.usp_GetAccountByCustomerIdGridControl.TabIndex = 0;
            this.usp_GetAccountByCustomerIdGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAccount});
            // 
            // bdsAccount
            // 
            this.bdsAccount.DataMember = "usp_GetAccountByCustomerId";
            this.bdsAccount.DataSource = this.DS;
            // 
            // gvAccount
            // 
            this.gvAccount.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAccount.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAccount.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAccount.Appearance.Row.Options.UseFont = true;
            this.gvAccount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSOTK,
            this.colSODU,
            this.colNGAYMOTK});
            this.gvAccount.GridControl = this.usp_GetAccountByCustomerIdGridControl;
            this.gvAccount.Name = "gvAccount";
            this.gvAccount.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvAccount_FocusedRowChanged);
            // 
            // colSOTK
            // 
            this.colSOTK.AppearanceCell.Options.UseTextOptions = true;
            this.colSOTK.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSOTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colSOTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSOTK.Caption = "Số TK";
            this.colSOTK.FieldName = "SOTK";
            this.colSOTK.MinWidth = 25;
            this.colSOTK.Name = "colSOTK";
            this.colSOTK.OptionsColumn.ReadOnly = true;
            this.colSOTK.Visible = true;
            this.colSOTK.VisibleIndex = 0;
            this.colSOTK.Width = 94;
            // 
            // colSODU
            // 
            this.colSODU.AppearanceCell.Options.UseTextOptions = true;
            this.colSODU.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSODU.AppearanceHeader.Options.UseTextOptions = true;
            this.colSODU.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSODU.Caption = "Số dư";
            this.colSODU.DisplayFormat.FormatString = "{0:c0}";
            this.colSODU.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSODU.FieldName = "SODU";
            this.colSODU.MinWidth = 25;
            this.colSODU.Name = "colSODU";
            this.colSODU.OptionsColumn.ReadOnly = true;
            this.colSODU.Visible = true;
            this.colSODU.VisibleIndex = 1;
            this.colSODU.Width = 94;
            // 
            // colNGAYMOTK
            // 
            this.colNGAYMOTK.AppearanceCell.Options.UseTextOptions = true;
            this.colNGAYMOTK.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNGAYMOTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colNGAYMOTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNGAYMOTK.Caption = "Ngày mở TK";
            this.colNGAYMOTK.FieldName = "NGAYMOTK";
            this.colNGAYMOTK.MinWidth = 25;
            this.colNGAYMOTK.Name = "colNGAYMOTK";
            this.colNGAYMOTK.OptionsColumn.ReadOnly = true;
            this.colNGAYMOTK.Visible = true;
            this.colNGAYMOTK.VisibleIndex = 2;
            this.colNGAYMOTK.Width = 94;
            // 
            // gcEditEnpoint
            // 
            this.gcEditEnpoint.Controls.Add(this.pnInput);
            this.gcEditEnpoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEditEnpoint.Location = new System.Drawing.Point(0, 533);
            this.gcEditEnpoint.Name = "gcEditEnpoint";
            this.gcEditEnpoint.Size = new System.Drawing.Size(1147, 403);
            this.gcEditEnpoint.TabIndex = 17;
            this.gcEditEnpoint.Text = "Danh sách tài khoản cần chuyển";
            // 
            // pnInput
            // 
            this.pnInput.Controls.Add(this.gcEndpoints);
            this.pnInput.Controls.Add(this.panel2);
            this.pnInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnInput.Location = new System.Drawing.Point(2, 28);
            this.pnInput.Name = "pnInput";
            this.pnInput.Size = new System.Drawing.Size(1143, 373);
            this.pnInput.TabIndex = 19;
            // 
            // gcEndpoints
            // 
            this.gcEndpoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEndpoints.Location = new System.Drawing.Point(0, 0);
            this.gcEndpoints.MainView = this.gvEndpoints;
            this.gcEndpoints.Name = "gcEndpoints";
            this.gcEndpoints.Size = new System.Drawing.Size(830, 373);
            this.gcEndpoints.TabIndex = 5;
            this.gcEndpoints.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEndpoints});
            // 
            // gvEndpoints
            // 
            this.gvEndpoints.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvEndpoints.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvEndpoints.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvEndpoints.Appearance.Row.Options.UseFont = true;
            this.gvEndpoints.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvEndpoints.GridControl = this.gcEndpoints;
            this.gvEndpoints.Name = "gvEndpoints";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Số TK";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Họ tên";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "CMND";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 94;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Số tiền chuyển";
            this.gridColumn4.DisplayFormat.FormatString = "{0:c0}";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 94;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReload);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(830, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 373);
            this.panel2.TabIndex = 4;
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(6, 161);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(297, 33);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Làm mới";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.teModifiedBalance);
            this.panel1.Controls.Add(this.btnChangeEndpoints);
            this.panel1.Controls.Add(this.btnCommit);
            this.panel1.Controls.Add(this.teInitBalance);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 143);
            this.panel1.TabIndex = 4;
            // 
            // teModifiedBalance
            // 
            this.teModifiedBalance.Location = new System.Drawing.Point(106, 56);
            this.teModifiedBalance.Name = "teModifiedBalance";
            this.teModifiedBalance.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teModifiedBalance.Properties.Appearance.Options.UseFont = true;
            this.teModifiedBalance.Properties.DisplayFormat.FormatString = "{0:c0}";
            this.teModifiedBalance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teModifiedBalance.Properties.EditFormat.FormatString = "{0:c0}";
            this.teModifiedBalance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teModifiedBalance.Properties.Mask.EditMask = "c0";
            this.teModifiedBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teModifiedBalance.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.teModifiedBalance.Properties.ReadOnly = true;
            this.teModifiedBalance.Size = new System.Drawing.Size(174, 30);
            this.teModifiedBalance.TabIndex = 3;
            // 
            // btnChangeEndpoints
            // 
            this.btnChangeEndpoints.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeEndpoints.Location = new System.Drawing.Point(15, 96);
            this.btnChangeEndpoints.Name = "btnChangeEndpoints";
            this.btnChangeEndpoints.Size = new System.Drawing.Size(123, 33);
            this.btnChangeEndpoints.TabIndex = 5;
            this.btnChangeEndpoints.Text = "Hiệu chỉnh";
            this.btnChangeEndpoints.UseVisualStyleBackColor = true;
            this.btnChangeEndpoints.Click += new System.EventHandler(this.btnChangeEndpoints_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommit.Location = new System.Drawing.Point(155, 96);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(125, 33);
            this.btnCommit.TabIndex = 6;
            this.btnCommit.Text = "Xác nhận chuyển";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // teInitBalance
            // 
            this.teInitBalance.Location = new System.Drawing.Point(106, 18);
            this.teInitBalance.Name = "teInitBalance";
            this.teInitBalance.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teInitBalance.Properties.Appearance.Options.UseFont = true;
            this.teInitBalance.Properties.DisplayFormat.FormatString = "{0:c0}";
            this.teInitBalance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teInitBalance.Properties.EditFormat.FormatString = "{0:c0}";
            this.teInitBalance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teInitBalance.Properties.Mask.EditMask = "c0";
            this.teInitBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teInitBalance.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.teInitBalance.Properties.ReadOnly = true;
            this.teInitBalance.Size = new System.Drawing.Size(174, 30);
            this.teInitBalance.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số dư sau:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số dư đầu:";
            // 
            // taTrans
            // 
            this.taTrans.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.GD_CHUYENTIENTableAdapter = null;
            this.tableAdapterManager.GD_GOIRUTTableAdapter = null;
            this.tableAdapterManager.KhachHangTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.TaiKhoanTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = NganHangPhanTan.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // taCustomer
            // 
            this.taCustomer.ClearBeforeFill = true;
            // 
            // taAccount
            // 
            this.taAccount.ClearBeforeFill = true;
            // 
            // fTransExchange
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 936);
            this.Controls.Add(this.gcEditEnpoint);
            this.Controls.Add(this.pnBody);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fTransExchange";
            this.Text = "Giao dịch chuyển tiền";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fTransExchange_FormClosing);
            this.Load += new System.EventHandler(this.fTransExchange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usp_GetCustomerHavingAccountInSubcriberGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.pnBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnTrans)).EndInit();
            this.pnTrans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usp_GetAccountByCustomerIdGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEditEnpoint)).EndInit();
            this.gcEditEnpoint.ResumeLayout(false);
            this.pnInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEndpoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEndpoints)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teModifiedBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teInitBalance.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnBody;
        private DevExpress.XtraEditors.GroupControl pnTrans;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl gcEditEnpoint;
        private System.Windows.Forms.Panel pnInput;
        private DS DS;
        private System.Windows.Forms.BindingSource bdsTrans;
        private DSTableAdapters.usp_GetTransExchangeByAccountIdTableAdapter taTrans;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcTrans;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTrans;
        private System.Windows.Forms.BindingSource bdsCustomer;
        private DSTableAdapters.usp_GetCustomerHavingAccountInSubcriberTableAdapter taCustomer;
        private System.Windows.Forms.BindingSource bdsAccount;
        private DSTableAdapters.usp_GetAccountByCustomerIdTableAdapter taAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colMAGD;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTIEN;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYGD;
        private DevExpress.XtraGrid.GridControl gcEndpoints;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEndpoints;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnChangeEndpoints;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit teModifiedBalance;
        private DevExpress.XtraEditors.TextEdit teInitBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReload;
        private DevExpress.XtraGrid.GridControl usp_GetCustomerHavingAccountInSubcriberGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYCAP;
        private DevExpress.XtraGrid.Columns.GridColumn colSODT;
        private DevExpress.XtraGrid.GridControl usp_GetAccountByCustomerIdGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTK;
        private DevExpress.XtraGrid.Columns.GridColumn colSODU;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYMOTK;
    }
}