using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace identity1.Domain.Entities
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class User:IdentityUser
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.Feedback = new HashSet<Feedback>();
        }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Feedback> Feedback { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext() : base("AppStore", throwIfV1Schema: false)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Characteristics> Characteristics { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Display> Displays { get; set; }
        public DbSet<SizeBody> SizeBody { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}