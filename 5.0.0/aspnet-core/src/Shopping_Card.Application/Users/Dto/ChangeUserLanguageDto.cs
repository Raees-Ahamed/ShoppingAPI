using System.ComponentModel.DataAnnotations;

namespace Shopping_Card.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}