using NganHangPhanTan.DTO;
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
        private static UserDAO uniqueInstance;

        public static UserDAO UniqueInstance
        {
            get
            {
                if (uniqueInstance == null)
                    uniqueInstance = new UserDAO();
                return uniqueInstance;
            }
            private set { uniqueInstance = value; }
        }

        private UserDAO() { }

        /// <summary>
        /// Login to subcriber. Return new user instance if successful; otherwise return null.
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public User Login(string loginName)
        {
            string query = "EXEC dbo.usp_Login @LoginName";
            DataTable data = DataProvider.UniqueInstance.ExecuteQueryDataTable(query, new object[] { loginName });
            if (data == null)
                return null;

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu.\nVui lòng nhập lại mã nhân viên.", "", MessageBoxButtons.OK);
                return null;
            }

            User user = new User(data.Rows[0]);
            //MessageBox.Show($"Đăng nhập thành công.\nXin chào {user.Fullname}.", "", MessageBoxButtons.OK);
            return user;
        }
    }

}
