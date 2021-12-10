using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangPhanTan.DAO
{
    public class BrandDAO
    {
        private static BrandDAO uniqueInstance;

        public static BrandDAO UniqueInstance
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

        public string GetBrandIdOfSubcriber()
        {
            string query = "SELECT dbo.udf_GetBrandIDOfSubcriber()";
            return (string)DataProvider.UniqueInstance.ExecuteScalar(query);
        }
    }
}
