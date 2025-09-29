using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusLink
{
    public class StudentManager : IManageStudents<Student>
    {
        private List<Student> students = new List<Student>();

        public void Add(Student student)
        {
            students.Add(student);
        }

        public bool Edit(string id, string name = null, string gender = null, int? age = null)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);
            if (student != null)
            {
                if (!string.IsNullOrEmpty(name)) student.Name = name;
                if (!string.IsNullOrEmpty(gender)) student.Gender = gender;
                if (age.HasValue) student.Age = age.Value;
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);
            if (student != null)
            {
                students.Remove(student);
                return true;
            }
            return false;
        }

        public List<Student> List()
        {
            return students;
        }

        public List<Student> Sort(string by)
        {
            if (by.ToLower() == "name")
                return students.OrderBy(s => s.Name).ToList();
            else if (by.ToLower() == "age")
                return students.OrderBy(s => s.Age).ToList();
            return students;
        }
    }
}
