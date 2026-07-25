namespace AIRecruitment.BLL.DTOs.Auth
{
    public class LoginResponseDto
    {
        public required string Token { get; set; }
        public required string Email { get; set; }
        public required string FullName { get; set; }
        public required string Role { get; set; }
    }
}