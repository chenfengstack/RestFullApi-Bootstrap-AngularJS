using System.Data.Entity;
using Spartan.Model.Models;

namespace Spartan.Model.DbContext
{
    public class SpartanDB : System.Data.Entity.DbContext
    {
        public SpartanDB() :
            base("db")
        {
            
        }
        public DbSet<News> News { get; set; }

        public DbSet<NewType> NewTypes { get; set; }
    }
}