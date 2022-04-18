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
            var userId = User.GetUserId();
        
            return null;
        }

        [HttpPost("CreateUserWorkout"), Authorize]
        public async Task CreateUserWorkout(UserWorkoutDTO model)
        {
            var userId = User.GetUserId();
            await _userWorkoutService.CreateUserWorkoutAsync(model, userId);
        }
    }
}
