using SafeBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.Contracts.Repositories
{
    public interface IAdminRepository
    {
        bool UsernameExists(string username);
        bool EmailExists(string email);

        int Insert(Admin admin);
        Admin GetByUsernameOrEmail(string usernameOrEmail);
    }
}
