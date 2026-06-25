using SafeBox.DAL.Db;
using SafeBox.Domain.Contracts.Repositories;
using SafeBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Infrastructure.Repositories
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        public int Insert(ActivityLog log)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));

            const string sql = @"
                INSERT INTO ActivityLog (user_id, action, details)
                OUTPUT INSERTED.activity_id
                VALUES (@UserId, @Action, @Details);";

            using (var con = DbHelper.CreateConnection())
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add(DbHelper.P("@UserId", SqlDbType.Int, log.UserId));

                    // Action null হলে empty করে দিচ্ছি + Trim safe
                    string action = (log.Action ?? string.Empty).Trim();
                    cmd.Parameters.Add(DbHelper.P("@Action", SqlDbType.NVarChar, action, 50));

                    // Details nullable হতে পারে
                    object detailsValue = (object)log.Details ?? DBNull.Value;
                    cmd.Parameters.Add(DbHelper.P("@Details", SqlDbType.NVarChar, detailsValue, 500));

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public List<ActivityLog> GetByUserId(int userId)
        {
            const string sql = @"
                SELECT activity_id, user_id, action, details, timestamp
                FROM ActivityLog
                WHERE user_id = @UserId
                ORDER BY timestamp DESC;";

            var list = new List<ActivityLog>();

            using (var con = DbHelper.CreateConnection())
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add(DbHelper.P("@UserId", SqlDbType.Int, userId));

                    con.Open();

                    using (var r = cmd.ExecuteReader())
                    {
                        int ordActivityId = r.GetOrdinal("activity_id");
                        int ordUserId = r.GetOrdinal("user_id");
                        int ordAction = r.GetOrdinal("action");
                        int ordDetails = r.GetOrdinal("details");
                        int ordTimestamp = r.GetOrdinal("timestamp");

                        while (r.Read())
                        {
                            list.Add(new ActivityLog
                            {
                                ActivityId = r.GetInt32(ordActivityId),
                                UserId = r.GetInt32(ordUserId),
                                Action = r.GetString(ordAction),
                                Details = r.IsDBNull(ordDetails) ? null : r.GetString(ordDetails),
                                Timestamp = r.GetDateTime(ordTimestamp)
                            });
                        }
                    }
                }
            }

            return list;
        }
        public void LogActivity(int userId, string action, string description)
        {
            Insert(new ActivityLog
            {
                UserId = userId,
                Action = action,
                Details = description,
                Timestamp = DateTime.Now
            });
        }

        public IEnumerable<ActivityLog> GetRecentActivities(int userId, int count = 10)
        {
            const string sql = @"
                SELECT TOP (@Count) activity_id, user_id, action, details, timestamp
                FROM ActivityLog
                WHERE user_id = @UserId
                ORDER BY timestamp DESC;";

            var list = new List<ActivityLog>();

            using (var con = DAL.Db.DbHelper.CreateConnection())
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add(DAL.Db.DbHelper.P("@UserId", SqlDbType.Int, userId));
                    cmd.Parameters.Add(DAL.Db.DbHelper.P("@Count", SqlDbType.Int, count));

                    con.Open();

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new ActivityLog
                            {
                                ActivityId = r.GetInt32(r.GetOrdinal("activity_id")),
                                UserId = r.GetInt32(r.GetOrdinal("user_id")),
                                Action = r.GetString(r.GetOrdinal("action")),
                                Details = r.IsDBNull(r.GetOrdinal("details")) ? null : r.GetString(r.GetOrdinal("details")),
                                Timestamp = r.GetDateTime(r.GetOrdinal("timestamp"))
                            });
                        }
                    }
                }
            }

            return list;
        }

        public IEnumerable<ActivityLog> GetAllActivities(int userId)
        {
            return GetByUserId(userId);
        }
    }
}
