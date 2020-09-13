using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ideas.Cms
{
    /**
     * COntent Managment Entity
     * @author: Basim E
     * */
    public class CmsContent : FullAuditedEntity<int>, IMustHaveTenant
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;


        public virtual int TenantId { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public string PageTitle { get; set; }

        [Required]
        [StringLength(MaxDescriptionLength)]
        public string PageContent { get; set; }

        public CmsContent Create(int tenantId, string pageTitle, string pageContent = null)
        {
            var @page = new CmsContent
            {
                TenantId = tenantId,
                PageTitle = pageTitle,
                PageContent = pageContent

            };

            return @page;
        }
    }
}
