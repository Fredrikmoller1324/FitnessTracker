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
        private readonly IConfiguration _config;

        public ExerciseController(IExerciseService exerciseService, IConfiguration config)
        {
            _exerciseService = exerciseService;
            _config = config;
        }

        [HttpGet("GetAllExercises")]
        public async Task<IActionResult> GetAllExercises()
        {
            try
            {
                var Exercises = await _exerciseService.GetAllExercisesAsync();

                return Ok(Exercises.ToList());
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
                await _exerciseService.CreateExerciseAsync(exercise);

                return Ok();
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
                await _exerciseService.DeleteExerciseAsync(exerciseId);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
