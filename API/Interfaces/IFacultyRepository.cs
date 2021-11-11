using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IFacultyRepository
    {
        Task<bool> AddFaculty(Faculty faculty);
        Task<bool> AddMajorToFaculty(Major major);
        Task<IEnumerable<FacultyDto>> getAllFacultyAndMajor();
        Task<bool> UpdateFaculty(Faculty faculty);
        Task<bool> UpdateMajor(Major major);
        Task<bool> DeleteFaculty(Faculty faculty);
        Task<bool> DeleteMajor(Major major);
    }
}