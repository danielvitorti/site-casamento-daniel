using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace casamento.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<casamento.Models.Noivos> Noivos { get; set; }

        public System.Data.Entity.DbSet<casamento.Models.Mensagem> Mensagems { get; set; }

        public System.Data.Entity.DbSet<casamento.Models.Padrinhos> Padrinhos { get; set; }

        public System.Data.Entity.DbSet<casamento.Models.Convidados> Convidados { get; set; }

        public System.Data.Entity.DbSet<casamento.Models.ImagensDestaque> ImagensDestaques { get; set; }

        public System.Data.Entity.DbSet<casamento.Models.Endereco> Enderecoes { get; set; }

        public System.Data.Entity.DbSet<casamento.Models.Frase> Frases { get; set; }

        public System.Data.Entity.DbSet<casamento.Models.Historia> Historias { get; set; }

        public System.Data.Entity.DbSet<casamento.Areas.admin.Models.Usuarios> Usuarios { get; set; }
    }
}