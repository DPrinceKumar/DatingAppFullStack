using AutoMapper;
using DatingAppFS.DTOs;
using DatingAppFS.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/**
 *  ApiController is written to say that it's not any MVC controller
 *  [Route("/api/[controller]")]    //  this [/api/Users] will become the default endpoint for this controller
 *  ctor is for generating constructor
 *  DataContext here is AppUserDbContext         
 */
namespace DatingAppFS.Controllers
{
    [Authorize]
    public class UsersController: BaseApiController
    {
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UsersController(IUserRepository userRepository,IMapper mapper)
        {
			_userRepository = userRepository;
			_mapper = mapper;
			//  this._userRepository = dataContext;
		}

        [HttpGet]
        [AllowAnonymous]
        [Route("getInfo")]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();
         //   var usersToReturn = _mapper.Map<IEnumerable<MemberDTO>>(users);

            return Ok(users);

        }


        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDTO>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);  //FirstOrDefault will return first occurce in databse 
        }
    }
}
