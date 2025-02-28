namespace SecureMvcApp.Models
{
    public class UserProfileModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public IFormFile ProfilePicture { get; set; }
    }
}
