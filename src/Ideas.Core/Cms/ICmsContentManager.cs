using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ideas.Cms
{
    public interface ICmsContentManager : IDomainService
    {
        Task<CmsContent> GetAsync(int id);

        Task<CmsContent> CreatAsync(CmsContent @page);

        Task<CmsContent> UpdateAsync(CmsContent @page);

        Task<List<CmsContent>> GetAllAsync();
    }
}
