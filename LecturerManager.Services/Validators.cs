using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    public static class Validators
    {
        public record struct ValidationError(string ErrorMessage, string MemberName);

        public static List<ValidationError> Validate(this LecturerCreateDTO lecturerCandidate)
        {
            var errors = new List<ValidationError>();
            if (lecturerCandidate.DepartmentId == Guid.Empty)
                errors.Add(new ValidationError("Lecturer must be assigned to a department.", nameof(LecturerCreateDTO.DepartmentId)));
            errors.AddRange(ValidateLecturer(lecturerCandidate.FirstName, lecturerCandidate.LastName, lecturerCandidate.Position, lecturerCandidate.DateOfBirth));
            return errors;
        }

        public static List<ValidationError> ValidateLecturer(string firstName, string lastName, LecturerPosition? position, DateTime? dateOfBirth)
        {
            var errors = new List<ValidationError>();
            errors.AddRange(ValidatePersonName(firstName, nameof(LecturerCreateDTO.FirstName), "First Name"));
            errors.AddRange(ValidatePersonName(lastName, nameof(LecturerCreateDTO.LastName), "Last Name"));
            if (position == null)
            {
                errors.Add(new ValidationError("Lecturer position must be selected.", nameof(LecturerCreateDTO.Position)));
            }
            errors.AddRange(ValidateDoB(dateOfBirth, nameof(LecturerCreateDTO.DateOfBirth), "Date of birth"));
            return errors;
        }

        private static List<ValidationError> ValidatePersonName(string name, string propertyName, string displayName)
        {
            var errors = new List<ValidationError>();
            if (String.IsNullOrWhiteSpace(name))
            {
                errors.Add(new ValidationError($"{displayName} can't be empty.", propertyName));
                return errors;
            }
            if (name.Length < 2)
                errors.Add(new ValidationError($"{displayName} must be at least 2 caracters long.", propertyName));
            if (!name.All(char.IsLetter))
                errors.Add(new ValidationError($"{displayName} must consist only from letters.", propertyName));
            return errors;
        }

        private static List<ValidationError> ValidateDoB(DateTime? dateOfBirth, string propertyName, string displayName)
        {
            var errors = new List<ValidationError>();
            if (dateOfBirth == null)
                errors.Add(new ValidationError($"{displayName}  must be selected.", propertyName));
            if (dateOfBirth >= DateTime.Today)
                errors.Add(new ValidationError($"{displayName}  cannot be in future.", propertyName));
            return errors;
        }
    }
}
