namespace AIRecruitment.BLL.DTOs.Auth
{
    public class RegisterDto
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Headline { get; set; }
        public required string Role { get; set; } //Candidate or Recruiter
    }
}