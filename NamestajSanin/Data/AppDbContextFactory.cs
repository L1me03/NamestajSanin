using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NamestajSanin.Data;

namespace NamestajSanin
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            var connectionString = "Server=mariadb;Port=3306;Database=namestajdb;User=root;Password=lozinka;";
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            optionsBuilder.UseMySql(connectionString, serverVersion);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
