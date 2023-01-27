using DatingAppFS.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace DatingAppFS.Data
{
    public class Seed
    {
        public static async Task SeedUsers(AppUserDataContext appUser)
        {
            if (await appUser.Users.AnyAsync()) { return; }

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var users=JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();
               
                    user.UserName = user.UserName.ToLower();
                    user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                    user.SaltedPassword = hmac.Key;

                    appUser.Users.Add(user);
           
            }

            await appUser.SaveChangesAsync();
        }
    }
}
