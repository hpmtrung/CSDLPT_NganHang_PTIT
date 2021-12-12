namespace NganHangPhanTan.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private CustomerDAO() { }

        /// <summary>
        /// Kiểm tra mã CMND khách hàng tồn tại trên site 3
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool ExistById(string customerId)
        {
            return (bool)DataProvider.Instance.ExecuteScalar($"SELECT dbo.udf_CheckCustomerExistedById('{customerId}')");
        }
    }
}
