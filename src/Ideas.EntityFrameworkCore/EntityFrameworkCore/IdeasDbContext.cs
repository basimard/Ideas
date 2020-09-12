using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Ideas.Authorization.Roles;
using Ideas.Authorization.Users;
using Ideas.MultiTenancy;
using Ideas.Cms;

namespace Ideas.EntityFrameworkCore
{
    public class IdeasDbContext : AbpZeroDbContext<Tenant, Role, User, IdeasDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<CmsContent> CmsContents { get; set; }
        public IdeasDbContext(DbContextOptions<IdeasDbContext> options)
            : base(options)
        {
        }
    }
}
