using Microsoft.AspNetCore.Identity;

namespace eAppointmentServer.Domain.Entities
{
    // sealed ekledim baska class inherit etmesin istiyorum 
    public sealed class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } =string.Empty;
        public string LastName { get; set; } = string.Empty;

        // fullname db kaydetmiyorum boylece gerekli yerlerde fullname cagirip kullanacagim
        public string FullName => string.Join("-", FirstName, LastName);

    }
}
