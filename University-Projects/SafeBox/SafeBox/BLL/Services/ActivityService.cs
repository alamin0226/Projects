using SafeBox.Application.Interfaces;
using SafeBox.Domain.Entities;
using SafeBox.Domain.Contracts.Repositories;
using System.Collections.Generic;

namespace SafeBox.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityLogRepository _repo;

        public ActivityService()
        {
            // Poor man's DI for UI
            _repo = new Infrastructure.Repositories.ActivityLogRepository();
        }

        public ActivityService(IActivityLogRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ActivityLog> GetRecentActivities(int userId, int count)
        {
            return _repo.GetRecentActivities(userId, count);
        }

        public void LogActivity(int userId, string action, string description)
        {
            _repo.LogActivity(userId, action, description);
        }
    }
}
