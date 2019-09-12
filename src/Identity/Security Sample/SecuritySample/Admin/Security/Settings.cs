using System;
using System.Configuration;
using System.Linq;

// You can learn about Database Initialization Strategies in EF6 via
// http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx

namespace SecuritySample.Admin.Security
{
    /// <summary>
    /// A collection of application wide settings that provide values which
    /// have been set in the web.config's <appSettings /> section.
    /// </summary>
    public static class Settings
    {
        public static string AdminRole => ConfigurationManager.AppSettings["adminRole"];

        public static string CustomerRole
        { get { return ConfigurationManager.AppSettings["customerRole"]; } }
        public static string EmployeeRole
        { get { return ConfigurationManager.AppSettings["employeeRole"]; } }
        public static string SupplierRole
        { get { return ConfigurationManager.AppSettings["supplierRole"]; } }
    }
}