using Microsoft.AspNetCore.Identity;

namespace Consumer.Models
{
    public class User : IdentityUser<int>
    {
        public UserAddress Address { get; set; }
    }
}
