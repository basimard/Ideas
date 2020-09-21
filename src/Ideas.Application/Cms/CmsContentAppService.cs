using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Runtime.Session;
using Ideas.Cms.Dtos;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using Ideas.Sessions;
using Abp.Authorization;
using Ideas.Authorization;

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

            var @page =  CmsContent.Create(1, (int)input.Id,input.PageTitle, input.PageContent);

            if (input.Id!=0)
            {

                content = await _cmsContentManager.UpdateAsync(@page);
              

            }
            else
            {

                var id = await _cmsContentManager.CreatAsync(@page);
                await UnitOfWorkManager.Current.SaveChangesAsync();
                content = await _cmsContentManager.GetAsync(id);
              

            }

            return content.MapTo<GetSingleCmsContentOutput>();
        }

    }

}
