namespace NganHangPhanTan.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO uniqueInstance;

        public static EmployeeDAO UniqueInstance
        {
            get
            {
                if (uniqueInstance == null)
                    uniqueInstance = new EmployeeDAO();
                return uniqueInstance;
            }
            private set { uniqueInstance = value; }
        }

        private EmployeeDAO() { }

        public bool isEmployeeIDExisted(string employeeID)
        {
            return (bool) DataProvider.UniqueInstance.ExecuteScalar($"SELECT dbo.udf_CheckEmployeeIDExisted(N'{employeeID}')");
        }
    }
}
