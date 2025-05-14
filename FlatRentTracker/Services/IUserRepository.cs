using FlatRentTracker.Models;

namespace FlatRentTracker.Services
{
    public interface IUserRepository
    {
        Task<UserLoginResult> CheckLoginAsync(UserLoginRequest request);
    }
}
