using FitnessTracker.Entities;
using FitnessTracker.Interfaces;

namespace FitnessTracker.Services
{
    public interface IChangePasswordService
    {
        User ChangePassword(User user, string currentPassword, string newPassword, string ConfirmNewPassword);
    }
    public class ChangePasswordService : IChangePasswordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangePasswordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User ChangePassword(User user, string currentPassword, string newPassword, string ConfirmNewPassword)
        {
            if (!BCrypt.Net.BCrypt.Verify (currentPassword,user.Password)) throw new KeyNotFoundException($"current password is incorrect");

            user.Password = BCrypt.Net.BCrypt.HashPassword(ConfirmNewPassword);
            _unitOfWork.UserRepository.UpdateUserAsync(user);

            return user;
        }
    }
}
