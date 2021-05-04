using System;
using System.Collections.Generic;

namespace Methods.Simple
{
    /// <summary>
    /// ** Do not modify the namespace name or the Run class name and Main method header. **
    /// 1) By looking at the comments, extract the appropriate methods.
    /// 2) Identify similar code in the new methods and reduce code duplication by extracting a shared method.
    /// </summary>
    class ScheduleService
    {
        bool IsAvailable(Doctor doctor, Operation operation)
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
    }

    class Operation
    {
        public DateTime StartTime { get; }

        public DateTime EndTime { get; }
    }

    class Doctor
    {
        public List<Operation> Operations { get; }
        public List<VacationSlot> VacationSlots { get; }
    }
}
