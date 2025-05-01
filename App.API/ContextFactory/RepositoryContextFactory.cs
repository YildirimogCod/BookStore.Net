using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository.EfCore;

namespace App.API.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(configuration.GetConnectionString("SqlServer"),p => p.MigrationsAssembly("App.API"));
            return new AppDbContext(builder.Options);
        }
    }
}
