using System.ComponentModel.DataAnnotations;

namespace Delta.Models;

public class ApplicationModel
{
    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    public string Name { get; set; } = string.Empty;
    
    [Display(Name = "Телефон")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    [RegularExpression(@"^\+7 \((?:[0-9] ?){3}\) (?:[0-9] ?){3}\-(?:[0-9] ?){2}\-(?:[0-9] ?){2}$",ErrorMessage = "Поле {0} не содержит допустимый номер телефона.")]
    public string Phone { get; set; } = string.Empty;
    
    public string UtmInfo { get; set; } = string.Empty;
    public string SitePage { get; set; } = string.Empty;
    public string AdditionalInfo { get; set; } = string.Empty;
}