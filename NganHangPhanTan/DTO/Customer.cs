using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangPhanTan.DTO
{
    public class Customer
    {
        public static readonly string ID_HEADER = "CMND";
        public static readonly string FIRSTNAME_HEADER = "HO";
        public static readonly string LASTNAME_HEADER = "TEN";
        public static readonly string ADDRESS_HEADER = "DIACHI";
        public static readonly string DATE_ACCEPT_HEADER = "NGAYCAP";
        public static readonly string PHONENUM_HEADER = "SODT";

        private string id;
        private string lastName;
        private string firstName;
        private string address;
        private string gender;
        private DateTime dateAccept;
        private string phoneNum;

        public Customer(string id, string lastName, string firstName, string address, string gender, DateTime dateAccept, string phoneNum)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.address = address;
            this.gender = gender;
            this.dateAccept = dateAccept;
            this.phoneNum = phoneNum;
        }

        public Customer(DataRowView row)
        {
            this.id = (string)row[ID_HEADER];
            this.lastName = (string)row["HO"];
            this.firstName = (string)row["TEN"];
            this.address = (string)row["DIACHI"];
            this.gender = (string)row["PHAI"];
            this.dateAccept = (DateTime)row["NGAYCAP"];
            this.phoneNum = (string)row["SODT"];
        }

        public string Id { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Address { get => address; set => address = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime DateAccept { get => dateAccept; set => dateAccept = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
    }
}
