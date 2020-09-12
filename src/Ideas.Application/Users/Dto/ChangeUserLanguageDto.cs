using System.ComponentModel.DataAnnotations;

namespace Ideas.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}