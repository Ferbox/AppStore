using System.Data.Entity;
using identity1.Common.Entities;
using identity1.Common.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace identity1.Common.EF
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext() : base("name=Apple", throwIfV1Schema: false)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<ImageOfProduct> ImagesProd { get; set; }
        public DbSet<Image> ImageProduct { get; set; }
        public DbSet<ImageofFeedback> ImagesFeed { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Display> Displays { get; set; }
        public DbSet<SizeBody> SizeBody { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
    public class AppDbInitializer:DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<User>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            var role3 = new IdentityRole { Name = "manager" };

            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            // создаем пользователей
            var admin = new User { Email = "arstanism@ya.ru", UserName = "arstan" };
            string password = "zeniT_1925";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role3.Name);
            }

            base.Seed(context);
        }
    }
}
