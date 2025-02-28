using AutoMapper;
using QimiaSchool.Business.Implementations.Queries.Courses.Dtos;
using QimiaSchool.Business.Implementations.Queries.Enrollments.Dtos;
using QimiaSchool.Business.Implementations.Queries.Students.Dtos;
using QimiaSchool.DataAccess.Entities;

namespace QimiaSchool.Business.Implementations.MapperProfiles;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Enrollment, EnrollmentDto>()
            .ForMember(dest=> dest.Student, opt => opt.MapFrom(src => src.Student))
            .ForMember(dest=> dest.Course, opt => opt.MapFrom(src => src.Course))
            .ForMember(dest=> dest.Grade, opt => opt.MapFrom(src => src.Grade))
            ;
        CreateMap<Student, StudentDto>()
            .ForMember(dest => dest.Enrollments, opt => opt.MapFrom(src => src.Enrollments))
            ;
        CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.Enrollments, opt => opt.MapFrom(src => src.Enrollments))
            ;
    }
}
