using System;
using System.Collections.Generic;

namespace Methods.Simple
{
    /// <summary>
    /// CHALLENGE ID: 44
    /// ** Do not modify the namespace name or the Run class name and its method headers. **
    /// 1. By looking at the comments, extract the appropriate methods.
    /// 2. Identify similar code in the new methods and reduce code duplication by extracting a shared method.
    /// 3. Ensure there are no syntax errors and that the Run class is aware of any renaming of the other classes and their members.
    /// </summary>
    class ScheduleService
    {
        internal bool IsAvailable(Doctor doctor, Operation operation)
        {
            //Check if doctor is on vacation.
            if (doctor.VacationSlots != null)
            {
                foreach (VacationSlot vacation in doctor.VacationSlots)
                {
                    DateTime vacationStart = vacation.StartTime;
                    DateTime vacationEnd = vacation.EndTime;

                    if (operation.StartTime > operation.EndTime) throw new InvalidOperationException("Invalid operation time frame.");
                    //---s1---| vacationStart |---e1---s2---e2---s3---| vacationEnd |---e3---
                    if (operation.StartTime <= vacationEnd && operation.EndTime >= vacationStart)
                    {
                        return false;
                    }
                }
            }

            //Check if doctor has operations at the time.
            if (doctor.Operations != null)
            {
                foreach (Operation op in doctor.Operations)
                {
                    DateTime opStart = op.StartTime;
                    DateTime opEnd = op.EndTime;

                    if (operation.StartTime > operation.EndTime) throw new InvalidOperationException("Invalid operation time frame.");
                    //---s1---| oldOpStart |---e1---s2---e2---s3---| oldOpEnd |---e3---
                    if (operation.StartTime <= opEnd && operation.EndTime >= opStart)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    class VacationSlot
    {
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public VacationSlot(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }

    class Operation
    {
        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public Operation(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }

    class Doctor
    {
        public List<Operation> Operations { get; }
        public List<VacationSlot> VacationSlots { get; }

        public Doctor()
        {
            Operations = new List<Operation>
            {
                new Operation(DateTime.Now.AddHours(2), DateTime.Now.AddHours(3)),
                new Operation(DateTime.Now.AddHours(5), DateTime.Now.AddHours(6))
            };
            VacationSlots = new List<VacationSlot>
            {
                new VacationSlot(DateTime.Now.AddDays(1), DateTime.Now.AddDays(3)),
                new VacationSlot(DateTime.Now.AddDays(5), DateTime.Now.AddDays(7))
            };
        }
    }

    #region Run
    public class Run
    {
        private readonly ScheduleService _service = new ScheduleService();

        public bool IsAvailable(DateTime begin, DateTime end)
        {
            return _service.IsAvailable(new Doctor(), new Operation(begin, end));
        }
    }
    #endregion
}
