using System;

namespace CampusLink
{
    public class Student : Person
    {
        public string StudentID { get; private set; }

        public Student(string name, string gender, int age) 
            : base(name, gender, age)
        {
            // Auto-generate unique ID
            StudentID = Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}
