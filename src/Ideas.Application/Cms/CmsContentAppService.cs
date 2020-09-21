using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Ideas.Authorization;
using Ideas.Cms.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ideas.Cms
{
    /**
     * Service Content Managment
     * @author:Basim E
     */
    [AbpAuthorize(PermissionNames.Pages_Cms)]
    public class CmsContentAppService : IdeasAppServiceBase, ICmsContentAppService

    {
        private readonly IRepository<CmsContent, int> _cmsContentRepository;
        private readonly ICmsContentManager _cmsContentManager;

        public CmsContentAppService(IRepository<CmsContent, int> cmsContentRepository,
                       ICmsContentManager cmsContentManager)
        {
            _cmsContentRepository = cmsContentRepository;
            _cmsContentManager = cmsContentManager;


        }

        public async Task<ListResultDto<ListAllCmsContentDto>> GetAll()
        {
            var pages = await _cmsContentRepository.GetAll().ToListAsync();

            if (pages == null)
            {
                throw new UserFriendlyException("Could not found any pages.");
            }

            return new ListResultDto<ListAllCmsContentDto>(pages.MapTo<List<ListAllCmsContentDto>>());
        }

        public async Task<GetSingleCmsContentOutput> GetCMSContent(EntityDto<int> input)
        {
            var @page = await _cmsContentRepository
              .GetAsync(input.Id);
            if (@page == null)
            {
                throw new UserFriendlyException("Could not found the page");
            }

            return @page.MapTo<GetSingleCmsContentOutput>();

        }

        public async Task<GetSingleCmsContentOutput> InsertOrUpdateCMSContent(InsertOrUpdateCmsInput input)
        {
            CmsContent content = new CmsContent();

            var @page = CmsContent.Create(AbpSession.GetTenantId(), (int)input.Id, input.PageTitle, input.PageContent);

            if (input.Id != 0)
            {

                content = await _cmsContentManager.UpdateAsync(@page);


            }
            else
            {

                content = await _cmsContentManager.CreatAsync(@page);


            }

            return content.MapTo<GetSingleCmsContentOutput>();
        }

    }

}
