﻿using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using BrowserTravel.Library.Repository.Interfaces;
using BrowserTravel.Library.Infraestructure.Models;
using BrowserTravel.Library.Entities.Dto.Auth;
using BrowserTravel.Library.Entities.Models;
using BrowserTravel.Library.Services.Interfaces;
using BrowserTravel.Library.Common.Cryptography;

namespace BrowserTravel.Library.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly Token _appSettings;

        public AccountService(IAccountRepository accountRepository, IOptions<Token> appSettings)
        {
            _accountRepository = accountRepository;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Determines the security status of the user in the application.
        /// </summary>
        /// <param name="userSignInDto"></param>
        /// <returns></returns>
        public async Task<UserDto> SignIn(UserSignInDto userSignInDto)
        {
            var user = await _accountRepository.SignIn(new User
            {
                Email = userSignInDto.Email
            });

            if (user == null)
                return null;

            // Compare hash password
            string sentPassword = HiddenSecret.Hash(userSignInDto.Password, user.Salt);
            if (!sentPassword.Equals(user.SaltedAndHashedPassword))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Rol.Name));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userResult = new UserDto
            {
                Email = user.Email,
                Name= user.Name,
                Id = user.Id,
                CreateAt= user.CreateAt,
                Token = tokenHandler.WriteToken(token)
            };

            return userResult;
        }
    }
}
