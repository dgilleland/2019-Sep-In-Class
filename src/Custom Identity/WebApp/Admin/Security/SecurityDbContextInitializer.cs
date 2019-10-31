using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

// You can learn about Database Initialization Strategies in EF6 via
// http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx

namespace WebApp.Admin.Security
{
    /// <summary>
    /// Provide functionality for setting up the database for the ApplicationDbContext.
    /// The specific functionality is to create the database if it does not exist.
    /// </summary>
    public class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // To "seed" a database is to provide it with some initial data
            // when the database is created.

            #region Seed the security roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            // The RoleManager<T> and RoleStore<T> are BLL classes that give flexibility
            // to the design/structure of how we're using Asp.Net Identity.
            // The IdentityRole is an Entity class that represents a security role.

            // Hard-coded security roles (move later on)
            roleManager.Create(new IdentityRole { Name = "Administrators" });
            roleManager.Create(new IdentityRole { Name = "Registered Users" });
            #endregion

            #region Seed the users
            // Create a user
            var adminUser = new ApplicationUser
            {
                UserName = "WebAdmin",
                Email = "Fake@Hackers.ru",
                EmailConfirmed = true
            };

            // Get the BLL user manager
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            // - The ApplicationUserManager is a BLL class in the IdentityConfig.cs file
            var result = userManager.Create(adminUser, "Pa$$w0rd");
            if(result.Succeeded)
            {
                // Get the Id that was generated for the user we created/added
                var found = userManager.FindByName("WebAdmin").Id;
                // Add the user to the Administrators role
                userManager.AddToRole(found, "Administrators");
            }
            #endregion

            // Keep the call to the base class to do its seeding work
            base.Seed(context);
        }
    }
}