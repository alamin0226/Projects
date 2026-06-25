using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly string _connectionString;

        public AdminRepository()
        {
            _connectionString = DAL.Db.DbConfig.ConnectionString;
        }

        public bool UsernameExists(string username)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = "SELECT COUNT(*) FROM Admin WHERE admin_username = @username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public bool EmailExists(string email)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = "SELECT COUNT(*) FROM Admin WHERE email = @email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public int Insert(Admin admin)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = @"
                    INSERT INTO Admin (admin_username, email, password_hash, status, created_at, last_login)
                    VALUES (@username, @email, @hash, @status, @created, @login);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", admin.AdminUsername);
                    cmd.Parameters.AddWithValue("@email", admin.Email);
                    cmd.Parameters.AddWithValue("@hash", admin.PasswordHash);
                    cmd.Parameters.AddWithValue("@status", admin.Status ? "1" : "0");
                    cmd.Parameters.AddWithValue("@created", admin.CreatedAt);
                    cmd.Parameters.AddWithValue("@login", admin.UpdateLastLogin);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public Admin GetByUsernameOrEmail(string usernameOrEmail)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = @"
                    SELECT * FROM Admin 
                    WHERE admin_username = @val OR email = @val";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@val", usernameOrEmail);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            return new Admin
                            {
                                AdminId = Convert.ToInt32(r["admin_id"]),
                                AdminUsername = r["admin_username"].ToString(),
                                Email = r["email"].ToString(),
                                PasswordHash = r["password_hash"].ToString(),
                                Status = r["status"] != DBNull.Value && (r["status"].ToString() == "1" || r["status"].ToString().ToLower() == "true"),
                                CreatedAt = Convert.ToDateTime(r["created_at"]),
                                UpdateLastLogin = r["last_login"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(r["last_login"])
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
