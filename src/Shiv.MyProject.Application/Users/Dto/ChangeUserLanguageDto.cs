using System.ComponentModel.DataAnnotations;

namespace Shiv.MyProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}