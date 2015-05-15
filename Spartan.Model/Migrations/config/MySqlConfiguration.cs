using System.Data.Entity;
using Spartan.Model.Migrations.config;

namespace HTTZ.Model.Migrations
{
    public class MySqlConfiguration : DbConfiguration
    {
        public MySqlConfiguration()
        {
            SetHistoryContext("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
        }
    }

}
