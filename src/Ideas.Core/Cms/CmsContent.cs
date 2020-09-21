using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Ideas.Cms
{
    /**
     * COntent Managment Entity
     * @author: Basim E
     * */
    public class CmsContent : FullAuditedEntity<int>, IMustHaveTenant
    {
        public const int MaxTitleLength = 100;
        public const int MaxDescriptionLength = 2000;
        public const int MinTitleLength = 2;
        public const int MinDescriptionLength = 10;
        public virtual int TenantId { get; set; }

        [Required]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string PageTitle { get; protected set; }

        [Required]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength)]
        public string PageContent { get; protected set; }

        public CmsContent()
        {

        }
        public static CmsContent Create(int tenantId, int id, string pageTitle, string pageContent = null)
        {
            var @page = new CmsContent
            {
                Id = id,
                TenantId = tenantId,
                PageTitle = pageTitle,
                PageContent = pageContent

            };



            return @page;
        }
    }
}
