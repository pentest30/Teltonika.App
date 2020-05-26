using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Teltonika.Core;
using Teltonika.Core.Data;
using Teltonika.Core.Domain.Users;

namespace Teeltonika.Application.Service
{
    public class UserService :IUserService
    {
        private readonly ApplicationContext _context;
        private readonly AppSettings _appSettings;
        private readonly UserManager<UserApp> _userManager;

        public UserService(AppSettings appSettings, ApplicationContext context, UserManager<UserApp> userManager)
        {
            _context = context;
            _userManager = userManager;
            _appSettings = appSettings;
        }

        public async Task<UserApp> AuthenticateAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username).ConfigureAwait(false);

            // return null if user not found
            if (user == null || _userManager.PasswordHasher.VerifyHashedPassword(user,user.PasswordHash, password) == PasswordVerificationResult.Failed)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public IEnumerable<UserApp> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
