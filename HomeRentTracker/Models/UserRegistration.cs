namespace HomeRentTracker.Models
{
    public class UserRegistration
    {
        public bool IsSuccess { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public int UserType { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
