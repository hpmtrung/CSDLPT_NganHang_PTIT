using NganHangPhanTan.DTO;
using NganHangPhanTan.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NganHangPhanTan.DAO
{
    public class UserDAO
    {
        private static UserDAO instance;

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private UserDAO() { }

        /// <summary>
        /// Login to subcriber. Return new user instance if successful; otherwise return null.
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public User Login(string loginName)
        {
            DataTable data = DataProvider.Instance.ExecuteDataTable($"EXEC dbo.usp_Login @loginName", new object[] { loginName });
            if (data == null)
                return null;

            if (data.Rows.Count == 0)
            {
                MessageUtil.ShowInfoMsgDialog("Login bạn nhập không có quyền truy cập dữ liệu.\nVui lòng nhập lại mã nhân viên.");
                return null;
            }

            return new User(data.Rows[0]);
        }
    }

}
