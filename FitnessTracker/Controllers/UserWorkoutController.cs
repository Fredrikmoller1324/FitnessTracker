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
        public IEnumerable<UserWorkout> GetUserWorkouts()
        {

            return new List<UserWorkout>();
        }
    }
}
