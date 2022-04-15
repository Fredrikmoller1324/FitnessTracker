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
                var Exercises = await _exerciseService.GetAllExercises();

                return Ok(Exercises.ToList());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
