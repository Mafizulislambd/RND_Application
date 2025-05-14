namespace AutoMapper.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UserDto
    {
        public string FullName { get; set; }
    }

}
