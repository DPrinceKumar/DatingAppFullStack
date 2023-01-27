using AutoMapper;
using DatingAppFS.DTOs;
using DatingAppFS.Entity;
using DatingAppFS.Extension;

namespace DatingAppFS.Helpers
{
	public class AutoMapperProfiles:Profile
	{
		public AutoMapperProfiles()
		{
			//map the ENtity to Data transfer Obj 
			CreateMap<AppUser, MemberDTO>()
				.ForMember(dest => dest.photoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
				.ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
				
			CreateMap<Photo,PhotoDTO>();

		}
	}
}
