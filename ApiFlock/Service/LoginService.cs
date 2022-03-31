using ApiFlock.Configuration;
using ApiFlock.Dtos;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;

using System.Text;

namespace ApiFlock.Service
{
    public class LoginService : ILoginService
    {
        private readonly UserSetting _userSetting;
        private readonly GeneralSetting _generalSetting;

        public LoginService(ConfigurationContext configurationContext)
        {
            _userSetting = configurationContext.UserSetting.Value;
            _generalSetting = configurationContext.GeneralSetting.Value;
        }


        public LoginResponseDto Login(LoginRequestDto model)
        {
            var userEmailCorrect = _userSetting.email;
            var userPassWordCorrect = _userSetting.password;

            var response = new LoginResponseDto();

            if (userEmailCorrect == model.Email && userPassWordCorrect == model.Password)
            {
                response = BuildToken(model);
            }

            return response;
        }



        private LoginResponseDto BuildToken(LoginRequestDto model)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_generalSetting.JWTSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new(
               issuer: "Flock.com",
               audience: "Flock.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            var response = new LoginResponseDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirateDate = expiration.ToString()
            };


            return response;
        }
    }
}
