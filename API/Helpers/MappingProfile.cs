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
            CreateMap<CreateCourseDto, Course>();
            CreateMap<UpdateCourseDto, Course>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<Course, CourseCardDto>()
                .ForMember(card => card.ImageUrl, opt => opt.MapFrom(src => src.Photo.Url))
                .ForMember(card => card.TeacherName, opt => opt.MapFrom(src => src.Teacher.UserName));
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Photo.Url))
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.UserName));
            CreateMap<Lesson, LessonDto>()
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.Video.Url));
        }
    }
}
