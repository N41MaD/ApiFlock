using ApiFlock.Dtos;

namespace ApiFlock.Service
{
    public interface ILoginService
    {
        LoginResponseDto Login(LoginRequestDto model);
    }
}
