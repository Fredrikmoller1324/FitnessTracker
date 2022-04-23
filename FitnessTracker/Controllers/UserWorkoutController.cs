using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTracker.Helpers;
using FitnessTracker.Interfaces;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWorkoutController : ControllerBase
    {
        private readonly IUserWorkoutService _userWorkoutService;

        public UserWorkoutController(IUserWorkoutService userWorkoutService)
        {
            _userWorkoutService = userWorkoutService;
        }

        [HttpGet("GetAllUserWorkouts"), Authorize]
        public async Task<IActionResult> GetUserWorkouts()
        {
            try
            {
                var userId = User.GetUserId();

                var allUserWorkouts = await _userWorkoutService.GetAllUserWorkouts(userId);

                return Ok(allUserWorkouts);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPost("CreateUserWorkout"), Authorize]
        public async Task CreateUserWorkout(UserWorkoutDTO model)
        {
            var userId = User.GetUserId();
            await _userWorkoutService.CreateUserWorkoutAsync(model, userId);
        }
    }
}
