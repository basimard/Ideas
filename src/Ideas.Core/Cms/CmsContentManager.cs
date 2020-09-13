using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ideas.Cms
{
    /**
     * CMS Page Management 
     * @author: Basim E
     */
    public class CmsContentManager : ICmsContentManager
    {
        private readonly IRepository<CmsContent, int> _cmsRepository;

        public CmsContentManager(IRepository<CmsContent, int> pageRepository)
        {
            _cmsRepository = pageRepository;

        }
        public async Task<CmsContent> CreateOrUpdateAsync(CmsContent @page)
        {
            var insertOrUpdate = await _cmsRepository.InsertOrUpdateAsync(@page);
            
            return insertOrUpdate;
        }


        public async Task<CmsContent> CreatAsync(CmsContent input)
        {

            var cmscontent = await _cmsRepository.InsertAsync(input);

            return cmscontent;
        }

        public async Task<CmsContent> UpdateAsync(CmsContent input)
        {
            var cmsContent = await _cmsRepository.FirstOrDefaultAsync(input.Id);

            return cmsContent;

        }
        public async Task<List<CmsContent>> GetAllAsync()
        {
            var @pages = await _cmsRepository.GetAllListAsync();
            if (@pages == null)
            {
                throw new UserFriendlyException("Could not found any pages");
            }

            return @pages;
        }

        public async Task<CmsContent> GetAsync(int id)
        {
            var @page = await _cmsRepository.FirstOrDefaultAsync(id);
            if (@page == null)
            {
                throw new UserFriendlyException("Could not found the page");
            }

            return @page;
        }


    }
}
