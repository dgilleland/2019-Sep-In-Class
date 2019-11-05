using System;
using System.Collections.Generic;
using static System.Configuration.ConfigurationManager;
using System.Linq;
using System.Web;

namespace WebApp.Admin.Security
{
    public static class Settings
    {
        #region Security Roles
        public static string AdminRole => AppSettings["adminRole"];
        /* The above is the same as typing:
         * public static string AdminRole
         * {
         *    get { return ConfigurationManager.AppSettings["adminRole"]; }
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