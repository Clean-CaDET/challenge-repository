using System.Collections.Generic;

namespace Naming._01._Basic_Naming
{
    /// <summary>
    /// 1. Identify and rename all the identifiers with poor names (excluding the namespace).
    /// </summary>
    class CourseService
    {
        public void Add(Course nc, Student s)
        {
            int i = 0;
            //Counts number of active courses
            foreach (var c in s.Courses)
            {
                if (c.Status.Equals("enrolled") || c.Status.Equals("current")) i++;
            }
            if (i < 6) //Check course limit
            {
                s.Courses.Add(nc);
            }
        }
    }

    internal class Course
    {
        public string Status { get; set; }
    }

    internal class Student
    {
        public List<Course> Courses { get; set; }
    }
}
