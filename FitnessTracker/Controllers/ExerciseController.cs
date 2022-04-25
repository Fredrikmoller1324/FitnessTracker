using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTracker.Interfaces;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;
        
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet("GetAllExercises")]
        public async Task<IActionResult> GetAllExercises()
        {
            try
            {
                var Exercises = await _exerciseService.GetAllExercisesAsync();

                return Ok(Exercises);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetExerciseByName")]
        public async Task<IActionResult> GetExercise(string exerciseName)
        {
            try
            {
                var exercise = await _exerciseService.GetByNameAsync(exerciseName);

                return Ok(exercise);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("CreateExercise")]
        public async Task<IActionResult> CreateExercise(ExerciseDTO exercise)
        {
            try
            {
               var createdExercise= await _exerciseService.CreateExerciseAsync(exercise);

                return Ok(createdExercise);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("DeleteExercise")]
        public async Task<IActionResult> DeleteExercise(int exerciseId)
        {
            try
            {
                var deletedExercise = await _exerciseService.DeleteExerciseAsync(exerciseId);

                return Ok(deletedExercise);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
