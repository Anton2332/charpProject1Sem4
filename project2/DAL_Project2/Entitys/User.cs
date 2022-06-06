using Microsoft.AspNetCore.Identity;

namespace DAL_Project2.Entitys
{
    public class User : IdentityUser
    {
        public int Rating { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;

        public IList<Offers> Offers { get; set; }
        public IList<Orders> Orders { get; set; }
        public IList<RefreshToken> RefreshTokens { get; set; }
    }
}
