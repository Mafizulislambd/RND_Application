using HomeRentTracker.Models;

namespace HomeRentTracker.Services.Contract
{
    public interface IUserServices
    {
        UserRegistration ValidateUser(string username, string password);
        int RegisterUser(string username, string userFirstName, string userMName, string userLName, string userFullName, string userEmail, String userPhone, string password);
        //Task<UserLoginResult> CheckLoginAsync(UserLoginRequest request);
    }
}
