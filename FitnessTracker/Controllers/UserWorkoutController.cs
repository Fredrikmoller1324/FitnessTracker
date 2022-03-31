using FitnessTracker.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWorkoutController : ControllerBase
    {
        [HttpGet(), Authorize]
        public async Task<IActionResult> GetUserWorkouts()
        {

            //return new List<UserWorkout>();
            return null;
        }
    }
}
