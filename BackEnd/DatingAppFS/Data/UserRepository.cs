using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingAppFS.DTOs;
using DatingAppFS.Entity;
using DatingAppFS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingAppFS.Data
{
	public class UserRepository : IUserRepository
	{
		private readonly AppUserDataContext _context;
		private readonly IMapper _mapper;

		public UserRepository(AppUserDataContext context,IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<MemberDTO> GetMemberAsync(string username)
		{
			return await _context.Users
				.Where(x=>x.UserName==username)
				.ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
				.SingleOrDefaultAsync();
		}

		public async Task<IEnumerable<MemberDTO>> GetMembersAsync()
		{
			return await _context.Users
				.ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<AppUser> GetUserByIdAsync(int id)
		{
			return await _context.Users.FindAsync( id);
		}

		public async Task<AppUser> GetUserByUsernameAsync(string username)
		{
			return await _context.Users
                .Include(p => p.Photos)
                .FirstOrDefaultAsync(x => x.UserName == username);
		}

		public async Task<IEnumerable<AppUser>> GetUsersAsync()
		{
			 return await _context.Users
				.Include(p=>p.Photos)
				.ToListAsync();
		}

		public async Task<bool> SaveAllAsync()
		{
			return await _context.SaveChangesAsync() > 0;
        }

		public void Update(AppUser user)
		{
			_context.Entry(user).State=EntityState.Modified;
		}


	}
}
