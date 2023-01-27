using DatingAppFS.Extension;
using System.ComponentModel.DataAnnotations;

namespace DatingAppFS.Entity
{
    public class AppUser
    {
        /**
        * by default EF understand Id as primary key but if we want something else to be id 
        * we have to use the key property [key]
        * 
        * Example:
        * 
        *  [Key]
        *  public int theId { get; set; }
        */

        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[] SaltedPassword { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string KnownAs { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public string Gender { get; set; }

        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public List<Photo> Photos { get; set; } = new();


       /* public int GetAge()
        {
            return DateOfBirth.CalculateAge();
        }*/

    }
}
