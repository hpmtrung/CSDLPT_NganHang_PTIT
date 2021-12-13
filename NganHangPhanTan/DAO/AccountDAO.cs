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

        public bool ExistById(string accountId)
        {
            return (bool)DataProvider.Instance.ExecuteScalar($"SELECT dbo.udf_CheckAccountIdExisted('{accountId}')");
        }

        public bool CheckAccountExistedByPersonalId(string personalId)
        {
            return (bool)DataProvider.Instance.ExecuteScalar($"SELECT dbo.udf_CheckAccountExistedByPersonalId('{personalId}')");
        }
    }
}
