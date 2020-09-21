using System.ComponentModel.DataAnnotations;

namespace Ideas.Cms.Dtos
{
    public class InsertOrUpdateCmsInput
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(CmsContent.MaxTitleLength, MinimumLength = CmsContent.MinTitleLength)]
        public string PageTitle { get; set; }

        [StringLength(CmsContent.MaxDescriptionLength, MinimumLength = CmsContent.MinDescriptionLength)]
        public string PageContent { get; set; }
    }
}
