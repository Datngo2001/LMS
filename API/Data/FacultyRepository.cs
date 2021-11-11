using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class FacultyRepository : IFacultyRepository
    {

        private readonly DataContext _context;

        public FacultyRepository(DataContext context)
        {
            this._context = context;
        }
        public async Task<bool> AddFaculty(Faculty faculty)
        {
            bool isExist = await _context.Faculties.AnyAsync(f => f.Name == faculty.Name);
            if (isExist)
            {
                return false;
            }
            else
            {
                await _context.Faculties.AddAsync(faculty);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> AddMajorToFaculty(Major major)
        {
            Faculty faculty = await _context.Faculties.Include(f => f.Majors).FirstOrDefaultAsync(f => f.fId == major.FacultyId);
            if (faculty == null)
            {
                return false;
            }
            else if (faculty.Majors == null)
            {
                faculty.Majors = new List<Major>();
            }
            else if (faculty.Majors.Any(m => m.Name == major.Name))
            {
                return false;
            }
            faculty.Majors.Add(major);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FacultyDto>> getAllFacultyAndMajor()
        {
            return await (from f in _context.Faculties
                          select new FacultyDto()
                          {
                              fId = f.fId,
                              Name = f.Name,
                              Majors = (from m in f.Majors
                                        select new MajorDto()
                                        {
                                            mId = m.mId,
                                            Name = m.Name
                                        }).ToList()
                          }).AsSingleQuery().ToListAsync();
        }

        public Task<bool> DeleteFaculty(Faculty faculty)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMajor(Major major)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFaculty(Faculty faculty)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMajor(Major major)
        {
            throw new NotImplementedException();
        }
    }
}