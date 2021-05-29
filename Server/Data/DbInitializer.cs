using Workings.Shared;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Workings.Server.Models;

namespace Workings.Server.Data
{
    public class DbInitializer
    {
        public static void Initialise(ApplicationDbContext context)
        {
            // Look for any blind profiles.
            if (context.BlindProfiles.Any())
            {
                return; // DB has been seeded
            }

            SeedUsers(context);
            SeedBusinessClients(context);
            SeedBlindRailings(context);
            SeedBlindRods(context);
            SeedBlindStacks(context);
            SeedBlindBottomBars(context);
            SeedBlindLinings(context);
            SeedBlindProfiles(context);
        }

        private static void SeedUsers(ApplicationDbContext context)
        {
            var user = new ApplicationUser
            {
                UserName = "test@test.com",
                Email = "test@test.com",
                EmailConfirmed = true
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Password123!");

            context.Users.Add(user);
            context.SaveChanges();
        }

        private static void SeedBusinessClients(ApplicationDbContext context)
        {
            var businessClients = new[]
            {
                new BusinessClient
                {
                    Name = "Business Client 1"
                },
                new BusinessClient
                {
                    Name = "Business Client 2"
                },
                new BusinessClient
                {
                    Name = "Business Client 3"
                }
            };

            context.BusinessClients.AddRange(businessClients);
            context.SaveChanges();
        }

        private static void SeedBlindRailings(ApplicationDbContext context)
        {
            var blindRailings = new[]
            {
                new BlindRailing
                {
                    Name = "Blind Railing 1",
                    Height = 1
                },
                new BlindRailing
                {
                    Name = "Blind Railing 2",
                    Height = 2
                },
                new BlindRailing
                {
                    Name = "Blind Railing 3",
                    Height = 3
                }
            };

            context.BlindRailings.AddRange(blindRailings);
            context.SaveChanges();
        }

        private static void SeedBlindRods(ApplicationDbContext context)
        {
            var blindRods = new[]
            {
                new BlindRod
                {
                    Name = "Blind Rod 1",
                    Height = 1
                },
                new BlindRod
                {
                    Name = "Blind Rod 2",
                    Height = 2
                },
                new BlindRod
                {
                    Name = "Blind Rod 3",
                    Height = 3
                }
            };

            context.BlindRods.AddRange(blindRods);
            context.SaveChanges();
        }

        private static void SeedBlindStacks(ApplicationDbContext context)
        {
            var blindStacks = new[]
            {
                new BlindStack
                {
                    Name = "Blind Stack 1",
                    Type = BlindStackType.Normal,
                    Offset = 1
                },
                new BlindStack
                {
                    Name = "Blind Stack 2",
                    Type = BlindStackType.Waterfall,
                    Offset = 2
                },
                new BlindStack
                {
                    Name = "Blind Stack 3",
                    Type = BlindStackType.Reveal,
                    Offset = 3
                }
            };

            context.BlindStacks.AddRange(blindStacks);
            context.SaveChanges();
        }

        private static void SeedBlindBottomBars(ApplicationDbContext context)
        {
            var blindBottomBars = new[]
            {
                new BlindBottomBar
                {
                    Name = "Blind Bottom Bar 1",
                    Height = 1
                },
                new BlindBottomBar
                {
                    Name = "Blind Bottom Bar 2",
                    Height = 2
                },
                new BlindBottomBar
                {
                    Name = "Blind Bottom Bar 3",
                    Height = 3
                }
            };

            context.BlindBottomBars.AddRange(blindBottomBars);
            context.SaveChanges();
        }

        private static void SeedBlindLinings(ApplicationDbContext context)
        {
            var blindLinings = new[]
            {
                new BlindLining
                {
                    Name = "Blind Lining 1",
                    IsInner = false
                },
                new BlindLining
                {
                    Name = "Blind Lining 2",
                    IsInner = false
                },
                new BlindLining
                {
                    Name = "Blind Lining 3",
                    IsInner = false
                }
            };

            context.BlindLinings.AddRange(blindLinings);
            context.SaveChanges();
        }

        private static void SeedBlindProfiles(ApplicationDbContext context)
        {
            var blindProfiles = new[]
            {
                new BlindProfile
                {
                    Name = "Blind Profile 1",
                    BusinessClient =
                        context.BusinessClients.FirstOrDefault(client => client.Name == "Business Client 1"),
                    BlindRailing =
                        context.BlindRailings.FirstOrDefault(railing => railing.Name == "Blind Railing 1"),
                    BlindRod =
                        context.BlindRods.FirstOrDefault(rod => rod.Name == "Blind Rod 1"),
                    BlindStack =
                        context.BlindStacks.FirstOrDefault(stack => stack.Name == "Blind Stack 1"),
                    BlindBottomBar =
                        context.BlindBottomBars.FirstOrDefault(bottomBar => bottomBar.Name == "Blind Bottom Bar 1")
                },
                new BlindProfile
                {
                    Name = "Blind Profile 2",
                    BusinessClient =
                        context.BusinessClients.FirstOrDefault(client => client.Name == "Business Client 2"),
                    BlindRailing =
                        context.BlindRailings.FirstOrDefault(railing => railing.Name == "Blind Railing 2"),
                    BlindRod =
                        context.BlindRods.FirstOrDefault(rod => rod.Name == "Blind Rod 2"),
                    BlindStack =
                        context.BlindStacks.FirstOrDefault(stack => stack.Name == "Blind Stack 2"),
                    BlindBottomBar =
                        context.BlindBottomBars.FirstOrDefault(bottomBar => bottomBar.Name == "Blind Bottom Bar 2")
                },
                new BlindProfile
                {
                    Name = "Blind Profile 3",
                    BusinessClient =
                        context.BusinessClients.FirstOrDefault(client => client.Name == "Business Client 3"),
                    BlindRailing =
                        context.BlindRailings.FirstOrDefault(railing => railing.Name == "Blind Railing 3"),
                    BlindRod =
                        context.BlindRods.FirstOrDefault(rod => rod.Name == "Blind Rod 3"),
                    BlindStack =
                        context.BlindStacks.FirstOrDefault(stack => stack.Name == "Blind Stack 3"),
                    BlindBottomBar =
                        context.BlindBottomBars.FirstOrDefault(bottomBar => bottomBar.Name == "Blind Bottom Bar 3")
                }
            };

            try
            {
                context.BlindProfiles.AddRange(blindProfiles);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}