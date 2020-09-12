using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Ideas.Configuration;
using Ideas.Web;

namespace Ideas.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class IdeasDbContextFactory : IDesignTimeDbContextFactory<IdeasDbContext>
    {
        public IdeasDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IdeasDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            IdeasDbContextConfigurer.Configure(builder, configuration.GetConnectionString(IdeasConsts.ConnectionStringName));

            return new IdeasDbContext(builder.Options);
        }
    }
}
