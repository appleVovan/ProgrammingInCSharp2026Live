using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using KMA.ProgrammingInCSharp2026.LecturerManager.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        private readonly IStorageContext _storageContext;
        public LecturerRepository(IStorageContext storageContext)
        {
            _storageContext = storageContext;
        }
        public IEnumerable<LecturerDBModel> GetLecturersByDepartment(Guid departmentId)
        {
            return _storageContext.GetLecturersByDepartment(departmentId);
        }

        public LecturerDBModel GetLecturer(Guid lecturerId)
        {
            return _storageContext.GetLecturer(lecturerId);
        }

        public int GetLecturersCountByDepartment(Guid departmentId)
        {
            return _storageContext.GetLecturersCountByDepartment(departmentId);
        }
    }
}
