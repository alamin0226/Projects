using SafeBox.Domain.Entities;

namespace SafeBox.Presentation
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }
        public static Admin CurrentAdmin { get; set; }
        public static int CurrentUserId => CurrentUser?.UserId ?? 0;
    }
}
