using NganHangPhanTan.DTO;

namespace NganHangPhanTan.Util
{
    public class SecurityContext
    {
        private static User user;

        public static User User { get => user; set => user = value; }

        public static void ClearUser()
        {
            user = null;
        }

        private SecurityContext() { }
    }
}
