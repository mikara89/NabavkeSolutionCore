using Microsoft.AspNetCore.Identity;

namespace NabavkeSolutionCore.Data.Models.Code_First_DB
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}