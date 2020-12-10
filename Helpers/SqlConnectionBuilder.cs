using Microsoft.Extensions.Configuration;

namespace UserService.Helpers
{
    public class SqlConnectionBuilder 
    {

        public string build(IConfiguration  configuration)
        {
            var password = configuration["DbPassword"];
            var userID = configuration["DBUser"] ?? "sa";
            var dbServer = configuration["DBSERVER"] ?? "localhost";
            var dbPort = configuration["DBPORT"] ?? "1433";
            var database = configuration["DBCatalog"] ?? "UserDb";
            return $"Server={dbServer},{dbPort};Initial Catalog={database};User ID={userID};Password={password}";
        }
    }
}