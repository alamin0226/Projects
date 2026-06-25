using SafeBox.Domain.Entities;
using System.Collections.Generic;

namespace SafeBox.Application.Interfaces
{
    public interface IActivityService
    {
        IEnumerable<ActivityLog> GetRecentActivities(int userId, int count);
        void LogActivity(int userId, string action, string description);
    }
}
