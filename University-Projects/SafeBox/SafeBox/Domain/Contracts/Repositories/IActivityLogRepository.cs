using SafeBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.Contracts.Repositories
{
    public interface IActivityLogRepository
    {
      
        void LogActivity(int userId, string action, string description);
        IEnumerable<ActivityLog> GetRecentActivities(int userId, int count = 10);
        IEnumerable<ActivityLog> GetAllActivities(int userId);
    }
}
