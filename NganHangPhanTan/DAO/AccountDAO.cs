namespace NganHangPhanTan.DAO
{
    public class AccountDAO
    {
        private static AccountDAO uniqueInstance;

        public static AccountDAO UniqueInstance
        {
            get
            {
                if (uniqueInstance == null)
                    uniqueInstance = new AccountDAO();
                return uniqueInstance;
            }
            private set { uniqueInstance = value; }
        }

        private AccountDAO() { }

        public bool IsAccountIdExisted(string accountId)
        {
            return (bool)DataProvider.UniqueInstance.ExecuteScalar($"SELECT dbo.udf_CheckAccountIdExisted(N'{accountId}')");
        }
    }
}
