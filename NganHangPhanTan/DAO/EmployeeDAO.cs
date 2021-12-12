namespace NganHangPhanTan.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private EmployeeDAO() { }

        /// <summary>
        /// Kiểm tra mã nhân viên tồn tại trên site chủ
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public bool IsEmployeeIDExisted(string employeeID)
        {
            return (bool) DataProvider.Instance.ExecuteScalar($"SELECT dbo.udf_CheckEmployeeIDExisted(N'{employeeID}')");
        }
    }
}
