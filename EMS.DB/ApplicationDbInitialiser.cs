namespace EMS.DB
{
    using System;
    using System.Linq;
    using EMS.DB.Models;
    using Microsoft.AspNetCore.Identity;

    public static class ApplicationDbInitialiser
    {

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            AddRoleIfNotExists(roleManager, "Admin");
            AddRoleIfNotExists(roleManager, "Supervisor");
            AddRoleIfNotExists(roleManager, "Staff");
            AddRoleIfNotExists(roleManager, "Operator");
        }
        public static void SeedUsers(UserManager<User> userManager)
        {
            (string name, string password, string role)[] demoUsers = new[]
            {
                (name: "sadmin@yopmail.com", password: "Test@123", role: "Admin"),
            };

            foreach ((string name, string password, string role) user in demoUsers)
            {
                AddUserIfNotExists(userManager, user);
            }

        }

        private static void AddUserIfNotExists(UserManager<User> userManager, (string name, string password, string role) demoUser)
        {
            User user = userManager.FindByNameAsync(demoUser.name).Result;
            if (user == default)
            {
                var newAppUser = new User
                {
                    UserName = demoUser.name,
                    Email = demoUser.name,
                    Userrole = demoUser.role,
                    EmailConfirmed = true,
                    IsActive = true
                };
                _ = userManager.CreateAsync(newAppUser, demoUser.password).Result;
                if (!string.IsNullOrWhiteSpace(demoUser.role))
                {
                    var roles = demoUser.role.Split(',').Select(a => a.Trim()).ToArray();
                    Console.WriteLine($"{roles.Length}");
                    foreach (var role in roles)
                    {
                        _ = userManager.AddToRoleAsync(newAppUser, role).Result;

                    }
                }

            }
        }

        private static void AddRoleIfNotExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (roleManager.FindByNameAsync(roleName).Result == default)
            {
                roleManager.CreateAsync(new IdentityRole { Name = roleName }).Wait();
            }
        }
    }
}
