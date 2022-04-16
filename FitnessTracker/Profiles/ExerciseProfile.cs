using AutoMapper;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;

namespace FitnessTracker.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {

            // DTO to Exercise
            CreateMap<Exercise, ExerciseDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.ExerciseCategories,
                    opt => opt.MapFrom(src => src.ExerciseCategories)
                );
            
            // Exercise to DTO
            CreateMap<ExerciseDTO, Exercise>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.ExerciseCategories,
                    opt => opt.MapFrom(src => src.ExerciseCategories)
                );
        }
    }
}
