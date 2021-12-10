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

        public bool IsEmployeeIDExisted(string employeeID)
        {
            return (bool) DataProvider.Instance.ExecuteScalar($"SELECT dbo.udf_CheckEmployeeIDExisted(N'{employeeID}')");
        }
    }
}
