using DatingAppFS.Data;
using DatingAppFS.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppFS.Controllers
{
    public class BuggyController : Controller
    {
        private readonly AppUserDataContext _appUserDataContext;

        public BuggyController(AppUserDataContext appUserDataContext)
        {
            _appUserDataContext = appUserDataContext;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _appUserDataContext.Users.Find(-1);
            if (thing == null)
            {
                return NotFound();
            }
            return thing;
        }

        [HttpGet("server-Error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _appUserDataContext.Users.Find(-1);
            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> BadRequest()
        {
            return BadRequest("This is bad bro");
        }

    }
}
