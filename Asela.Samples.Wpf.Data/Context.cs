using Asela.Samples.Wpf.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asela.Samples.Wpf.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=SampleConnectionString")
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
