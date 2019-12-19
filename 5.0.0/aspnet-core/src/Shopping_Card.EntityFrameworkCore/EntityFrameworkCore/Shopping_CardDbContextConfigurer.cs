using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Shopping_Card.EntityFrameworkCore
{
    public static class Shopping_CardDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Shopping_CardDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Shopping_CardDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
