using AutoMapper;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTracker.Exceptions;
using FitnessTracker.Interfaces;

namespace FitnessTracker.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExerciseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync()
        {
           var allExercises = await _unitOfWork.ExerciseRepository.GetAllAsync(null,x=>x.ExerciseCategories);

            if (allExercises == null || !allExercises.Any()) throw new NullOrEmptyException("List of Exercises is null or empty");

            var mappedExercises = new List<ExerciseDTO>();

            foreach (var exercise in allExercises)
            {
                mappedExercises.Add(_mapper.Map<ExerciseDTO>(exercise));
            }
            
            return mappedExercises;
        }

        public async Task<ExerciseDTO> GetByNameAsync(string exerciseName)
        {
            var exercise = await _unitOfWork.ExerciseRepository.GetExerciseByName(exerciseName);

            if (exercise == null) throw new KeyNotFoundException($"exercise with name '{exerciseName}' does not exist");

            return _mapper.Map<ExerciseDTO>(exercise);
        }

        public async Task DeleteExerciseAsync(int key)
        {
            var exerciseToDelete = _unitOfWork.ExerciseRepository.Delete(exercise => exercise.Id == key);

            if (exerciseToDelete is null) throw new NullOrEmptyException($"deletion of exercise with id: '{key}' has failed");

            if (_unitOfWork.HasChangesAsync()) await _unitOfWork.CompleteAsync();

        }

        public async Task CreateExerciseAsync(ExerciseDTO newExercise)
        {
            var exerciseAlreadyExist = _unitOfWork.ExerciseRepository.Exists(e => string.Equals(e.Name,newExercise.Name, StringComparison.InvariantCultureIgnoreCase));

            if (exerciseAlreadyExist) throw new ObjectAlreadyExistsException($"Exercise with name {newExercise.Name} already exists");

            var mappedNewExercise = _mapper.Map<Exercise>(newExercise);

             _unitOfWork.ExerciseRepository.Create(mappedNewExercise);

            if (_unitOfWork.HasChangesAsync()) await _unitOfWork.CompleteAsync();
        }

    }
}
