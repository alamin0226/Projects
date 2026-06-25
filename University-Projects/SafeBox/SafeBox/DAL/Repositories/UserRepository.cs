using SafeBox.Domain.Contracts.Repositories;
using SafeBox.Domain.Entities;
using SafeBox.Infrastructure.Data;
using System;
using System.Data.SqlClient;

namespace SafeBox.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository()
        {
            _connectionString = DatabaseHelper.ConnectionString;
        }

        public bool UsernameExists(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    const string query = "SELECT COUNT(*) FROM Users WHERE user_username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking UsernameExists: {ex.Message}", ex);
            }
        }

        public bool EmailExists(string email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    const string query = "SELECT COUNT(*) FROM Users WHERE email = @email";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking EmailExists: {ex.Message}", ex);
            }
        }

        public int Insert(User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    const string query = @"
                        INSERT INTO Users (user_username, email, password_hash)
                        VALUES (@username, @email, @passwordHash);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", user.Username);
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);

                        int newId = Convert.ToInt32(cmd.ExecuteScalar());
                        user.UserId = newId;
                        return newId;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting user: {ex.Message}", ex);
            }
        }

        public User GetByUsernameOrEmail(string usernameOrEmail)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    const string query = @"
                        SELECT user_id, user_username, email, password_hash, status, created_at, update_last_login
                        FROM Users
                        WHERE user_username = @value OR email = @value
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@value", usernameOrEmail);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    UserId = Convert.ToInt32(reader["user_id"]),
                                    Username = reader["user_username"].ToString(),
                                    Email = reader["email"].ToString(),
                                    PasswordHash = reader["password_hash"].ToString(),
                                    Status = reader["status"] == DBNull.Value ? "0" : reader["status"].ToString(),
                                    CreatedAt = reader["created_at"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["created_at"]),
                                    UpdateLastLogin = reader["update_last_login"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["update_last_login"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving user: {ex.Message}", ex);
            }

            return null;
        }

        public void UpdateLastLogin(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    const string query = "UPDATE Users SET update_last_login = SYSDATETIME() WHERE user_id = @userId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating last login: {ex.Message}", ex);
            }
        }

        // status NVARCHAR -> use '1' active, '0' inactive
        public void ActivateUser(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    const string query = "UPDATE Users SET status = '1' WHERE user_id = @userId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error activating user: {ex.Message}", ex);
            }
        }

        public void DeactivateUser(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    const string query = "UPDATE Users SET status = '0' WHERE user_id = @userId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deactivating user: {ex.Message}", ex);
            }
        }

        public int GetActiveUserCount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    const string query = "SELECT COUNT(*) FROM Users WHERE status = '1'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                        return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {
                return 0;
            }
        }

        public int GetInactiveUserCount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    const string query = "SELECT COUNT(*) FROM Users WHERE status = '0'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                        return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {
                return 0;
            }
        }

        public int GetTotalUserCount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    const string query = "SELECT COUNT(*) FROM Users";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                        return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {
                return 0;
            }
        }

        public Admin GetAdminByUsername(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    const string query = @"
                        SELECT admin_id, admin_username, email, password_hash, status, created_at, last_login
                        FROM Admin
                        WHERE admin_username = @username
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // status NVARCHAR('1'/'0') -> bool
                                bool isActive = reader["status"] != DBNull.Value && reader["status"].ToString() == "1";

                                return new Admin
                                {
                                    AdminId = Convert.ToInt32(reader["admin_id"]),
                                    AdminUsername = reader["admin_username"].ToString(),
                                    Email = reader["email"].ToString(),
                                    PasswordHash = reader["password_hash"].ToString(),
                                    Status = isActive,
                                    CreatedAt = reader["created_at"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["created_at"]),
                                    UpdateLastLogin = reader["update_last_login"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["update_last_login"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving admin: {ex.Message}", ex);
            }

            return null;
        }
    }
}
