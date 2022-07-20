using Microsoft.AspNetCore.Identity;
using System.Text;
using waste_management_parser.Data.Static;
using waste_management_parser.Models;

namespace waste_management_parser.Data
{
    public class AppDbInitializer
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AspNetUser>>();

                string adminUserEmail = "admin@wastemanagement.com";
                string appUserEmail = "user@wastemanagement.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                var appUser = await userManager.FindByEmailAsync(appUserEmail);

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
                    var newAdminUser = new AspNetUser()
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
                    var newAppUser = new AspNetUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newAppUser, "Wm@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                appUser = await userManager.FindByEmailAsync(appUserEmail);

                context.Database.EnsureCreated();

                // Organizations.
                if (!context.WmOrganizations.Any())
                {
                    context.WmOrganizations.AddRange(new List<WmOrganization>()
                    {
                        new WmOrganization()
                        {
                            Guid = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()),
                            Name = "Waste Management Organization"
                        }
                    });

                    context.SaveChanges();
                }

                // Groups.
                if (!context.WmGroups.Any())
                {
                    context.WmGroups.AddRange(new List<WmGroup>()
                    {
                        new WmGroup()
                        {
                            Guid = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()),
                            Name = WmGroups.WasteBin,
                            NormalizedName = WmGroups.WasteBin.ToUpper(),
                            WmOrganizationId = 1
                        }
                    });

                    context.SaveChanges();
                }

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
                            IsActivated = true,
                            OwnerId = appUser.Id,
                            WmGroupId = 1
                        },
                        new WmObject()
                        {
                            Guid = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()),
                            Mac = Encoding.ASCII.GetBytes("bcdefa"),
                            Name = "Object 2",
                            Latitude = 44.784962,
                            Longitude = 14.447081,
                            IsActivated = true,
                            OwnerId = appUser.Id,
                            WmGroupId = 1
                        },
                        new WmObject()
                        {
                            Guid = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()),
                            Mac = Encoding.ASCII.GetBytes("cdefab"),
                            Name = "Object 3",
                            Latitude = 45.080784,
                            Longitude = 13.636527,
                            IsActivated = true,
                            OwnerId = appUser.Id,
                            WmGroupId = 1
                        },
                        new WmObject()
                        {
                            Guid = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()),
                            Mac = new byte[] { 172, 103, 178, 194, 150, 224 },
                            Name = "Object 3",
                            Latitude = 45.080784,
                            Longitude = 13.636527,
                            IsActivated = false,
                            ActivationCode = Encoding.ASCII.GetBytes("1234"),
                            OwnerId = appUser.Id,
                            WmGroupId = 1
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
                            WmObjectId = 1
                        },
                        new WmRecord()
                        {
                            Data = Encoding.ASCII.GetBytes("BQGsZ7LCluAAAAAAAAADAe5phOWe1mVAAgAAAAAAgEBAAwAAAEAzsz1A1f9Z"),
                            WmObjectId = 1
                        },
                        new WmRecord()
                        {
                            Data = Encoding.ASCII.GetBytes("BQGsZ7LCluAAAAAAAAADAe5phOWe1mVAAgAAAAAAgEBAAwAAAEAzsz1A1f9Z"),
                            WmObjectId = 3
                        },
                        new WmRecord()
                        {
                            Data = Encoding.ASCII.GetBytes("BQGsZ7LCluAAAAAAAAADAe5phOWe1mVAAgAAAAAAgEBAAwAAAEAzsz1A1f9Z"),
                            WmObjectId = 1
                        },
                        new WmRecord()
                        {
                            Data = Encoding.ASCII.GetBytes("BQGsZ7LCluAAAAAAAAADAe5phOWe1mVAAgAAAAAAgEBAAwAAAEAzsz1A1f9Z"),
                            WmObjectId = 2
                        },
                    });

                    context.SaveChanges();
                }

                // Records - TriggerWasteBinEmptying.
                if (!context.WmRecords_TriggerWasteBinEmptying.Any())
                {
                    context.WmRecords_TriggerWasteBinEmptying.AddRange(new List<WmRecord_TriggerWasteBinEmptying>()
                    {
                        new WmRecord_TriggerWasteBinEmptying(),
                        new WmRecord_TriggerWasteBinEmptying(),
                        new WmRecord_TriggerWasteBinEmptying()
                    });

                    context.SaveChanges();
                }

                // Records - TriggerWasteBinEmptying & Objects.
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

                // Users & Organizations.
                if (!context.AspNetUsers_WmOrganizations.Any())
                {
                    context.AspNetUsers_WmOrganizations.AddRange(new List<AspNetUser_WmOrganization>()
                    {
                        new AspNetUser_WmOrganization()
                        {
                            UserId = appUser.Id,
                            WmOrganizationId = 1
                        }
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
