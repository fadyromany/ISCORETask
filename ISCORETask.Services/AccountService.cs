using ISCORETask.DAL;
using ISCORETask.DTOs.Common;
using ISCORETask.DTOs.Request;
using ISCORETask.DTOs.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ISCORETask.Services
{
    public class AccountService : IAccountService
    {
        #region CTOR
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }
        #endregion

        #region PublicMethods
        public async Task<bool> CheckUserExist(RegisterDto model)
        {
            return await _accountRepository.UserExist(model.Email);
        }

        public async Task<(ErrorResponse, string?)> Register(RegisterDto model)
        {

            if (!await _accountRepository.UserExist(model.Email))
            {
                IdentityUser user = new()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Email,
                    PhoneNumber = model.MobileNumber
                };

                var (error, result) = await _accountRepository.Register(user, model.Password);
                return error != null ? (error, null) : (null, "Congratilations ! Your Account Created Successfully");
            }
            else
                return (new ErrorResponse() { Code = 400, Title = "User Existing Before" }, null);
        }

        public async Task<(ErrorResponse, UserResponse)> Login(LoginDto model)
        {
            var user = await _accountRepository.UserExist(model.Email);
            if (user)
            {
                var existingUser = await _accountRepository.UserExist(model.Email);

                var (error, result) = await _accountRepository.Login(model.Email, model.Password);
                if (error == null)
                {
                    var token = GenerateJwtToken(result);
                    var userResponse = new UserResponse
                    {
                        Token = token,
                        User = new UserDto
                        {
                            Email = result.Email,
                            UserName = result.UserName,
                            Mobile = result.PhoneNumber

                        }
                    };
                    return (null, userResponse); // No error, return user data and token

                }
                return (new ErrorResponse() { Code = 400, Title = "Invalid UserName Or Password" }, null);
            }
            else
                return (new ErrorResponse() { Code = 400, Title = "User Not Found" }, null);
        }
        #endregion

        #region PrivateMethods
        private string GenerateJwtToken(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Issuer"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
