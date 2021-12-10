using System;
using System.Data;

namespace NganHangPhanTan.DTO
{
    public class Account
    {
        public static readonly string ID_HEADER = "SOTK";
        public static readonly string CUSTOMER_ID_HEADER = "CMND";
        public static readonly string BALANCE_HEADER = "SODU";
        public static readonly string BRAND_ID_HEADER = "MACN";
        public static readonly string OPEN_DATE_HEADER = "NGAYMOTK";

        private string id;
        private decimal balance;
        private string brandId;
        private DateTime openDate;

        public string Id { get => id; set => id = value; }
        public decimal Balance { get => balance; set => balance = value; }
        public string BrandId { get => brandId; set => brandId = value; }
        public DateTime OpenDate { get => openDate; set => openDate = value; }

        public Account(string id, string customerId, decimal balance, string brandId, DateTime openDate)
        {
            this.Id = id;
            this.Balance = balance;
            this.BrandId = brandId;
            this.OpenDate = openDate;
        }

        public Account(DataRowView row)
        {
            Id = (string)row[ID_HEADER];
            Balance = (decimal)row[BALANCE_HEADER];
            BrandId = (string)row[BRAND_ID_HEADER];
            OpenDate = (DateTime)row[OPEN_DATE_HEADER];
        }

        public override string ToString()
        {
            return "id: " + id + ", balance: " + balance + ", brandId: " + brandId + ", openDate: " + openDate;
        }
    }
}
