using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EmpSchedule.Model
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EmployeesShift> EmployeesShift { get; set; }

    }
}
