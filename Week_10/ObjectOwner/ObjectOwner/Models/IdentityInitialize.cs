﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// added...
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using ObjectOwner.Controllers;

namespace ObjectOwner.Models
{
    public static class IdentityInitialize
    {
        // Load user accounts
        public static async void LoadUserAccounts()
        {
            // Get a reference to the objects we need
            var ds = new ApplicationDbContext();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(ds));

            // Add the user(s) that the app needs when loaded for the first time
            // Change any of the data below to better match your app's needs
            if (userManager.Users.Count() == 0)
            {
                // User account manager...
                var uam = new ApplicationUser { UserName = "uam@example.com", Email = "uam@example.com" };
                var uamResult = await userManager.CreateAsync(uam, "Password123!");
                if (uamResult.Succeeded)
                {
                    // Add claims
                    await userManager.AddClaimAsync(uam.Id, new Claim(ClaimTypes.Email, "uam@example.com"));
                    await userManager.AddClaimAsync(uam.Id, new Claim(ClaimTypes.Role, "UserAccountManager"));
                    await userManager.AddClaimAsync(uam.Id, new Claim(ClaimTypes.GivenName, "User Account"));
                    await userManager.AddClaimAsync(uam.Id, new Claim(ClaimTypes.Surname, "Manager"));
                }

                // Developer/programmer...
                var dev = new ApplicationUser { UserName = "dev@example.com", Email = "dev@example.com" };
                var devResult = await userManager.CreateAsync(dev, "Password123!");
                if (devResult.Succeeded)
                {
                    // Add claims
                    await userManager.AddClaimAsync(dev.Id, new Claim(ClaimTypes.Email, "dev@example.com"));
                    await userManager.AddClaimAsync(dev.Id, new Claim(ClaimTypes.Role, "Developer"));
                    await userManager.AddClaimAsync(dev.Id, new Claim(ClaimTypes.GivenName, "App"));
                    await userManager.AddClaimAsync(dev.Id, new Claim(ClaimTypes.Surname, "Developer"));
                }

                // Attention - 1 - Programmatically add a new user account
                // The student...
                var stu = new ApplicationUser { UserName = "student@example.com", Email = "student@example.com" };
                var stuResult = await userManager.CreateAsync(stu, "Password123!");
                if (stuResult.Succeeded)
                {
                    // Add claims
                    await userManager.AddClaimAsync(stu.Id, new Claim(ClaimTypes.Email, "student@example.com"));
                    await userManager.AddClaimAsync(stu.Id, new Claim(ClaimTypes.Role, "Developer"));
                    await userManager.AddClaimAsync(stu.Id, new Claim(ClaimTypes.GivenName, "Web Services"));
                    await userManager.AddClaimAsync(stu.Id, new Claim(ClaimTypes.Surname, "Student"));
                }
            }
        }

        // Load app claims
        // Initial claims... OU
        // Finance, AandR, Clerical, Manufacturing, Marketing
        // Initial claims... Task
        // ArtistEdit, AlbumEdit, DataAdmin, CustomerView, CustomerEdit

        public static void LoadAppClaims()
        {
            // Get a reference to the manager
            Manager m = new Manager();

            // If there are no claims, add them
        }
    }
}
