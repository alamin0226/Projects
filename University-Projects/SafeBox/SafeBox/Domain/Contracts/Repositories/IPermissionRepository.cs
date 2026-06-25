using SafeBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.Contracts.Repositories
{
    internal interface IPermissionRepository
    {
        List<Permission> GetAll();
        Permission GetById(int permissionId);
        Permission GetByName(string permissionName);
    }
}
