using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.DAL.Db
{
    public class DbHelper
    {
        internal static SqlConnection CreateConnection()
            => new SqlConnection(DbConfig.ConnectionString);

        internal static SqlParameter P(string name, SqlDbType type, object value, int? size = null)
        {
            var p = new SqlParameter(name, type);
            if (size.HasValue) p.Size = size.Value;
            p.Value = value ?? DBNull.Value;
            return p;
        }
    }
}
