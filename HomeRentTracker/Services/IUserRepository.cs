using HomeRentTracker.Models;

namespace HomeRentTracker.Services
{
    public interface IUserRepository
    {
        Task<UserRegistration> UserLogin(string userId, string password);
        //Task<UserLoginResult> CheckLoginAsync(UserLoginRequest request);
    }
}
