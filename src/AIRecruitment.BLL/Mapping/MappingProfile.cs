using AIRecruitment.BLL.DTOs.Job;
using AIRecruitment.Domain.Entities;
using AutoMapper;

namespace AIRecruitment.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Job, GetJobDto>()
                .ForMember(dest => dest.Company,
                    opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.PostedDate,
                    opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Skills,
                    opt => opt.MapFrom(src =>
                        src.JobSkills.Select(js => js.Skill.Name)))
                .ForMember(dest => dest.ApplicantCount,
                    opt => opt.MapFrom(src =>
                        src.Applications.Count));

            CreateMap<CreateJobDto, Job>();
            CreateMap<UpdateJobDto, Job>();
        }
    }
}