using System.Collections.Generic;

namespace Naming._02._Meaningful_Words
{
    /// <summary>
    /// 1. Identify and rename all the identifiers with poor names.
	/// 2. Identify any literals in the code and find a way to make their purpose clear.
	/// 3. Identify at least one piece of logic whose intent is not clear and extract it into a method with a meaningful name.
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
