using AutoMapper;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;

namespace FitnessTracker.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {

            // DTO to Exercise and reverse
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
                ).ReverseMap();


            // DTO to UserWorkout and reverse
            CreateMap<UserWorkout, UserWorkoutDTO>()
                .ForMember(
                    dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.TimeTaken,
                    opt => opt.MapFrom(src => src.TimeTaken)
                )
                .ForMember(
                dest=>dest.WorkoutExercises,
                opt=>opt.MapFrom(src=>src.WorkoutExercises)
                ).ReverseMap();
            
        }
    }
}
