using System;
using System.Collections.Generic;
// Using a class with static members makes the code a little shorter to
// read and write. We can just say AppSettings[] instead of
// ConfigurationManager.AppSettings[]
using static System.Configuration.ConfigurationManager;
using System.Linq;
using System.Web;

namespace WebApp.Admin.Security
{
    /// <summary>
    /// A collection of application-wide settings that provide values
    /// for security roles which have been set in the web.config's
    /// <appSettings /> section.
    /// </summary>
    internal static class Settings // There is no need to instantiate this
    {
        #region Security Roles
        public static string AdminRole => AppSettings["adminRole"];
        /* The above is the same as typing:
         * public static string AdminRole
         * {
         *      get { return ConfigurationManager.AppSettings["adminRole"];
         * }
         */
        public static string UserRole => AppSettings["userRole"];

        public static IEnumerable<string> DefaultSecurityRoles =>
            new List<string> { AdminRole, UserRole };
        #endregion

        #region Startup Users
        public static string AdminUserName => AppSettings["adminUserName"];
        public static string AdminPassword => AppSettings["adminPassword"];
        public static string AdminEmail => AppSettings["adminEmail"];
        public static string TempPassword => AppSettings["temporaryUserPassword"];
        #endregion
    }
}