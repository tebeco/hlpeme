
using AutoMapper;
using BaseConn.Domain.DTOS.NoteDTOS;
using BaseConn.Domain.DTOS.ProblemDTOS;
using BaseConn.Domain.DTOS.SolutionDTOS;
using BaseConn.Domain.models;
using static BaseConn.Domain.DTOS.UserDTOS.UserDTOS;


namespace BaseConn.Application
{
  public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        
      CreateMap<ApplicationUser, UserDto>();
      CreateMap<ProblemDTO, Problem>()
          .ForMember(dest => dest.solutions, opt => opt.Ignore());

          
        CreateMap<AddSolutionDTO, Solution>()
            .ForMember(dest => dest.solution_id, opt => opt.Ignore()) 
            .ForMember(dest => dest.problem_id, opt => opt.Ignore());  
    
       CreateMap<Problem, ProblemDTO>();
                // .ForMember(dest => dest.has_file, 
                //     opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.problem_file_name)));


       CreateMap<AddProblemDTO, Problem>()
                .ForMember(dest => dest.problem_id, opt => opt.Ignore())
                .ForMember(dest => dest.createdAt, opt => opt.Ignore());
                // .ForMember(dest => dest.problem_file_id, opt => opt.Ignore());
      CreateMap<Problem, AddProblemDTO>();
      CreateMap<Note, GetNoteDTO>();
      CreateMap<Note, AddNoteDTO>();
      CreateMap<AddNoteDTO, Note>();
    }
}
}