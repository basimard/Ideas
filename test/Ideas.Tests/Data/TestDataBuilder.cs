using Ideas.Cms;
using Ideas.EntityFrameworkCore;
using Ideas.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ideas.Tests.Data
{
    public class TestDataBuilder
    {
        
        private readonly IdeasDbContext _context;

        public TestDataBuilder(IdeasDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateTestPost();
        }

        private void CreateTestPost()
        {
           
            var defaultTenant = _context.Tenants.Single(t => t.TenancyName == Tenant.DefaultTenantName);
            _context.CmsContents.AddRange(CmsContent.Create(defaultTenant.Id, 0,"Test Title 1", "Test Desc 1"),
                CmsContent.Create(defaultTenant.Id, 0, "Test Title 2", "Test Desc 2"),
                CmsContent.Create(defaultTenant.Id, 0, "Test Title 3", "Test Desc 3"));
            _context.SaveChanges();
        }
    }
}
