using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangPhanTan.DTO
{
    public class Employee
    {
        public readonly static string ID_HEADER = "MANV";
        public readonly static string LASTNAME_HEADER = "HO";
        public readonly static string FIRSTNAME_HEADER = "TEN";
        public readonly static string ADDRESS_HEADER = "DIACHI";
        public readonly static string GENDER_HEADER = "PHAI";
        public readonly static string PHONENUM_HEADER = "SODT";

        private string id;
        private string lastName;
        private string firstName;
        private string address;
        private string gender;
        private string phoneNum;

        public Employee() { }

        public Employee(string id, string lastName, string firstName, string address, string gender, string phoneNum)
        {
            this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Address = address;
            this.Gender = gender;
            this.PhoneNum = phoneNum;
        }

        public Employee(DataRowView row)
        {
            id = (string)row[ID_HEADER];
            lastName = (string)row[LASTNAME_HEADER];
            firstName = (string)row[FIRSTNAME_HEADER];
            address = (string)row[ADDRESS_HEADER];
            gender = (string)row[GENDER_HEADER];
            phoneNum = (string)row[PHONENUM_HEADER];
        }

        public string Id { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Address { get => address; set => address = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
    }
}
