using AutoMapper;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;

namespace FitnessTracker.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
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
        }
    }
}
