
namespace NganHangPhanTan.SimpleForm
{
    partial class fEmployeeMove
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
            this.btnMove = new System.Windows.Forms.Button();
            this.dS = new NganHangPhanTan.DS();
            this.bdsBrandOption = new System.Windows.Forms.BindingSource(this.components);
            this.usp_GetOtherBrandFromSubcriberTableAdapter = new NganHangPhanTan.DSTableAdapters.usp_GetOtherBrandFromSubcriberTableAdapter();
            this.tableAdapterManager = new NganHangPhanTan.DSTableAdapters.TableAdapterManager();
            this.usp_GetOtherBrandFromSubcriberGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMACN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENCN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBrandOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usp_GetOtherBrandFromSubcriberGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(1010, 342);
            this.btnMove.Margin = new System.Windows.Forms.Padding(4);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(198, 45);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "Chuyển";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsBrandOption
            // 
            this.bdsBrandOption.DataMember = "usp_GetOtherBrandFromSubcriber";
            this.bdsBrandOption.DataSource = this.dS;
            // 
            // usp_GetOtherBrandFromSubcriberTableAdapter
            // 
            this.usp_GetOtherBrandFromSubcriberTableAdapter.ClearBeforeFill = true;
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
            // usp_GetOtherBrandFromSubcriberGridControl
            // 
            this.usp_GetOtherBrandFromSubcriberGridControl.DataSource = this.bdsBrandOption;
            this.usp_GetOtherBrandFromSubcriberGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.usp_GetOtherBrandFromSubcriberGridControl.Location = new System.Drawing.Point(2, 28);
            this.usp_GetOtherBrandFromSubcriberGridControl.MainView = this.gridView1;
            this.usp_GetOtherBrandFromSubcriberGridControl.Margin = new System.Windows.Forms.Padding(4);
            this.usp_GetOtherBrandFromSubcriberGridControl.Name = "usp_GetOtherBrandFromSubcriberGridControl";
            this.usp_GetOtherBrandFromSubcriberGridControl.Size = new System.Drawing.Size(1217, 294);
            this.usp_GetOtherBrandFromSubcriberGridControl.TabIndex = 2;
            this.usp_GetOtherBrandFromSubcriberGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMACN,
            this.colTENCN,
            this.colDIACHI,
            this.colSoDT});
            this.gridView1.DetailHeight = 503;
            this.gridView1.FixedLineWidth = 3;
            this.gridView1.GridControl = this.usp_GetOtherBrandFromSubcriberGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMACN
            // 
            this.colMACN.Caption = "Mã CN";
            this.colMACN.FieldName = "MACN";
            this.colMACN.MinWidth = 32;
            this.colMACN.Name = "colMACN";
            this.colMACN.OptionsColumn.ReadOnly = true;
            this.colMACN.Visible = true;
            this.colMACN.VisibleIndex = 0;
            this.colMACN.Width = 121;
            // 
            // colTENCN
            // 
            this.colTENCN.Caption = "Tên chi nhánh";
            this.colTENCN.FieldName = "TENCN";
            this.colTENCN.MinWidth = 32;
            this.colTENCN.Name = "colTENCN";
            this.colTENCN.OptionsColumn.ReadOnly = true;
            this.colTENCN.Visible = true;
            this.colTENCN.VisibleIndex = 1;
            this.colTENCN.Width = 121;
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "Địa chỉ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 32;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.OptionsColumn.ReadOnly = true;
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 2;
            this.colDIACHI.Width = 121;
            // 
            // colSoDT
            // 
            this.colSoDT.Caption = "Số ĐT";
            this.colSoDT.FieldName = "SoDT";
            this.colSoDT.MinWidth = 32;
            this.colSoDT.Name = "colSoDT";
            this.colSoDT.OptionsColumn.ReadOnly = true;
            this.colSoDT.Visible = true;
            this.colSoDT.VisibleIndex = 3;
            this.colSoDT.Width = 121;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnMove);
            this.groupControl2.Controls.Add(this.usp_GetOtherBrandFromSubcriberGridControl);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1221, 403);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Chọn chi nhánh cần chuyển nhân viên:";
            // 
            // fEmployeeMove
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 403);
            this.Controls.Add(this.groupControl2);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fEmployeeMove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều chuyển nhân viên sang chi nhánh";
            this.Load += new System.EventHandler(this.fEmployeeMove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsBrandOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usp_GetOtherBrandFromSubcriberGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMove;
        private DS dS;
        private System.Windows.Forms.BindingSource bdsBrandOption;
        private DSTableAdapters.usp_GetOtherBrandFromSubcriberTableAdapter usp_GetOtherBrandFromSubcriberTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl usp_GetOtherBrandFromSubcriberGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN;
        private DevExpress.XtraGrid.Columns.GridColumn colTENCN;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDT;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}