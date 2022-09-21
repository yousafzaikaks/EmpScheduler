namespace EmpSchedule.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Employees")]
    public partial class EmployeesDO
    {
        [Key]
        public int EmpId { get; set; }


        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
    }
    public partial class Employees : EmployeesDO
    {
        public Employees()
        {
            this.EmployeesShift = new List<EmployeesShift>();
        }

        public virtual ICollection<EmployeesShift> EmployeesShift { get; set; }
    }
}
