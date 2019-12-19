using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Shopping_Card.Configuration;
using Shopping_Card.Web;

namespace Shopping_Card.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class Shopping_CardDbContextFactory : IDesignTimeDbContextFactory<Shopping_CardDbContext>
    {
        public Shopping_CardDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Shopping_CardDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            Shopping_CardDbContextConfigurer.Configure(builder, configuration.GetConnectionString(Shopping_CardConsts.ConnectionStringName));

            return new Shopping_CardDbContext(builder.Options);
        }
    }
}
