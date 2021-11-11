using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using AutoMapper;
namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Group, GroupDto>();
            //CreateMap<Enrolled, EnrolledDto>();
            CreateMap<Lesson, LessonDto>();
        }
    }
}
