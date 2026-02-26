using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace KMA.ProgrammingInChsarp2026.Samples.Original
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    internal class Student
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private string firstName;
        private string lastName;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public Student(string firstName = "Default", string lastName = "Default")
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || obj is not Student)
                return false;
            Student castedObj = (Student)obj;                 
            return this.FirstName == castedObj.FirstName && LastName == castedObj.LastName;
        }
    }
}
