using FitnessTracker.Data;
using FitnessTracker.Data.Auth;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTracker.Interfaces;
using MailLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FitnessTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly IMailService _mailService;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration config, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _mailService = mailService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDTO newUser)
        {
            try
            {
                var allUsers = await _unitOfWork.UserRepository.GetUsersAsync();

                if (allUsers.Any(x => x.Username == newUser.UserName)) return StatusCode(409, "");

                string encryptedUsername = StringEncryption.Encrypt(newUser.UserName);

                await _unitOfWork.UserRepository.AddUser(new User
                {
                    Username = encryptedUsername,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    password = BCrypt.Net.BCrypt.HashPassword(newUser.Password)
                });

                if (await _unitOfWork.CompleteAsync()) 
                {
                    var request = new MailRequest
                    {
                        Subject = "Registred",
                        Body = $"Welcome to Fitnesstracker, {newUser.FirstName} {newUser.LastName}",
                        ToEmail = $"{newUser.UserName}"
                    };
                    await _mailService.SendEmailAsync(request);
                    return StatusCode(201);
                } 

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginCredentials credentials)
        {
            try
            {
                var encryptedUsername = StringEncryption.Encrypt(credentials.UserName);
                var user = await _unitOfWork.UserRepository.GetUserByUsername(encryptedUsername);

                if (user == null || !BCrypt.Net.BCrypt.Verify(credentials.Password, user.password))
                {
                    throw new KeyNotFoundException($"Username or password is incorrect");
                }

                string token = CreateToken(user);
                return Ok(token);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
