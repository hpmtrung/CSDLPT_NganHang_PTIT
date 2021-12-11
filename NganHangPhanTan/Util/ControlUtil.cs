using NganHangPhanTan.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NganHangPhanTan.Util
{
    public class ControlUtil
    {
        public readonly static int MAX_RECORD_STACK = 50;

        public readonly static string BRAND_DISPLAY_NAME = "TENCN";
        public readonly static string BRAND_VALUE_NAME = "TENSERVER";

        public static void SetEnableOfAllButtons(Form frm, Boolean Active)
        {
            foreach (Control ctl in frm.Controls)
                if ((ctl) is Button)
                    ctl.Enabled = Active;
        }

        public static Form CheckFormExists(Form parent, Type ftype)
        {
            foreach (Form f in parent.MdiChildren)
            {
                if (f.GetType() == ftype)
                    return f;
            }
            return null;
        }

        public static void ConfigComboboxBrand(ComboBox cb)
        {
            cb.DisplayMember = BRAND_DISPLAY_NAME;
            cb.ValueMember = BRAND_VALUE_NAME;
            cb.DataSource = DataProvider.Instance.GetBSSubcribers();
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void ConfigComboboxGender(ComboBox cb)
        {
            cb.Items.AddRange(new object[] {"Nam", "Nữ"});
            cb.SelectedIndex = 0;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static string RemoveDuplicateSpace(string str)
        {
            return Regex.Replace(str, @"\s+", " ");
        }

        public static String CapitalizeFirstLetter(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException();
            string res = "";
            string[] words = Regex.Split(str, @"\s+");
            foreach (string word in words)
            {
                res += $"{word.First().ToString().ToUpper()}{word.Substring(1).ToLower()} ";
            }
            return res.TrimEnd();
        }

        public static void ResolveStackStorage(LinkedList<UserEventData> stack)
        {
            if (stack.Count == MAX_RECORD_STACK)
                stack.RemoveFirst();
        }

        public static void Debug(params object[] obs)
        {
            string msg = "";
            foreach (var o in obs)
                msg += (o != null ? o.ToString() : "null") + "\n";
            MessageBox.Show(msg, "DEBUG");
        }

        public static string GetTextInCombobox(ComboBox cmb)
        {
            return cmb.GetItemText(cmb.SelectedItem);
        }

        private ControlUtil() 
        {
            throw new Exception();
        }
    }
}
