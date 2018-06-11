using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using identity1.Common.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace identity1.Common.Identity  
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
    
}