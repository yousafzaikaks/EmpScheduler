namespace EmpSchedule.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EmployeesShift")]
    public partial class EmployeesShiftDO
    {
        [Key]
        public int ShiftId { get; set; }
        
        public int EmpId { get; set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan ShiftFrom { get; set; }
        public TimeSpan ShiftTo { get; set; }
        public string ShiftType { get; set; }
    }
    public partial class EmployeesShift : EmployeesShiftDO
    {
        public EmployeesShift()
        {
        }
        public virtual Employees Employees { get; set; }
    }
}
