using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SafeBox.DAL.Db;
using SafeBox.Domain.Entities;

namespace SafeBox.Infrastructure.Repositories
{
    public class VaultRepository : IVaultRepository
    {
        private readonly string _connectionString;

        public VaultRepository()
        {
            _connectionString = DbConfig.ConnectionString;
        }

        public int Insert(Vault vault)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = @"
                    INSERT INTO Vaults (user_id, vault_name, description, created_at)
                    VALUES (@userId, @name, @desc, @created);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userId", vault.UserId);
                    cmd.Parameters.AddWithValue("@name", vault.VaultName);
                    cmd.Parameters.AddWithValue("@desc", (object)vault.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@created", vault.CreatedAt);

                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    vault.VaultId = id;
                    return id;
                }
            }
        }

        public List<Vault> GetByUserId(int userId)
        {
            return GetVaultsByUser(userId);
        }

        public Vault GetById(int vaultId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = "SELECT * FROM Vaults WHERE vault_id = @vaultId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@vaultId", vaultId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Vault
                            {
                                VaultId = Convert.ToInt32(reader["vault_id"]),
                                UserId = Convert.ToInt32(reader["user_id"]),
                                VaultName = reader["vault_name"].ToString(),
                                Description = reader["description"] == DBNull.Value ? "" : reader["description"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int GetVaultCount(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = "SELECT COUNT(*) FROM Vaults WHERE user_id = @userId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public List<Vault> GetVaultsByUser(int userId)
        {
            var vaults = new List<Vault>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = "SELECT * FROM Vaults WHERE user_id = @userId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vaults.Add(new Vault
                            {
                                VaultId = Convert.ToInt32(reader["vault_id"]),
                                UserId = Convert.ToInt32(reader["user_id"]),
                                VaultName = reader["vault_name"].ToString(),
                                Description = reader["description"] == DBNull.Value ? "" : reader["description"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            });
                        }
                    }
                }
            }
            return vaults;
        }

        public void DeleteVault(int vaultId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = "DELETE FROM Vaults WHERE vault_id = @vaultId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@vaultId", vaultId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
