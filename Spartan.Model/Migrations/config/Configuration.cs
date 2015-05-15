using System.Data.Entity.Migrations;
using MySql.Data.Entity;
using Spartan.Model.DbContext;

namespace Spartan.Model.Migrations.config
{

    public sealed class Configuration : DbMigrationsConfiguration<SpartanDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());    // This will add our MySQLClient as SQL Generator
        }

        protected override void Seed(SpartanDB context)
        {
           
        }

    }
}
