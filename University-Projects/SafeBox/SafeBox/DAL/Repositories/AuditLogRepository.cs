using SafeBox.DAL.Db;
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
    public class AuditLogRepository
    {
        public int Insert(AuditLog log)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));

            const string sql = @"
                INSERT INTO AuditLog (user_id, admin_id, action, details)
                OUTPUT INSERTED.audit_id
                VALUES (@UserId, @AdminId, @Action, @Details);";

            using (var con = DbHelper.CreateConnection())
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    // user_id nullable হলে DBNull.Value
                    object userIdValue = log.UserId.HasValue ? (object)log.UserId.Value : DBNull.Value;
                    cmd.Parameters.Add(DbHelper.P("@UserId", SqlDbType.Int, userIdValue));

                    // admin_id nullable হলে DBNull.Value
                    object adminIdValue = log.AdminId.HasValue ? (object)log.AdminId.Value : DBNull.Value;
                    cmd.Parameters.Add(DbHelper.P("@AdminId", SqlDbType.Int, adminIdValue));

                    // Action null হলে empty + Trim safe
                    string action = (log.Action ?? string.Empty).Trim();
                    cmd.Parameters.Add(DbHelper.P("@Action", SqlDbType.NVarChar, action, 60));

                    // Details nullable হলে DBNull.Value
                    object detailsValue = (object)log.Details ?? DBNull.Value;
                    cmd.Parameters.Add(DbHelper.P("@Details", SqlDbType.NVarChar, detailsValue, 800));

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public List<AuditLog> GetLatest(int take)
        {
            const string sql = @"
                SELECT TOP (@Take) audit_id, user_id, admin_id, action, details, timestamp
                FROM AuditLog
                ORDER BY timestamp DESC;";

            var list = new List<AuditLog>();

            using (var con = DbHelper.CreateConnection())
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add(DbHelper.P("@Take", SqlDbType.Int, take));

                    con.Open();

                    using (var r = cmd.ExecuteReader())
                    {
                        int ordAuditId = r.GetOrdinal("audit_id");
                        int ordUserId = r.GetOrdinal("user_id");
                        int ordAdminId = r.GetOrdinal("admin_id");
                        int ordAction = r.GetOrdinal("action");
                        int ordDetails = r.GetOrdinal("details");
                        int ordTimestamp = r.GetOrdinal("timestamp");

                        while (r.Read())
                        {
                            list.Add(new AuditLog
                            {
                                AuditId = r.GetInt32(ordAuditId),
                                UserId = r.IsDBNull(ordUserId) ? (int?)null : r.GetInt32(ordUserId),
                                AdminId = r.IsDBNull(ordAdminId) ? (int?)null : r.GetInt32(ordAdminId),
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
    }
}
