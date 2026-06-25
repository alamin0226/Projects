using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SafeBox.DAL.Db;
using SafeBox.Domain.Entities;

namespace SafeBox.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly string _connectionString;

        public FileRepository()
        {
            _connectionString = DAL.Db.DbConfig.ConnectionString;
        }

        public int Insert(FileEntity file)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = @"
                    INSERT INTO Files (vault_id, user_id, file_name, file_path, file_size, is_encrypted, uploaded_at)
                    VALUES (@vaultId, @userId, @name, @path, @size, @encrypted, @uploaded);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@vaultId", file.VaultId);
                    cmd.Parameters.AddWithValue("@userId", file.UserId);
                    cmd.Parameters.AddWithValue("@name", file.FileName);
                    cmd.Parameters.AddWithValue("@path", file.FilePath);
                    cmd.Parameters.AddWithValue("@size", file.FileSize);
                    cmd.Parameters.AddWithValue("@encrypted", file.IsEncrypted);
                    cmd.Parameters.AddWithValue("@uploaded", file.UploadedAt);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public FileEntity GetById(int fileId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = "SELECT * FROM Files WHERE file_id = @fileId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@fileId", fileId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new FileEntity
                            {
                                FileId = Convert.ToInt32(reader["file_id"]),
                                VaultId = Convert.ToInt32(reader["vault_id"]),
                                UserId = Convert.ToInt32(reader["user_id"]),
                                FileName = reader["file_name"].ToString(),
                                FilePath = reader["file_path"].ToString(),
                                FileSize = Convert.ToInt64(reader["file_size"]),
                                IsEncrypted = Convert.ToBoolean(reader["is_encrypted"]),
                                UploadedAt = Convert.ToDateTime(reader["uploaded_at"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<FileEntity> GetByVaultId(int vaultId)
        {
            var files = new List<FileEntity>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = "SELECT * FROM Files WHERE vault_id = @vaultId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@vaultId", vaultId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            files.Add(new FileEntity
                            {
                                FileId = Convert.ToInt32(reader["file_id"]),
                                VaultId = Convert.ToInt32(reader["vault_id"]),
                                UserId = Convert.ToInt32(reader["user_id"]),
                                FileName = reader["file_name"].ToString(),
                                FilePath = reader["file_path"].ToString(),
                                FileSize = Convert.ToInt64(reader["file_size"]),
                                IsEncrypted = Convert.ToBoolean(reader["is_encrypted"]),
                                UploadedAt = Convert.ToDateTime(reader["uploaded_at"])
                            });
                        }
                    }
                }
            }
            return files;
        }

        public void DeleteFile(int fileId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = "DELETE FROM Files WHERE file_id = @fileId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@fileId", fileId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public long GetTotalStorageSize(int userId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                const string query = "SELECT SUM(file_size) FROM Files WHERE user_id = @userId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    object result = cmd.ExecuteScalar();
                    return result == DBNull.Value ? 0 : Convert.ToInt64(result);
                }
            }
        }
    }
}
