using Microsoft.AspNetCore.Identity;
using System.Text;
using waste_management_parser.Data.Static;
using waste_management_parser.Models;

namespace waste_management_parser.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Objects.
                if (!context.WmObjects.Any())
                {
                    context.WmObjects.AddRange(new List<WmObject>()
                    {
                        new WmObject()
                        {
                            Guid = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()),
                            Mac = Encoding.ASCII.GetBytes("abcdef"),
                            Name = "Object 1",
                            Latitude = 43.370273,
                            Longitude = 17.417578,
                            CreatedAt = DateTime.Now
                        },
                        new WmObject()
                        {
                            Guid = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()),
                            Mac = Encoding.ASCII.GetBytes("bcdefa"),
                            Name = "Object 2",
                            Latitude = 44.784962,
                            Longitude = 14.447081,
                            CreatedAt = DateTime.Now
                        },
                        new WmObject()
                        {
                            Guid = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()),
                            Mac = Encoding.ASCII.GetBytes("cdefab"),
                            Name = "Object 3",
                            Latitude = 45.080784,
                            Longitude = 13.636527,
                            CreatedAt = DateTime.Now
                        }
                    });

                    context.SaveChanges();
                }

                // Records.
                if (!context.WmRecords.Any())
                {
                    context.WmRecords.AddRange(new List<WmRecord>()
                    {
                        new WmRecord()
                        {
                            Data = Encoding.ASCII.GetBytes("BQGsZ7LCluAAAAAAAAADAe5phOWe1mVAAgAAAAAAgEBAAwAAAEAzsz1A1f9Z"),
                            CreatedAt = DateTime.Now,
                            WmObjectId = 1
                        },
                        new WmRecord()
                        {
                            Data = Encoding.ASCII.GetBytes("BQGsZ7LCluAAAAAAAAADAe5phOWe1mVAAgAAAAAAgEBAAwAAAEAzsz1A1f9Z"),
                            CreatedAt = DateTime.Now,
                            WmObjectId = 1
                        },
                        new WmRecord()
                        {
                            Data = Encoding.ASCII.GetBytes("BQGsZ7LCluAAAAAAAAADAe5phOWe1mVAAgAAAAAAgEBAAwAAAEAzsz1A1f9Z"),
                            CreatedAt = DateTime.Now,
                            WmObjectId = 3
                        },
                        new WmRecord()
                        {
                            Data = Encoding.ASCII.GetBytes("BQGsZ7LCluAAAAAAAAADAe5phOWe1mVAAgAAAAAAgEBAAwAAAEAzsz1A1f9Z"),
                            CreatedAt = DateTime.Now,
                            WmObjectId= 1
                        },
                        new WmRecord()
                        {
                            Data = Encoding.ASCII.GetBytes("BQGsZ7LCluAAAAAAAAADAe5phOWe1mVAAgAAAAAAgEBAAwAAAEAzsz1A1f9Z"),
                            CreatedAt = DateTime.Now,
                            WmObjectId = 2
                        },
                    });

                    context.SaveChanges();
                }

                // Records - TriggerWasteBinEmptying
                if (!context.WmRecords_TriggerWasteBinEmptying.Any())
                {
                    context.WmRecords_TriggerWasteBinEmptying.AddRange(new List<WmRecord_TriggerWasteBinEmptying>()
                    {
                        new WmRecord_TriggerWasteBinEmptying()
                        {
                            CreatedAt = DateTime.Now
                        },
                        new WmRecord_TriggerWasteBinEmptying()
                        {
                            CreatedAt = DateTime.Now
                        },
                        new WmRecord_TriggerWasteBinEmptying()
                        {
                            CreatedAt = DateTime.Now
                        }
                    });

                    context.SaveChanges();
                }

                // Records - TriggerWasteBinEmptying & Objects
                if (!context.WmRecords_TriggerWasteBinEmptying_WmObjects.Any())
                {
                    context.WmRecords_TriggerWasteBinEmptying_WmObjects.AddRange(new List<WmRecord_TriggerWasteBinEmptying_WmObject>()
                    {
                        new WmRecord_TriggerWasteBinEmptying_WmObject()
                        {
                            WmRecord_TriggerWasteBinEmptyingId = 1,
                            WmObjectId = 1
                        },
                        new WmRecord_TriggerWasteBinEmptying_WmObject()
                        {
                            WmRecord_TriggerWasteBinEmptyingId = 1,
                            WmObjectId = 2
                        },
                        new WmRecord_TriggerWasteBinEmptying_WmObject()
                        {
                            WmRecord_TriggerWasteBinEmptyingId = 2,
                            WmObjectId = 1
                        },
                        new WmRecord_TriggerWasteBinEmptying_WmObject()
                        {
                            WmRecord_TriggerWasteBinEmptyingId = 2,
                            WmObjectId = 2
                        },
                        new WmRecord_TriggerWasteBinEmptying_WmObject()
                        {
                            WmRecord_TriggerWasteBinEmptyingId = 2,
                            WmObjectId = 3
                        }
                    });

                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@wastemanagement.com";
                string appUserEmail = "user@wastemanagement.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                var appUser = await userManager.FindByNameAsync(appUserEmail);

                // Roles.

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                // Users.

                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAdminUser, "Wm@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAppUser, "Wm@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
