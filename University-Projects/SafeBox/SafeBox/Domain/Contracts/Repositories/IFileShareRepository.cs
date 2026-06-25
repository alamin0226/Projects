using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.Domain.Contracts.Repositories
{
    public interface IFileShareRepository
    {
        int Insert(FileShare share);
        List<FileShare> GetSharesForUser(int userId);
        FileShare? GetById(int shareId);
    }
}
