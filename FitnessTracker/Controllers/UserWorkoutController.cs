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
        private readonly ILogger<UserWorkoutController> _logger;

        public UserWorkoutController(IUserWorkoutService userWorkoutService, ILogger<UserWorkoutController> logger)
        {
            _userWorkoutService = userWorkoutService;
            _logger = logger;
        }

        [HttpGet("GetAllUserWorkouts"), Authorize]
        public async Task<IActionResult> GetUserWorkouts()
        {
            try
            {
                _logger.LogInformation("in 'GetAllUserWorkouts'");

                var userId = User.GetUserId();

                var allUserWorkouts = await _userWorkoutService.GetAllUserWorkouts(userId);

                return Ok(allUserWorkouts);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("GetAllUserWorkoutsByName"), Authorize]
        public async Task<IActionResult> GetUserWorkouts(string userWorkoutName)
        {
            try
            {
                _logger.LogInformation("In 'GetAllUserWorkoutsByName'");

                var userId = User.GetUserId();

                var allUserWorkouts = await _userWorkoutService.GetAllSpecificUserWorkoutsByName(userId,userWorkoutName);

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

        [HttpDelete("DeleteUserWorkout"), Authorize]
        public async Task<IActionResult> DeleteUserWorkout(string userWorkoutName)
        {
            try
            {
                if (string.IsNullOrEmpty(userWorkoutName)) return BadRequest();

                var userId = User.GetUserId();

                var deletedUserWorkout = await _userWorkoutService.DeleteUserWorkoutAsync(userWorkoutName, userId);

                return Ok(deletedUserWorkout);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
