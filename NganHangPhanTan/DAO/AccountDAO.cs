using NganHangPhanTan.Util;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NganHangPhanTan.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private AccountDAO() { }

        /// <summary>
        /// Check if account id existed in all account database
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public bool ExistById(string accountId)
        {
            return (bool)DataProvider.Instance.ExecuteScalar($"SELECT dbo.udf_CheckAccountIdExisted('{accountId}')");
        }

        /// <summary>
        /// Check if account having any transaction
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public bool HavingAnyTransaction(string accountId)
        {
            return (bool)DataProvider.Instance.ExecuteScalar($"SELECT dbo.udf_CheckAccountHavingTransaction('{accountId}')");
        }

        /// <summary>
        /// Save a sending or withdrawal transaction for account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transTypeCode"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int AddSendWithdrawalTransaction(string accountId, string transTypeCode, double amount)
        {
            string employeeId = SecurityContext.User.Username;
            DateTime transDate = DateTime.Now;

            int rowAffected = DataProvider.Instance.ExecuteNonQuery(
                "EXEC usp_InsertTransSendWithdrawal @SOTK, @LOAIGD, @NGAYGD, @SOTIEN, @MANV",
                    new object[] { accountId, transTypeCode, transDate, amount, employeeId }
            );

            return rowAffected;
        }

        /// <summary>
        /// Save an exchange transaction for account
        /// </summary>
        /// <returns></returns>
        public int AddExchangeTransaction(string senderAccountId, DataTable bufferExchangeTransDataTable)
        {
            string employeeId = SecurityContext.User.Username;

            SqlParameter param0 = new SqlParameter("@SOTK_CHUYEN", senderAccountId);
            SqlParameter param1 = new SqlParameter("@NGAYGD", DateTime.Now);
            SqlParameter param2 = new SqlParameter("@MULTI_EXCHANGE_TABLE", bufferExchangeTransDataTable);
            param2.SqlDbType = SqlDbType.Structured;
            param2.TypeName = "dbo.TBTYPE_MultiExchangeTransaction";
            SqlParameter param3 = new SqlParameter("@MANV", employeeId);

            int rowAffected = DataProvider.Instance.ExecuteNonQuery(
                "dbo.usp_InsertTransExchange",
                new SqlParameter[] { param0, param1, param2, param3 }
            );

            return rowAffected;
        }

    }
}
