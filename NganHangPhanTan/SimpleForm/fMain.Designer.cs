
namespace NganHangPhanTan
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.btnOpenedAccountReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomerInfoReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveCashService = new DevExpress.XtraBars.BarButtonItem();
            this.btnTransferService = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.btnTransactionReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateAccount = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomerManage = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployeeManage = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpenCustomerAccount = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateLogin = new DevExpress.XtraBars.BarButtonItem();
            this.ribSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribCategory = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribService = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribReport = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssEmployeeID = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssEmployeeName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssEmployeeGroup = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiManager)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barStaticItem1,
            this.btnOpenedAccountReport,
            this.btnCustomerInfoReport,
            this.btnSaveCashService,
            this.btnTransferService,
            this.barButtonItem14,
            this.btnTransactionReport,
            this.btnLogin,
            this.btnCreateAccount,
            this.btnLogout,
            this.btnCustomerManage,
            this.btnEmployeeManage,
            this.btnOpenCustomerAccount,
            this.btnCreateLogin});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 24;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribSystem,
            this.ribCategory,
            this.ribService,
            this.ribReport});
            this.ribbonControl1.Size = new System.Drawing.Size(1178, 193);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Đăng nhập";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Đăng xuất";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Tạo tài khoản";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Thoát";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Id = 5;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // btnOpenedAccountReport
            // 
            this.btnOpenedAccountReport.Caption = "Danh sách tài khoản mở";
            this.btnOpenedAccountReport.Id = 6;
            this.btnOpenedAccountReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenedAccountReport.ImageOptions.Image")));
            this.btnOpenedAccountReport.LargeWidth = 100;
            this.btnOpenedAccountReport.Name = "btnOpenedAccountReport";
            this.btnOpenedAccountReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOpenedAccountReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenAccountReport_ItemClick);
            // 
            // btnCustomerInfoReport
            // 
            this.btnCustomerInfoReport.Caption = "Thống kê thông tin khách hàng";
            this.btnCustomerInfoReport.Id = 7;
            this.btnCustomerInfoReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerInfoReport.ImageOptions.Image")));
            this.btnCustomerInfoReport.LargeWidth = 100;
            this.btnCustomerInfoReport.Name = "btnCustomerInfoReport";
            this.btnCustomerInfoReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCustomerInfoReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomerInfoReport_ItemClick);
            // 
            // btnSaveCashService
            // 
            this.btnSaveCashService.Caption = "Gửi và rút tiền";
            this.btnSaveCashService.Id = 8;
            this.btnSaveCashService.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCashService.ImageOptions.Image")));
            this.btnSaveCashService.LargeWidth = 100;
            this.btnSaveCashService.Name = "btnSaveCashService";
            this.btnSaveCashService.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSaveCashService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSendWithdrawService_ItemClick);
            // 
            // btnTransferService
            // 
            this.btnTransferService.Caption = "Chuyển khoản";
            this.btnTransferService.Id = 9;
            this.btnTransferService.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTransferService.ImageOptions.Image")));
            this.btnTransferService.LargeWidth = 100;
            this.btnTransferService.Name = "btnTransferService";
            this.btnTransferService.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTransferService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTransferService_ItemClick);
            // 
            // barButtonItem14
            // 
            this.barButtonItem14.Caption = "Giao dịch của tài khoản";
            this.barButtonItem14.Id = 15;
            this.barButtonItem14.Name = "barButtonItem14";
            // 
            // btnTransactionReport
            // 
            this.btnTransactionReport.Caption = "Sao kê tài khoản";
            this.btnTransactionReport.Id = 16;
            this.btnTransactionReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTransactionReport.ImageOptions.Image")));
            this.btnTransactionReport.LargeWidth = 100;
            this.btnTransactionReport.Name = "btnTransactionReport";
            this.btnTransactionReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTransactionReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAccTransactionReport_ItemClick);
            // 
            // btnLogin
            // 
            this.btnLogin.Caption = "Đăng nhập";
            this.btnLogin.Id = 17;
            this.btnLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.ImageOptions.Image")));
            this.btnLogin.LargeWidth = 100;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogin_ItemClick);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Caption = "Tạo tài khoản";
            this.btnCreateAccount.Id = 18;
            this.btnCreateAccount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateAccount.ImageOptions.Image")));
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnCreateAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateAccount_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Đăng xuất";
            this.btnLogout.Id = 19;
            this.btnLogout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.Image")));
            this.btnLogout.LargeWidth = 100;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnCustomerManage
            // 
            this.btnCustomerManage.Caption = "Khách hàng";
            this.btnCustomerManage.Id = 20;
            this.btnCustomerManage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerManage.ImageOptions.Image")));
            this.btnCustomerManage.LargeWidth = 100;
            this.btnCustomerManage.Name = "btnCustomerManage";
            this.btnCustomerManage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCustomerManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomerManage_ItemClick);
            // 
            // btnEmployeeManage
            // 
            this.btnEmployeeManage.Caption = "Nhân viên";
            this.btnEmployeeManage.Id = 21;
            this.btnEmployeeManage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeManage.ImageOptions.Image")));
            this.btnEmployeeManage.LargeWidth = 100;
            this.btnEmployeeManage.Name = "btnEmployeeManage";
            this.btnEmployeeManage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnEmployeeManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnManageEmployee_ItemClick);
            // 
            // btnOpenCustomerAccount
            // 
            this.btnOpenCustomerAccount.Caption = "Mở tài khoản";
            this.btnOpenCustomerAccount.Id = 22;
            this.btnOpenCustomerAccount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenCustomerAccount.ImageOptions.Image")));
            this.btnOpenCustomerAccount.LargeWidth = 100;
            this.btnOpenCustomerAccount.Name = "btnOpenCustomerAccount";
            this.btnOpenCustomerAccount.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnOpenCustomerAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpenCustomerAccount_ItemClick);
            // 
            // btnCreateLogin
            // 
            this.btnCreateLogin.Caption = "Tạo tài khoản";
            this.btnCreateLogin.Id = 23;
            this.btnCreateLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateLogin.ImageOptions.Image")));
            this.btnCreateLogin.LargeWidth = 100;
            this.btnCreateLogin.Name = "btnCreateLogin";
            this.btnCreateLogin.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCreateLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateLogin_ItemClick);
            // 
            // ribSystem
            // 
            this.ribSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribSystem.Name = "ribSystem";
            this.ribSystem.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogin);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogout);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCreateLogin);
            this.ribbonPageGroup1.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.ThreeRows;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribCategory
            // 
            this.ribCategory.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribCategory.Name = "ribCategory";
            this.ribCategory.Text = "Danh mục";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCustomerManage);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnEmployeeManage);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribService
            // 
            this.ribService.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.ribService.Name = "ribService";
            this.ribService.Text = "Nghiệp vụ";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnOpenCustomerAccount);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnSaveCashService);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnTransferService);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribReport
            // 
            this.ribReport.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribReport.Name = "ribReport";
            this.ribReport.Text = "Báo cáo";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnTransactionReport);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnOpenedAccountReport);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnCustomerInfoReport);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // mdiManager
            // 
            this.mdiManager.MdiParent = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssEmployeeID,
            this.tssEmployeeName,
            this.tssEmployeeGroup});
            this.statusStrip1.Location = new System.Drawing.Point(0, 668);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1178, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssEmployeeID
            // 
            this.tssEmployeeID.Name = "tssEmployeeID";
            this.tssEmployeeID.Size = new System.Drawing.Size(97, 20);
            this.tssEmployeeID.Text = "Mã nhân viên";
            // 
            // tssEmployeeName
            // 
            this.tssEmployeeName.Name = "tssEmployeeName";
            this.tssEmployeeName.Size = new System.Drawing.Size(54, 20);
            this.tssEmployeeName.Text = "Họ tên";
            // 
            // tssEmployeeGroup
            // 
            this.tssEmployeeGroup.Name = "tssEmployeeGroup";
            this.tssEmployeeGroup.Size = new System.Drawing.Size(52, 20);
            this.tssEmployeeGroup.Text = "Vai trò";
            // 
            // fMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 694);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Quản lý nghiệp vụ ngân hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.Load += new System.EventHandler(this.fMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdiManager)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribCategory;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribService;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribReport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnOpenedAccountReport;
        private DevExpress.XtraBars.BarButtonItem btnCustomerInfoReport;
        private DevExpress.XtraBars.BarButtonItem btnSaveCashService;
        private DevExpress.XtraBars.BarButtonItem btnTransferService;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarButtonItem btnTransactionReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdiManager;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssEmployeeID;
        private System.Windows.Forms.ToolStripStatusLabel tssEmployeeName;
        private System.Windows.Forms.ToolStripStatusLabel tssEmployeeGroup;
        private DevExpress.XtraBars.BarButtonItem btnLogin;
        private DevExpress.XtraBars.BarButtonItem btnCreateAccount;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnCustomerManage;
        private DevExpress.XtraBars.BarButtonItem btnEmployeeManage;
        private DevExpress.XtraBars.BarButtonItem btnOpenCustomerAccount;
        private DevExpress.XtraBars.BarButtonItem btnCreateLogin;
    }
}

