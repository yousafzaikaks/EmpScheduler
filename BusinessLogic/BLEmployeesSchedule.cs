using EmpSchedule.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpSchedule.BusinessLogic
{
    public class BLEmployeesSchedule
    {
        public int ShiftId { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan ShiftFrom { get; set; }
        public TimeSpan ShiftTo { get; set; }
        public string ShiftType { get; set; }

        public static List<BLEmployeesSchedule> GetEmployeeShifts()
        {
            try
            {
                var ctx = new DBContext();
                return ctx.EmployeesShift.Select(x => new BLEmployeesSchedule()
                {
                    ShiftId = x.ShiftId,
                    EmpId = x.Employees.EmpId,
                    EmpName = x.Employees.LastName + ", " + x.Employees.FirstName,
                    ShiftDate = x.ShiftDate,
                    ShiftFrom = x.ShiftFrom,
                    ShiftTo = x.ShiftTo,
                    ShiftType = x.ShiftType,
                }).ToList();
            }
            catch (Exception ex)
            {
                return new List<BLEmployeesSchedule>();
            }
        }

        public static List<BLEmployeesSchedule> GetPlanShifts()
        {
            var shifts = GetEmployeeShifts();
            foreach (var empShift in shifts.GroupBy(x => x.EmpId))
            {
                var shift = empShift.Where(x => x.ShiftType == "Chat Shift").FirstOrDefault();
                //checking for exceeding limits of slots
                foreach (var con in shifts)
                {
                    if (con.ShiftFrom < shift.ShiftFrom)
                    {
                        con.ShiftFrom = shift.ShiftFrom;
                    }
                    if (con.ShiftTo > shift.ShiftTo)
                    {
                        con.ShiftTo = shift.ShiftTo;
                    }
                }
            }
            return shifts;
        }
        public static List<ShiftSlots> GetEmployeesSchedule()
        {
            try
            {
                var shiftSlots = new List<ShiftSlots>();
                var singleSlot = new ShiftSlots();
                TimeSpan LastTo = new TimeSpan();
                int counter = 0;
                var shifts = GetPlanShifts();

                foreach (var empShift in shifts.GroupBy(x => x.EmpId))
                {
                    counter = 0;
                    var shift = empShift.Where(x => x.ShiftType == "Chat Shift").FirstOrDefault();
                    
                    //check for a full day leave


                    foreach (var item in empShift.Where(x => x.ShiftType != "Chat Shift").OrderBy(x=> x.ShiftFrom))
                    {
                        if (counter == 0)
                        {
                            singleSlot = new ShiftSlots();
                            singleSlot.EmpId = item.EmpId;
                            singleSlot.EmpName = item.EmpName;
                            singleSlot.SlotName = "Chat Shift";
                            singleSlot.SlotFrom = shift.ShiftFrom;
                            singleSlot.SlotTo = item.ShiftFrom;
                            singleSlot.ShiftDate = item.ShiftDate;
                            if (singleSlot.SlotFrom != singleSlot.SlotTo)
                            {
                                shiftSlots.Add(singleSlot);
                            }


                            singleSlot = new ShiftSlots();
                            singleSlot.EmpId = item.EmpId;
                            singleSlot.EmpName = item.EmpName;
                            singleSlot.SlotName = item.ShiftType;
                            singleSlot.SlotFrom = item.ShiftFrom;
                            singleSlot.SlotTo = item.ShiftTo;
                            singleSlot.ShiftDate = item.ShiftDate;
                            if (singleSlot.SlotFrom != singleSlot.SlotTo)
                            {
                                shiftSlots.Add(singleSlot);
                            }
                            LastTo = singleSlot.SlotTo;

                            if (LastTo < shift.ShiftTo && counter == (empShift.Count() - 2))
                            {
                                singleSlot = new ShiftSlots();
                                singleSlot.EmpId = item.EmpId;
                                singleSlot.EmpName = item.EmpName;
                                singleSlot.SlotName = "Chat Shift";
                                singleSlot.SlotFrom = LastTo;
                                singleSlot.SlotTo = shift.ShiftTo;
                                singleSlot.ShiftDate = item.ShiftDate;
                                shiftSlots.Add(singleSlot);
                                LastTo = singleSlot.SlotTo;
                            }
                        }
                        else
                        {
                            singleSlot = new ShiftSlots();
                            singleSlot.EmpId = item.EmpId;
                            singleSlot.EmpName = item.EmpName;
                            singleSlot.SlotName = "Chat Shift";
                            singleSlot.SlotFrom = LastTo;
                            singleSlot.SlotTo = item.ShiftFrom;
                            singleSlot.ShiftDate = item.ShiftDate;
                            if (singleSlot.SlotFrom != singleSlot.SlotTo)
                            {
                                shiftSlots.Add(singleSlot);
                            }


                            singleSlot = new ShiftSlots();
                            singleSlot.EmpId = item.EmpId;
                            singleSlot.EmpName = item.EmpName;
                            singleSlot.SlotName = item.ShiftType;
                            singleSlot.SlotFrom = item.ShiftFrom;
                            singleSlot.SlotTo = item.ShiftTo;
                            singleSlot.ShiftDate = item.ShiftDate;
                            if (singleSlot.SlotFrom != singleSlot.SlotTo)
                            {
                                shiftSlots.Add(singleSlot);
                            }
                            
                            LastTo = singleSlot.SlotTo;

                            if (LastTo < shift.ShiftTo && counter == (empShift.Count() - 2))
                            {
                                singleSlot = new ShiftSlots();
                                singleSlot.EmpId = item.EmpId;
                                singleSlot.EmpName = item.EmpName;
                                singleSlot.SlotName = "Chat Shift";
                                singleSlot.SlotFrom = LastTo;
                                singleSlot.SlotTo = shift.ShiftTo;
                                singleSlot.ShiftDate = item.ShiftDate;
                                if (singleSlot.SlotFrom != singleSlot.SlotTo)
                                {
                                    shiftSlots.Add(singleSlot);
                                }
                                LastTo = singleSlot.SlotTo;
                            }
                        }
                        counter++;
                    }
                }
                return shiftSlots;
            }
            catch (Exception ex)
            {
                return new List<ShiftSlots>();
            }
        }

        public static ShiftSlots AddSlots(BLEmployeesSchedule slot)
        {
            var singleSlot = new ShiftSlots();
            singleSlot.EmpId = slot.EmpId;
            singleSlot.SlotName = "Chat Shift";
            singleSlot.SlotFrom = slot.ShiftFrom;
            singleSlot.SlotTo = slot.ShiftFrom;
            singleSlot.ShiftDate = slot.ShiftDate;
            return singleSlot;
        }
    }
    public partial class ShiftSlots
    {
        public int EmpId { get; set; }

        [Display(Name = "Employee Name")]
        public string EmpName { get; set; }

        [Display(Name = "Shift Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, MMMM d, yyy}")]
        public DateTime ShiftDate { get; set; }

        [Display(Name = "Slot Name")]
        public string SlotName { get; set; }

        [Display(Name = "Slot From")]
        public TimeSpan SlotFrom { get; set; }
        
        [Display(Name = "Slot To")]
        public TimeSpan SlotTo { get; set; }
    }

}