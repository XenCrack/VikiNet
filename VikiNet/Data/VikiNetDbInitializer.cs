using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VikiNet.Models;

namespace VikiNet.Entity
{
    public class VikiNetDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<VikiNetDbContext>();
                context.Database.EnsureCreated();

                if(!context.Subject.Any())
                {
                    var subjectList = new List<Subject>
                    {
                        new Subject()
                        {
                            Name = "Tarih",
                            Description = "Deneme",
                            ImageUrl = "https://xn--zelders-80a.org/wp-content/uploads/2017/07/tarih.jpg"
                        },
                        new Subject()
                        {
                            Name = "Din",
                            Description = "Deneme2",
                            ImageUrl = "https://xn--zelders-80a.org/wp-content/uploads/2017/07/tarih.jpg"
                        },
                        new Subject()
                        {
                            Name = "Bilim",
                            Description = "Deneme3",
                            ImageUrl = "https://xn--zelders-80a.org/wp-content/uploads/2017/07/tarih.jpg"
                        }
                    };

                    context.Subject.AddRange(subjectList);

                    context.SaveChanges();

                }

                if (!context.SubjectType.Any())
                {
                    var subjectTypes = new List<SubjectType>()
                    {
                        new SubjectType
                        {
                            SubjectName = "Din"
                        },
                        new SubjectType
                        {
                            SubjectName = "Tarih"
                        },
                        new SubjectType
                        {
                            SubjectName = "Edebiyat"
                        },
                        new SubjectType
                        {
                            SubjectName = "Teknoloji"
                        }
                    };

                    context.SubjectType.AddRange(subjectTypes);
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

                if (!await roleManager.RoleExistsAsync("User"))
                    await roleManager.CreateAsync(new IdentityRole("User"));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var adminUserEmail = "admin@a.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser
                    {
                        Name = "admin",
                        Surname = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        BirthDate = Convert.ToDateTime("01.01.2000"),
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        UserName = "admin",
                        Discriminator = string.Empty
                    };

                    var result = await userManager.CreateAsync(newAdminUser, "123QWEaB");
                    await userManager.AddToRoleAsync(newAdminUser, "admin");
                }

                var userEmail = "a@b.com";
                var user = await userManager.FindByEmailAsync(userEmail);

                if(user == null)
                {
                    var newUser = new ApplicationUser
                    {
                        Name = "user",
                        Surname = "user",
                        Email = userEmail,
                        EmailConfirmed = true,
                        BirthDate = Convert.ToDateTime("01.01.2000"),
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        UserName = "user",
                        Discriminator = string.Empty
                    };

                    await userManager.CreateAsync(newUser, "123QWEaA");
                    await userManager.AddToRoleAsync(newUser, "user");
                }
            }
        }
    }
}
