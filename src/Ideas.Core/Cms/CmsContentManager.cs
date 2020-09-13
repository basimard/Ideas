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

   
        public async Task<CmsContent> CreatAsync(CmsContent input)
        {
            
           var id = await _cmsRepository.InsertAndGetIdAsync(input);
           var content  = await GetAsync(id);
            return content;
        }
     
        public async Task<CmsContent> UpdateAsync(CmsContent input)
        {
           
                await _cmsRepository.UpdateAsync(input);
                var updatedContent = await GetAsync(input.Id);
                return updatedContent;
           
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
