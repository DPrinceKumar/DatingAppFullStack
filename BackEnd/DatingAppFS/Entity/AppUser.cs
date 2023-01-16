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
    }
}
