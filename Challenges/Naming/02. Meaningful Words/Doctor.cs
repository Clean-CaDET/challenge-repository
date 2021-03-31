using System;
using System.Collections.Generic;

namespace Naming._02._Meaningful_Words
{
    /// <summary>
    /// 1. Identify all the names that contain meaningless words.
    /// 2. Use the refactoring tool supported by your IDE to rename these identifiers into something meaningful.
    /// </summary>
    class DoctorInfo
    {
        private int _doctorId;
        private ISet<Specialization> _specializations;

        public bool HasSpecializations(ISet<Specialization> specializationSet)
        {
            foreach (var specialization in specializationSet)
            {
                if (!_specializations.Contains(specialization)) return false;
            }

            return true;
        }

        public void AssignSpecialization(Specialization specializationData)
        {
            if (_specializations.Contains(specializationData)) throw new TheDoctorAlreadyHasSpecializationException("Doctor: " + _doctorId.ToString() + "Spec: " + specializationData);
            _specializations.Add(specializationData);
        }

    }

    internal class TheDoctorAlreadyHasSpecializationException : Exception
    {
        public TheDoctorAlreadyHasSpecializationException(string doctorId) : base(doctorId)
        {
        }
    }

    internal class Specialization
    {
        private string _nameStr;
    }
}
