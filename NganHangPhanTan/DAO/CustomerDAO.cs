using System.Data;
using System.Data.SqlClient;

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

        /// <summary>
        /// Check if customer with personalId having any account
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool HavingAnyAccount(string customerId)
        {
            return (bool)DataProvider.Instance.ExecuteScalar($"SELECT dbo.udf_CheckAccountExistedByPersonalId('{customerId}')");
        }

        /// <summary>
        /// Update customer's account data on account database and return number of row affected
        /// </summary>
        /// <param name="accountDataTable"></param>
        /// <returns></returns>
        public int UpdateAccount(DataTable accountDataTable)
        {
            SqlParameter tableParam = new SqlParameter("@UpdatedAccounts", accountDataTable);
            tableParam.SqlDbType = SqlDbType.Structured;
            tableParam.TypeName = "dbo.TBTYPE_TAIKHOAN";

            int rowAffected = DataProvider.Instance.ExecuteNonQuery("dbo.usp_UpdateCustomerAccounts", new SqlParameter[] { tableParam });
            return rowAffected;
        }
    }
}
