using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ideas.Cms.Dtos
{
    public class InsertOrUpdateCmsInput
    {
        [Required]
        [StringLength(CmsContent.MaxTitleLength)]
        public string PageTitle { get; set; }

        [StringLength(CmsContent.MaxDescriptionLength)]
        public string PageContent { get; set; }
    }
}
