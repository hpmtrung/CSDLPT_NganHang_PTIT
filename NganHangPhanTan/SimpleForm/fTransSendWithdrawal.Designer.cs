
namespace NganHangPhanTan.SimpleForm
{
    partial class fTransSendWithdrawal
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
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label sOTIENLabel;
            System.Windows.Forms.Label sOTKLabel;
            System.Windows.Forms.Label nGAYGDLabel;
            System.Windows.Forms.Label lOAIGDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTransSendWithdrawal));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcCustomer = new DevExpress.XtraGrid.GridControl();
            this.bdsCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new NganHangPhanTan.DS();
            this.gvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYCAP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.pnInput = new System.Windows.Forms.Panel();
            this.teTransType = new DevExpress.XtraEditors.TextEdit();
            this.bdsTrans = new System.Windows.Forms.BindingSource(this.components);
            this.teEmployeeId = new DevExpress.XtraEditors.TextEdit();
            this.teTransMoney = new DevExpress.XtraEditors.TextEdit();
            this.deTransDate = new DevExpress.XtraEditors.DateEdit();
            this.teAccountId = new DevExpress.XtraEditors.TextEdit();
            this.cbTransTypeName = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsert = new DevExpress.XtraEditors.SimpleButton();
            this.tableAdapterManager = new NganHangPhanTan.DSTableAdapters.TableAdapterManager();
            this.pnBody = new System.Windows.Forms.Panel();
            this.pnTrans = new DevExpress.XtraEditors.GroupControl();
            this.gcTrans = new DevExpress.XtraGrid.GridControl();
            this.gvTrans = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENLOAIGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOAIGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTENNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYGD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gcAccount = new DevExpress.XtraGrid.GridControl();
            this.bdsAccount = new System.Windows.Forms.BindingSource(this.components);
            this.gvAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSOTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYMOTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.taCustomer = new NganHangPhanTan.DSTableAdapters.usp_GetCustomerHavingAccountInSubcriberTableAdapter();
            this.taAccount = new NganHangPhanTan.DSTableAdapters.usp_GetAccountByCustomerIdTableAdapter();
            this.taTrans = new NganHangPhanTan.DSTableAdapters.usp_GetTransSendWithdrawalByAccountIdTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            mANVLabel = new System.Windows.Forms.Label();
            sOTIENLabel = new System.Windows.Forms.Label();
            sOTKLabel = new System.Windows.Forms.Label();
            nGAYGDLabel = new System.Windows.Forms.Label();
            lOAIGDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.pnInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teTransType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmployeeId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTransMoney.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAccountId.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnTrans)).BeginInit();
            this.pnTrans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mANVLabel.Location = new System.Drawing.Point(32, 121);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(118, 23);
            mANVLabel.TabIndex = 29;
            mANVLabel.Text = "Mã nhân viên:";
            // 
            // sOTIENLabel
            // 
            sOTIENLabel.AutoSize = true;
            sOTIENLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sOTIENLabel.Location = new System.Drawing.Point(753, 43);
            sOTIENLabel.Name = "sOTIENLabel";
            sOTIENLabel.Size = new System.Drawing.Size(67, 23);
            sOTIENLabel.TabIndex = 26;
            sOTIENLabel.Text = "Số tiền:";
            // 
            // sOTKLabel
            // 
            sOTKLabel.AutoSize = true;
            sOTKLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sOTKLabel.Location = new System.Drawing.Point(398, 44);
            sOTKLabel.Name = "sOTKLabel";
            sOTKLabel.Size = new System.Drawing.Size(109, 23);
            sOTKLabel.TabIndex = 20;
            sOTKLabel.Text = "Số tài khoản:";
            // 
            // nGAYGDLabel
            // 
            nGAYGDLabel.AutoSize = true;
            nGAYGDLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nGAYGDLabel.Location = new System.Drawing.Point(376, 121);
            nGAYGDLabel.Name = "nGAYGDLabel";
            nGAYGDLabel.Size = new System.Drawing.Size(131, 23);
            nGAYGDLabel.TabIndex = 24;
            nGAYGDLabel.Text = "Ngày thực hiện:";
            // 
            // lOAIGDLabel
            // 
            lOAIGDLabel.AutoSize = true;
            lOAIGDLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lOAIGDLabel.Location = new System.Drawing.Point(76, 43);
            lOAIGDLabel.Name = "lOAIGDLabel";
            lOAIGDLabel.Size = new System.Drawing.Size(74, 23);
            lOAIGDLabel.TabIndex = 23;
            lOAIGDLabel.Text = "Loại GD:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbBrand);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1356, 74);
            this.panelControl1.TabIndex = 7;
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcCustomer);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 74);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1356, 249);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Danh sách khách hàng đăng ký tài khoản thuộc chi nhánh";
            // 
            // gcCustomer
            // 
            this.gcCustomer.DataSource = this.bdsCustomer;
            this.gcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCustomer.Location = new System.Drawing.Point(2, 28);
            this.gcCustomer.MainView = this.gvCustomer;
            this.gcCustomer.Name = "gcCustomer";
            this.gcCustomer.Size = new System.Drawing.Size(1352, 219);
            this.gcCustomer.TabIndex = 0;
            this.gcCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.gvCustomer.GridControl = this.gcCustomer;
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCustomer_FocusedRowChanged);
            // 
            // colCMND
            // 
            this.colCMND.Caption = "Số CMND";
            this.colCMND.FieldName = "CMND";
            this.colCMND.MinWidth = 25;
            this.colCMND.Name = "colCMND";
            this.colCMND.OptionsColumn.ReadOnly = true;
            this.colCMND.Visible = true;
            this.colCMND.VisibleIndex = 0;
            this.colCMND.Width = 94;
            // 
            // colHOTEN
            // 
            this.colHOTEN.Caption = "Họ tên";
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.MinWidth = 25;
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.OptionsColumn.ReadOnly = true;
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 1;
            this.colHOTEN.Width = 94;
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "Địa chỉ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 25;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.OptionsColumn.ReadOnly = true;
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 2;
            this.colDIACHI.Width = 94;
            // 
            // colNGAYCAP
            // 
            this.colNGAYCAP.Caption = "Ngày cấp";
            this.colNGAYCAP.FieldName = "NGAYCAP";
            this.colNGAYCAP.MinWidth = 25;
            this.colNGAYCAP.Name = "colNGAYCAP";
            this.colNGAYCAP.OptionsColumn.ReadOnly = true;
            this.colNGAYCAP.Visible = true;
            this.colNGAYCAP.VisibleIndex = 3;
            this.colNGAYCAP.Width = 94;
            // 
            // colSODT
            // 
            this.colSODT.Caption = "Số ĐT";
            this.colSODT.FieldName = "SODT";
            this.colSODT.MinWidth = 25;
            this.colSODT.Name = "colSODT";
            this.colSODT.OptionsColumn.ReadOnly = true;
            this.colSODT.Visible = true;
            this.colSODT.VisibleIndex = 4;
            this.colSODT.Width = 94;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.pnInput);
            this.groupControl2.Controls.Add(this.panel1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 822);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1356, 240);
            this.groupControl2.TabIndex = 13;
            this.groupControl2.Text = "Thông tin giao dịch gửi/rút tiền";
            // 
            // pnInput
            // 
            this.pnInput.Controls.Add(this.panel2);
            this.pnInput.Controls.Add(this.teTransType);
            this.pnInput.Controls.Add(mANVLabel);
            this.pnInput.Controls.Add(this.teEmployeeId);
            this.pnInput.Controls.Add(sOTIENLabel);
            this.pnInput.Controls.Add(sOTKLabel);
            this.pnInput.Controls.Add(this.teTransMoney);
            this.pnInput.Controls.Add(nGAYGDLabel);
            this.pnInput.Controls.Add(this.deTransDate);
            this.pnInput.Controls.Add(this.teAccountId);
            this.pnInput.Controls.Add(lOAIGDLabel);
            this.pnInput.Controls.Add(this.cbTransTypeName);
            this.pnInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnInput.Location = new System.Drawing.Point(2, 68);
            this.pnInput.Name = "pnInput";
            this.pnInput.Size = new System.Drawing.Size(1352, 170);
            this.pnInput.TabIndex = 19;
            // 
            // teTransType
            // 
            this.teTransType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsTrans, "LOAIGD", true));
            this.teTransType.Location = new System.Drawing.Point(1217, 138);
            this.teTransType.Name = "teTransType";
            this.teTransType.Size = new System.Drawing.Size(125, 22);
            this.teTransType.TabIndex = 31;
            this.teTransType.TextChanged += new System.EventHandler(this.teTransType_TextChanged);
            // 
            // bdsTrans
            // 
            this.bdsTrans.DataMember = "usp_GetTransSendWithdrawalByAccountId";
            this.bdsTrans.DataSource = this.DS;
            // 
            // teEmployeeId
            // 
            this.teEmployeeId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsTrans, "MANV", true));
            this.teEmployeeId.Location = new System.Drawing.Point(156, 118);
            this.teEmployeeId.Name = "teEmployeeId";
            this.teEmployeeId.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teEmployeeId.Properties.Appearance.Options.UseFont = true;
            this.teEmployeeId.Properties.ReadOnly = true;
            this.teEmployeeId.Size = new System.Drawing.Size(169, 30);
            this.teEmployeeId.TabIndex = 30;
            // 
            // teTransMoney
            // 
            this.teTransMoney.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsTrans, "SOTIEN", true));
            this.teTransMoney.Location = new System.Drawing.Point(826, 40);
            this.teTransMoney.Name = "teTransMoney";
            this.teTransMoney.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teTransMoney.Properties.Appearance.Options.UseFont = true;
            this.teTransMoney.Properties.DisplayFormat.FormatString = "{0:c0}";
            this.teTransMoney.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teTransMoney.Properties.EditFormat.FormatString = "{0:c0}";
            this.teTransMoney.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.teTransMoney.Properties.Mask.EditMask = "c0";
            this.teTransMoney.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.teTransMoney.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.teTransMoney.Size = new System.Drawing.Size(169, 30);
            this.teTransMoney.TabIndex = 28;
            // 
            // deTransDate
            // 
            this.deTransDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsTrans, "NGAYGD", true));
            this.deTransDate.EditValue = null;
            this.deTransDate.Location = new System.Drawing.Point(513, 118);
            this.deTransDate.Name = "deTransDate";
            this.deTransDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deTransDate.Properties.Appearance.Options.UseFont = true;
            this.deTransDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTransDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTransDate.Properties.ReadOnly = true;
            this.deTransDate.Size = new System.Drawing.Size(165, 30);
            this.deTransDate.TabIndex = 27;
            // 
            // teAccountId
            // 
            this.teAccountId.Location = new System.Drawing.Point(513, 40);
            this.teAccountId.Name = "teAccountId";
            this.teAccountId.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teAccountId.Properties.Appearance.Options.UseFont = true;
            this.teAccountId.Properties.ReadOnly = true;
            this.teAccountId.Size = new System.Drawing.Size(165, 30);
            this.teAccountId.TabIndex = 22;
            // 
            // cbTransTypeName
            // 
            this.cbTransTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransTypeName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransTypeName.FormattingEnabled = true;
            this.cbTransTypeName.Items.AddRange(new object[] {
            "Rút tiền",
            "Gửi tiền"});
            this.cbTransTypeName.Location = new System.Drawing.Point(155, 40);
            this.cbTransTypeName.Name = "cbTransTypeName";
            this.cbTransTypeName.Size = new System.Drawing.Size(170, 31);
            this.cbTransTypeName.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1352, 40);
            this.panel1.TabIndex = 11;
            // 
            // btnReload
            // 
            this.btnReload.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Appearance.Options.UseFont = true;
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReload.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.Image")));
            this.btnReload.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnReload.Location = new System.Drawing.Point(338, 0);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(119, 40);
            this.btnReload.TabIndex = 27;
            this.btnReload.Text = "Xem lại";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnSave.ImageOptions.Image = global::NganHangPhanTan.Properties.Resources.diskette;
            this.btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnSave.Location = new System.Drawing.Point(230, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 40);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnCancel.Location = new System.Drawing.Point(115, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 40);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Appearance.Options.UseFont = true;
            this.btnInsert.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInsert.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnInsert.ImageOptions.Image = global::NganHangPhanTan.Properties.Resources.add;
            this.btnInsert.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom;
            this.btnInsert.Location = new System.Drawing.Point(0, 0);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(115, 40);
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.Click += new System.EventHandler(this.btnInsertAcc_Click);
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
            // pnBody
            // 
            this.pnBody.Controls.Add(this.pnTrans);
            this.pnBody.Controls.Add(this.groupControl3);
            this.pnBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBody.Location = new System.Drawing.Point(0, 323);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(1356, 499);
            this.pnBody.TabIndex = 15;
            // 
            // pnTrans
            // 
            this.pnTrans.Controls.Add(this.gcTrans);
            this.pnTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTrans.Location = new System.Drawing.Point(764, 0);
            this.pnTrans.Name = "pnTrans";
            this.pnTrans.Size = new System.Drawing.Size(592, 499);
            this.pnTrans.TabIndex = 14;
            this.pnTrans.Text = "Giao dịch gửi / rút của tài khoản";
            // 
            // gcTrans
            // 
            this.gcTrans.DataSource = this.bdsTrans;
            this.gcTrans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTrans.Location = new System.Drawing.Point(2, 28);
            this.gcTrans.MainView = this.gvTrans;
            this.gcTrans.Name = "gcTrans";
            this.gcTrans.Size = new System.Drawing.Size(588, 469);
            this.gcTrans.TabIndex = 0;
            this.gcTrans.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTrans});
            // 
            // gvTrans
            // 
            this.gvTrans.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTrans.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvTrans.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTrans.Appearance.Row.Options.UseFont = true;
            this.gvTrans.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAGD,
            this.colTENLOAIGD,
            this.colLOAIGD,
            this.colSOTIEN,
            this.colMANV,
            this.colHOTENNV,
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
            this.colMAGD.Visible = true;
            this.colMAGD.VisibleIndex = 0;
            this.colMAGD.Width = 94;
            // 
            // colTENLOAIGD
            // 
            this.colTENLOAIGD.AppearanceCell.Options.UseTextOptions = true;
            this.colTENLOAIGD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTENLOAIGD.AppearanceHeader.Options.UseTextOptions = true;
            this.colTENLOAIGD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTENLOAIGD.Caption = "Loại GD";
            this.colTENLOAIGD.FieldName = "TENLOAIGD";
            this.colTENLOAIGD.MinWidth = 25;
            this.colTENLOAIGD.Name = "colTENLOAIGD";
            this.colTENLOAIGD.UnboundExpression = "Iif([LOAIGD] = \'RT\', \'Rút tiền\', [LOAIGD] = \'GT\', \'Gửi tiền\', [LOAIGD] = \'CT\', \'C" +
    "huyển tiền\', \'\')";
            this.colTENLOAIGD.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colTENLOAIGD.Visible = true;
            this.colTENLOAIGD.VisibleIndex = 1;
            this.colTENLOAIGD.Width = 94;
            // 
            // colLOAIGD
            // 
            this.colLOAIGD.AppearanceHeader.Options.UseTextOptions = true;
            this.colLOAIGD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLOAIGD.FieldName = "LOAIGD";
            this.colLOAIGD.MinWidth = 25;
            this.colLOAIGD.Name = "colLOAIGD";
            this.colLOAIGD.Width = 94;
            // 
            // colSOTIEN
            // 
            this.colSOTIEN.AppearanceHeader.Options.UseTextOptions = true;
            this.colSOTIEN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSOTIEN.Caption = "Số tiền";
            this.colSOTIEN.DisplayFormat.FormatString = "{0:c0}";
            this.colSOTIEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSOTIEN.FieldName = "SOTIEN";
            this.colSOTIEN.MinWidth = 25;
            this.colSOTIEN.Name = "colSOTIEN";
            this.colSOTIEN.Visible = true;
            this.colSOTIEN.VisibleIndex = 2;
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
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 3;
            this.colMANV.Width = 94;
            // 
            // colHOTENNV
            // 
            this.colHOTENNV.AppearanceHeader.Options.UseTextOptions = true;
            this.colHOTENNV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHOTENNV.Caption = "Họ tên NV";
            this.colHOTENNV.FieldName = "HOTENNV";
            this.colHOTENNV.MinWidth = 25;
            this.colHOTENNV.Name = "colHOTENNV";
            this.colHOTENNV.Visible = true;
            this.colHOTENNV.VisibleIndex = 4;
            this.colHOTENNV.Width = 94;
            // 
            // colNGAYGD
            // 
            this.colNGAYGD.AppearanceCell.Options.UseTextOptions = true;
            this.colNGAYGD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNGAYGD.AppearanceHeader.Options.UseTextOptions = true;
            this.colNGAYGD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNGAYGD.Caption = "Ngày thực hiện";
            this.colNGAYGD.FieldName = "NGAYGD";
            this.colNGAYGD.MinWidth = 25;
            this.colNGAYGD.Name = "colNGAYGD";
            this.colNGAYGD.Visible = true;
            this.colNGAYGD.VisibleIndex = 5;
            this.colNGAYGD.Width = 94;
            // 
            // groupControl3
            // 
            this.groupControl3.AllowTouchScroll = true;
            this.groupControl3.Controls.Add(this.gcAccount);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(764, 499);
            this.groupControl3.TabIndex = 13;
            this.groupControl3.Text = "Danh sách tài khoản của khách hàng";
            // 
            // gcAccount
            // 
            this.gcAccount.DataSource = this.bdsAccount;
            this.gcAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAccount.Location = new System.Drawing.Point(2, 28);
            this.gcAccount.MainView = this.gvAccount;
            this.gcAccount.Name = "gcAccount";
            this.gcAccount.Size = new System.Drawing.Size(760, 469);
            this.gcAccount.TabIndex = 0;
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
            this.gvAccount.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAccount.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAccount.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAccount.Appearance.Row.Options.UseFont = true;
            this.gvAccount.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSOTK,
            this.colSODU,
            this.colNGAYMOTK});
            this.gvAccount.GridControl = this.gcAccount;
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
            this.colNGAYMOTK.DisplayFormat.FormatString = "d";
            this.colNGAYMOTK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAYMOTK.FieldName = "NGAYMOTK";
            this.colNGAYMOTK.MinWidth = 25;
            this.colNGAYMOTK.Name = "colNGAYMOTK";
            this.colNGAYMOTK.OptionsColumn.ReadOnly = true;
            this.colNGAYMOTK.Visible = true;
            this.colNGAYMOTK.VisibleIndex = 2;
            this.colNGAYMOTK.Width = 94;
            // 
            // taCustomer
            // 
            this.taCustomer.ClearBeforeFill = true;
            // 
            // taAccount
            // 
            this.taAccount.ClearBeforeFill = true;
            // 
            // taTrans
            // 
            this.taTrans.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1099, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 116);
            this.panel2.TabIndex = 32;
            // 
            // fTransSendWithdrawal
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1356, 1062);
            this.Controls.Add(this.pnBody);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fTransSendWithdrawal";
            this.Text = "Giao dịch gửi rút tiền";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fTransSendWithdrawal_FormClosing);
            this.Load += new System.EventHandler(this.fTransSendWithdrawal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.pnInput.ResumeLayout(false);
            this.pnInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teTransType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEmployeeId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTransMoney.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTransDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAccountId.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnTrans)).EndInit();
            this.pnTrans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DS DS;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnInsert;
        private System.Windows.Forms.Panel pnBody;
        private DevExpress.XtraEditors.GroupControl pnTrans;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Panel pnInput;
        private DevExpress.XtraEditors.TextEdit teEmployeeId;
        private DevExpress.XtraEditors.TextEdit teTransMoney;
        private DevExpress.XtraEditors.DateEdit deTransDate;
        private DevExpress.XtraEditors.TextEdit teAccountId;
        private System.Windows.Forms.ComboBox cbTransTypeName;
        private System.Windows.Forms.BindingSource bdsCustomer;
        private DSTableAdapters.usp_GetCustomerHavingAccountInSubcriberTableAdapter taCustomer;
        private DevExpress.XtraGrid.GridControl gcCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYCAP;
        private DevExpress.XtraGrid.Columns.GridColumn colSODT;
        private System.Windows.Forms.BindingSource bdsAccount;
        private DSTableAdapters.usp_GetAccountByCustomerIdTableAdapter taAccount;
        private DevExpress.XtraGrid.GridControl gcAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTK;
        private DevExpress.XtraGrid.Columns.GridColumn colSODU;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYMOTK;
        private System.Windows.Forms.BindingSource bdsTrans;
        private DSTableAdapters.usp_GetTransSendWithdrawalByAccountIdTableAdapter taTrans;
        private DevExpress.XtraGrid.GridControl gcTrans;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTrans;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colMAGD;
        private DevExpress.XtraGrid.Columns.GridColumn colTENLOAIGD;
        private DevExpress.XtraGrid.Columns.GridColumn colLOAIGD;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTIEN;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTENNV;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYGD;
        private DevExpress.XtraEditors.TextEdit teTransType;
        private System.Windows.Forms.Panel panel2;
    }
}