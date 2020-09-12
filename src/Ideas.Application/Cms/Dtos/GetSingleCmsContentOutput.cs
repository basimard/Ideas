using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace Ideas.Cms.Dtos
{
    [AutoMapFrom(typeof(CmsContent))]
    public class GetSingleCmsContentOutput : FullAuditedEntityDto<int>
    {
        public string PageTitle { get; set; }

        public string PageContent { get; set; }
    }
}
