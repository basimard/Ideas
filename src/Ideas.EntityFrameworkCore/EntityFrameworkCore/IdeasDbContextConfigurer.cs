using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Ideas.EntityFrameworkCore
{
    public static class IdeasDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IdeasDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IdeasDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
