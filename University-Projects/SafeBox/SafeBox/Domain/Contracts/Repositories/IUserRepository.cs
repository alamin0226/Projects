using SafeBox.Domain.Entities;
using System.Collections.Generic;

namespace SafeBox.Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        bool UsernameExists(string username);
        bool EmailExists(string email);

        int Insert(User user); // returns new user_id
        //User GetById(int userId);
        User GetByUsernameOrEmail(string usernameOrEmail);

        void UpdateLastLogin(int userId);

        void ActivateUser(int userId);
        void DeactivateUser(int userId);

        int GetActiveUserCount();
        int GetInactiveUserCount();
        int GetTotalUserCount();

        //Admin GetAdminByUsername(string username);

        //User GetByUsername(string username);
        //User GetByEmail(string email);
        //User GetById(int id);
        //void Add(User user);
        //void Update(User user);
        //void UpdateLastLogin(int userId);
        //bool UserExists(string username, string email);
        //IEnumerable<User> GetAll();
        //IEnumerable<User> Search(string searchTerm);
        //int GetTotalUserCount();
        //int GetActiveUserCount();
        //int GetInactiveUserCount();
        //void ActivateUser(int userId);
        //void DeactivateUser(int userId);
        //bool IsEmailTaken(string email, int excludeUserId);
        //IEnumerable<User> GetRecent(int count);
        //void UpdatePassword(int userId, byte[] passwordHash);
        //byte[] GetPasswordHash(int userId);
        //Admin GetAdminByUsername(string username);
    }
}
