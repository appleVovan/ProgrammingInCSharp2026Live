using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.Samples.Original
{
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string firstName = "Default", string lastName = "Default")
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
