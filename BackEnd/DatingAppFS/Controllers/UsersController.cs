using Microsoft.AspNetCore.Mvc;

using DatingAppFS.Data;
using DatingAppFS.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/**
 *  ApiController is written to say that it's not any MVC controller
 *  [Route("/api/[controller]")]    //  this [/api/Users] will become the default endpoint for this controller
 *  ctor is for generating constructor
 *  DataContext here is AppUserDbContext         
 */
namespace DatingAppFS.Controllers
{
    [ApiController]

    [Route("/api/[controller]")]
    public class UsersController
    {
        private readonly AppUserDataContext _dataContext;

        public UsersController(AppUserDataContext dataContext)
        {
            //  this._dataContext = dataContext;
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("/api/getInfo")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _dataContext.Users.ToListAsync();

            return users;
        }


        [HttpPost("/search/{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _dataContext.Users.FindAsync(id);     //FirstOrDefault will return first occurce in databse 
        }
    }
}
