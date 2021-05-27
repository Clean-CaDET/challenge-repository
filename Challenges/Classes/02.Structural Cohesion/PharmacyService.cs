using System;
using System.Collections.Generic;

namespace Classes.Structural
{
    /// <summary>
    /// CHALLENGE ID: 52
    /// ** Do not modify the namespace name or the Run class name and its method headers. **
    /// ** Do not modify any constructor or the classes names. **
    /// 1. By looking at the comments, extract the appropriate methods.
    /// 2. Identify similar code in the new methods and reduce code duplication by extracting a shared method.
    /// 3. Ensure there are no syntax errors and that the Run class is aware of any renaming of the other classes and their members.
    /// </summary>
    class PharmacyService
    {
        internal bool IsWorking(Pharmacist pharmacist, Stocktake stocktake, Weekend weekend)
        {
            //Check if pharmacist is on vacation.
            if (pharmacist.VacationSlots != null)
            {
                foreach (VacationSlot vacation in pharmacist.VacationSlots)
                {
                    DateTime vacationStart = vacation.StartTime;
                    DateTime vacationEnd = vacation.EndTime;

                    if (stocktake.StartTime > stocktake.EndTime) throw new InvalidOperationException("Invalid stocktake time frame.");
                    //---s1---| vacationStart |---e1---s2---e2---s3---| vacationEnd |---e3---
                    if (stocktake.StartTime <= vacationEnd && stocktake.EndTime >= vacationStart)
                    {
                        return false;
                    }
                }
            }

            //Check if pharmacist is doing stocktakes at the time.
            if (pharmacist.Stocktakes != null)
            {
                foreach (Stocktake st in pharmacist.Operations)
                {
                    DateTime stStart = st.StartTime;
                    DateTime stEnd = st.EndTime;

                    if (stocktake.StartTime > stocktake.EndTime) throw new InvalidOperationException("Invalid stocktake time frame.");
                    //---s1---| oldStStart |---e1---s2---e2---s3---| oldStEnd |---e3---
                    if (stocktake.StartTime <= stEnd && stocktake.EndTime >= stStart)
                    {
                        return false;
                    }
                }
            }

            //Check if it is weekend.
            if (pharmacist.Weekends != null)
            {
                foreach (Weekend week in pharmacist.Weekends)
                {
                    DateTime weekendStart = week.StartTime;
                    DateTime weekendEnd = week.EndTime;

                    if (weekend.StartTime > weekend.EndTime) throw new InvalidOperationException("Invalid weekend time frame.");
                    //---s1---| weekendStart |---e1---s2---e2---s3---| weekendEnd |---e3---
                    if (weekend.StartTime <= weekendEnd && weekend.EndTime >= weekendStart)
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

    class Stocktake
    {
        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public Stocktake(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }

    class Weekend
    {
        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public Weekend(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }

    class Pharmacist
    {
        public List<Stocktake> Stocktakes { get; }
        public List<VacationSlot> VacationSlots { get; }
        public List<Weekend> Weekends { get; }

        public Pharmacist()
        {
            Stocktake = new List<Stocktake>
            {
                new Stocktake(DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)),
            };
            VacationSlots = new List<VacationSlot>
            {
                new VacationSlot(DateTime.Now.AddDays(3), DateTime.Now.AddDays(4)),
                new VacationSlot(DateTime.Now.AddDays(5), DateTime.Now.AddDays(9))
            };
            Weekends = new List<Weekend>
            {
                new Weekend(DateTime.Now.AddDays(10), DateTime.Now.AddDays(11)),
                new Weekend(DateTime.Now.AddDays(11), DateTime.Now.AddDays(12))
            };
        }
    }

    #region Run
    public class Run
    {
        private readonly PharmacyService _service = new PharmacyService();

        public bool IsWorking(DateTime begin, DateTime end)
        {
            return _service.IsWorking(new Pharmacist(), new Stocktake(begin, end));
        }
    }
    #endregion
}
