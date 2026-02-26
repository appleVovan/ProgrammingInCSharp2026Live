using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace KMA.ProgrammingInChsarp2026.Samples.Copy
#pragma warning restore IDE0130 // Namespace does not match folder structure
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
