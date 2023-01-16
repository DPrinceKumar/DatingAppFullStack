using DatingAppFS.Data;
using DatingAppFS.DTOs;
using DatingAppFS.Entity;
using DatingAppFS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DatingAppFS.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly AppUserDataContext _registerContext;

        private readonly ITokenService _tokenService;

        public AccountController(AppUserDataContext registerContext,ITokenService tokenService)
        {
            _registerContext = registerContext;
            _tokenService = tokenService;
        }

        /**
         * 
         * REGISTRATION
         * 
         */
        [HttpPost("register")]  //POST: api/account/register

        public async Task<ActionResult<UserDTO>> Register( RegisterDTO registerDtoClass) 
        {
            if (await UserExist(registerDtoClass.userName)) return BadRequest("User Name Is already taken ");

            using var hmac=new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDtoClass.userName.ToLower(),
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDtoClass.password.ToLower())),
                SaltedPassword = hmac.Key
            };
            _registerContext.Users.Add(user);
            await _registerContext.SaveChangesAsync();

            return new UserDTO
            {
                Username=user.UserName,
                Token=_tokenService.CreateToken(user)
            };


        }
        private async Task<bool> UserExist(string uE)
        {
            return await _registerContext.Users.AnyAsync(x => x.UserName == uE.ToLower());
        }


        /**
         * 
         * LOGIN
         * 
         */

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)

        {
            var user = await _registerContext.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.UserName);
            if (user==null) return Unauthorized();

            //deCryptinh
            using var hmac = new HMACSHA512(user.SaltedPassword) ;
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.Password[i]) return Unauthorized("Invalid Password");
            }

            return new UserDTO
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}
