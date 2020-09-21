using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using System.Collections.Generic;
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
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public CmsContentManager(IRepository<CmsContent, int> pageRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _cmsRepository = pageRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }


        public async Task<CmsContent> CreatAsync(CmsContent input)
        {

            var content = await _cmsRepository.InsertAsync(input);
            await _unitOfWorkManager.Current.SaveChangesAsync();

            return content;
        }

        public async Task<CmsContent> UpdateAsync(CmsContent input)
        {

            var content = await _cmsRepository.UpdateAsync(input);

            return content;

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
