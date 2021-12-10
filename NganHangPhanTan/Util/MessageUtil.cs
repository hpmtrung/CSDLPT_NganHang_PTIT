using System.Windows.Forms;

namespace NganHangPhanTan.Util
{
    public class MessageUtil
    {
        public static void ShowSuccessMsgDialog(string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarnMsgDialog(string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowErrorMsgDialog(string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
