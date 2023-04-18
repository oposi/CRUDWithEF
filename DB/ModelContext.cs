using System.Data.Entity;

namespace CRUDWithEF
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base ("name=con") { }

        public DbSet<Employee> EmpList { get; set;}
    }
}
