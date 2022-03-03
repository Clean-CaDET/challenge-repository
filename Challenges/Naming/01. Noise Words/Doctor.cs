using System;
using System.Collections.Generic;
using System.Linq;

namespace Naming.Noise
{
    /// <summary>
    /// CHALLENGE ID: TODO
    /// ** Nemoj da modifikuješ naziv namespace-a, Run klase i zaglavlja metoda ove klase. **
    /// 1. Odredi sve nazive koji sadrže generične ili beznačajne reči.
    /// 2. Ukloni ove reči ili ih promeni u nešto značajnije.
    /// 3. Potvrdi da nema sintaksnih grešaka i da je Run klasa ispratila bilo kakva preimenovanja klasa i metoda koje koristi.
    /// </summary>
    public class DoctorInfo
    {
        public int DoctorId { get; }
        public ISet<Specialization> Specializations { get; } = new HashSet<Specialization>();

        public bool HasSpecializations(List<Specialization> specializationSet)
        {
            foreach (var specialization in specializationSet)
            {
                if (!Specializations.Contains(specialization)) return false;
            }

            return true;
        }

        public void AssignSpecialization(Specialization specializationData)
        {
            if (Specializations.Contains(specializationData)) throw new TheDoctorAlreadyHasSpecializationException("Doctor: " + DoctorId.ToString() + "Spec: " + specializationData);
            Specializations.Add(specializationData);
        }

    }

    public class TheDoctorAlreadyHasSpecializationException : Exception
    {
        public TheDoctorAlreadyHasSpecializationException(string doctorId) : base(doctorId)
        {
        }
    }

    public class Specialization
    {
        private readonly string _nameStr;

        public Specialization(string name)
        {
            _nameStr = name;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Specialization other)) return false;
            return other._nameStr.Equals(_nameStr);
        }

        public override int GetHashCode()
        {
            return _nameStr.GetHashCode();
        }
    }

    #region Run
    public class Run
    {
        private readonly DoctorInfo _doctor;

        public Run()
        {
            _doctor = new DoctorInfo();
            _doctor.AssignSpecialization(new Specialization("Test 1"));
            _doctor.AssignSpecialization(new Specialization("Test 2"));
            _doctor.AssignSpecialization(new Specialization("Test 3"));
        }

        public void AddSpec()
        {
            _doctor.AssignSpecialization(new Specialization("Test 1"));
        }

        public List<Specialization> GetSpec()
        {
            return _doctor.Specializations.ToList();
        }

        public bool HasSpec(List<Specialization> all)
        {
            return _doctor.HasSpecializations(all);
        }
    }
    #endregion
}
