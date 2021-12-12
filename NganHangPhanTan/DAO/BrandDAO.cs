namespace NganHangPhanTan.DAO
{
    public class BrandDAO
    {
        private static BrandDAO uniqueInstance;

        public static BrandDAO Instance
        {
            get
            {
                if (uniqueInstance == null)
                    uniqueInstance = new BrandDAO();
                return uniqueInstance;
            }
            private set { uniqueInstance = value; }
        }

        private BrandDAO() { }

        /// <summary>
        /// Get Id of current brand having connection
        /// </summary>
        /// <returns></returns>
        public string GetBrandIdOfSubcriber()
        {
            string query = "SELECT dbo.udf_GetBrandIDOfSubcriber()";
            return (string)DataProvider.Instance.ExecuteScalar(query);
        }
    }
}
