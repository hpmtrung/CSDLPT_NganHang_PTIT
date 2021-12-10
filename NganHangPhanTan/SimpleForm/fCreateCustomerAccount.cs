using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NganHangPhanTan.SimpleForm
{
    public partial class fCreateCustomerAccount : DevExpress.XtraEditors.XtraForm
    {
        public fCreateCustomerAccount()
        {
            InitializeComponent();
        }

        private void khachHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.khachHangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void fCreateCustomerAccount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);
            // TODO: This line of code loads data into the 'dS.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.dS.KhachHang);

        }
    }
}