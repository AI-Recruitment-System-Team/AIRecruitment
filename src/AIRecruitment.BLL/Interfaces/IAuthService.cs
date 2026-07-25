using AIRecruitment.BLL.DTOs.Auth;

namespace AIRecruitment.BLL.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto registerDto);
    Task <LoginResponseDto> LoginAsync(LoginDto loginDto);
}