using Microsoft.AspNetCore.Identity;

namespace Proyecto_SouKuroApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string NombreUsuario { get; set; } = string.Empty;

        public DateOnly? FechaNacimiento { get; set; }
    }

}
