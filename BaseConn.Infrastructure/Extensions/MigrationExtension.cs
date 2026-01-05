
using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseConn.Infrastructure.Extensions
{
    public static class MigrationExtension
    {



        public static void RunSqlScript(this MigrationBuilder migrationBuilder, string script)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith($"{script}.sql"));
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            var sqlResult = reader.ReadToEnd();
            migrationBuilder.Sql(sqlResult);
        }

    }
}