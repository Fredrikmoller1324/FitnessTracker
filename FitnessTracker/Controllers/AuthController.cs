using FitnessTracker.Data;
using FitnessTracker.Data.Auth;
using FitnessTracker.Data.Models.Auth;
using FitnessTracker.Entities;
using FitnessTracker.Entities.DTOs;
using FitnessTracker.Helpers;
using FitnessTracker.Interfaces;
using FitnessTracker.Services;
using MailLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FitnessTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly IMailService _mailService;
        private readonly IChangePasswordService _passwordService;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration config,
            IMailService mailService, IChangePasswordService passwordService)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _mailService = mailService;
            _passwordService = passwordService;
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

                string token = TokenHandler.CreateLoginToken(user,_config);
                return Ok(token);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("ChangePassword"), Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            if (changePasswordRequest.NewPassword != changePasswordRequest.ConfirmNewPassword) return BadRequest("New password and confirm new password is not equal");

            var loggedInUsername = User.GetUsername();

            var user = await  _unitOfWork.UserRepository.GetUserByUsername(loggedInUsername);

            if (user is null) return NotFound($"user with username '{StringEncryption.Decrypt(loggedInUsername)}' was not found");

            var result = _passwordService.ChangePassword(user, changePasswordRequest.CurrentPassword, changePasswordRequest.NewPassword, changePasswordRequest.ConfirmNewPassword);

            if (result is null) return StatusCode(500, "update password was unsuccesful");

            await _unitOfWork.CompleteAsync();

            return Ok("Password was successfully updated");

        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string username)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsername(StringEncryption.Encrypt(username));

            if (user is null) return NotFound($"user with username {username} doesn't exist");

            var token = TokenHandler.CreatePasswordResetToken(user,_config);

            var resetLink = $"https://localhost:7146/api/Auth/ResetPassword/{user.Id}/{token}";

            var request = new MailRequest
            {
                Subject = "Reset Password",
                Body = $"Password reset was requested by {user.FirstName} \nplease click the link below to reset your password \n" +
                $"{resetLink}",
                ToEmail = $"{username}"
            };
            await _mailService.SendEmailAsync(request);

            return Ok();
        }

        [HttpGet("ResetPassword/{id}/{token}")]
        public async Task<IActionResult> ResetPassword([FromRoute] int id, string token)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetUserById(id);

                var tokenIsValid = TokenHandler.ValidateToken(token, _config);

                //TODO redirect to frontend reset password form
                return Redirect(""); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            
        }
    }
}
