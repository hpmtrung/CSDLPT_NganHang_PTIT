using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangPhanTan.DTO
{
    public class User
    {
        public readonly static string GROUP_NAME_NGANHANG = "NganHang";
        public readonly static string GROUP_NAME_CHINHANH = "ChiNhanh";

        public enum GroupENM
        {
            NGAN_HANG,
            CHI_NHANH
        }

        private string username;
        private string login;
        private string pass;
        private int brandIndex;
        private GroupENM group;
        private string fullname;

        public User(string username, string login, string pass, int brandIndex, string group, string fullname)
        {
            this.username = username;
            this.login = login;
            this.pass = pass;
            this.brandIndex = brandIndex;
            this.fullname = fullname;
            SetGroup(group);
        }

        public User(DataRow row)
        {
            username = (string)row["USERNAME"];
            fullname = (string)row["HOTEN"];
            SetGroup((string)row["TENNHOM"]);
        }

        public User(SqlDataReader row)
        {
            username = (string)row["USERNAME"];
            fullname = (string)row["HOTEN"];
            SetGroup((string)row["TENNHOM"]);
        }

        public void SetGroup(string groupName)
        {
            if (groupName.Equals(GROUP_NAME_NGANHANG))
                this.Group = GroupENM.NGAN_HANG;
            else if (groupName.Equals(GROUP_NAME_CHINHANH))
                this.Group = GroupENM.CHI_NHANH;
            else
                throw new Exception("Group name param is illegal");
        }

        public string GetGroupName()
        {
            switch (this.group)
            {
                case GroupENM.NGAN_HANG:
                    return GROUP_NAME_NGANHANG;
                case GroupENM.CHI_NHANH:
                    return GROUP_NAME_CHINHANH;
                default:
                    throw new Exception();
            }
        }

        public string Username { get => username; set => username = value; }
        public string Login { get => login; set => login = value; }
        public int BrandIndex { get => brandIndex; set => brandIndex = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Pass { get => pass; set => pass = value; }
        public GroupENM Group { get => group; set => group = value; }
    }
}
