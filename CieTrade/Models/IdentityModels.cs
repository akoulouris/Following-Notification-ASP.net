using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CieTrade.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public ICollection<UserNotification> UserNotification { get; set; }

        public ApplicationUser()
        {
            UserNotification = new Collection<UserNotification>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public void Notify(Notification notification)
        {

            var userNotification = new UserNotification(this, notification);
            UserNotification.Add(userNotification);
            
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Card> Cards { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Follow> Followers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>().HasRequired(f => f.Card).WithMany(g =>g.Followers).WillCascadeOnDelete(false);
            modelBuilder.Entity<UserNotification>().HasRequired(u=>u.User).WithMany(g => g.UserNotification).WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}