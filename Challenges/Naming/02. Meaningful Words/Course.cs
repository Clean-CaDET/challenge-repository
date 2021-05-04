using System.Collections.Generic;

namespace Naming.Meaning
{
    /// <summary>
    /// ** Do not modify the namespace name or the Run class name and Main method header. **
    /// 1. Identify and rename all the identifiers with poor names.
    /// 2. Identify any literals in the code and find a way to make their purpose clear.
    /// 3. Identify at least one piece of logic whose intent is not clear and extract it into a method with a meaningful name.
    /// </summary>
    public class CourseService
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

    public class Course
    {
        public string Status { get; set; }
    }

    public class Student
    {
        public List<Course> Courses { get; set; } = new List<Course>();
    }

    #region Run
    public class Run
    {
        private readonly Student _student = new Student();
        private readonly CourseService _service = new CourseService();

        public Run()
        {
            _service.Add(new Course { Status = "enrolled" }, _student);
            _service.Add(new Course { Status = "current" }, _student);
            _service.Add(new Course { Status = "enrolled" }, _student);
            _service.Add(new Course { Status = "current" }, _student);
            _service.Add(new Course { Status = "current" }, _student);
        }

        public void AddCourse()
        {
            _service.Add(new Course { Status = "enrolled" }, _student);
        }

        public int Count()
        {
            return _student.Courses.Count;
        }
    }
    #endregion
}