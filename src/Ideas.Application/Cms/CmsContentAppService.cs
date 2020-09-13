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

namespace Ideas.Cms
{
    /**
     * Service Content Managment
     * @author:Basim E
     */
    public class CmsContentAppService : IdeasAppServiceBase, ICmsContentAppService
    {
        private readonly IRepository<CmsContent, int> _cmsContentRepository;
        private readonly ICmsContentManager _cmsContentManager;
        private readonly IAbpSession _session;
        public CmsContentAppService(IRepository<CmsContent, int> cmsContentRepository,
                       ICmsContentManager cmsContentManager, IAbpSession session)
        {
            _cmsContentRepository = cmsContentRepository;
            _cmsContentManager = cmsContentManager;
            _session = session;

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


            var @page = content.Create(1, input.PageTitle, input.PageContent);

            if (input.Id.HasValue)
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
