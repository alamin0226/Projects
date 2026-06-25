using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBox.DAL.Db
{
    public static class DbConfig
    {
        // UI/App.config থেকে সেট করলে আরও ভালো
        public static string ConnectionString { get; set; } =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SafeBox;Integrated Security=True;Trust Server Certificate=True;";
    }
}
