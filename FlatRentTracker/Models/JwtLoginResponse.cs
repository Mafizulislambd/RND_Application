namespace FlatRentTracker.Models
{
    public class JwtLoginResponse
    {
        public string Token { get; set; }
        public object User { get; set; } // Or strongly typed
    }
}
