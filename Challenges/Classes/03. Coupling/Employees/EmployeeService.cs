using System;

namespace Classes.Coupling.Employees
{
	/// <summary>
    /// ID izazova je dostupan na web prikazu.
    /// 1. Refaktoriši kod tako da redukuješ snagu spregnutosti između EmployeeService i Employee klase.
	/// 2. Unapredi enkapsulaciju Employee klase.
    /// </summary>
    public class EmployeeService
    {
        void RetireEmployee(Employee e)
        {
            if (e.Status != EmploymentStatus.Active) throw new InvalidOperationException();
            e.Status = EmploymentStatus.Retired;
            e.DateOfRetirement = DateTime.Now;
            e.YearsWorked = e.DateOfRetirement.Year - e.EmploymentDate.Year;
        }
    }

    public class Employee
    {
        public EmploymentStatus Status { get; set; }
        public DateTime DateOfRetirement { get; set; }
        public int YearsWorked { get; set; }
        public DateTime EmploymentDate { get; set; }
        public object Name { get; internal set; }
        public object Surname { get; internal set; }
    }

    internal enum EmploymentStatus
    {
        Active,
        Retired
    }
}
