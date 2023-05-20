using System;
using System.Threading.Tasks;
using BrowserTravel.Library.Common.Cryptography;
using BrowserTravel.Library.Entities.Dto.Auth;
using BrowserTravel.Library.Entities.Models;
using BrowserTravel.Library.Repository.Interfaces;
using BrowserTravel.Library.Services.Interfaces;

namespace BrowserTravel.Library.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IUserRepository _userRepository;

        public RegisterService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Allows the registration of new users
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        public async Task<RegisterResponseDto> Register(RegisterDto registerDto)
        {
            User user = new User
            {
                Email = registerDto.Email,
                Salt = HiddenSecret.GenerateSalt(),
                CreateAt = DateTime.Now,
                IdRol = 2
            };

            user.SaltedAndHashedPassword = HiddenSecret.Hash(registerDto.Password, user.Salt);
            var userResponse = await _userRepository.Add(user);

            return new RegisterResponseDto
            {
                Email = userResponse.Email,
                CreateAt= userResponse.CreateAt,
                Id = userResponse.Id
            };
        }
    }
}
