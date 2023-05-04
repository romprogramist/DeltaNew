using System.ComponentModel.DataAnnotations;

namespace Delta.Models;

public class ReviewModel
{
    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    public string Name { get; set; } = string.Empty;
    
    [Display(Name = "Телефон")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    [RegularExpression(@"^\+7 \((?:[0-9] ?){3}\) (?:[0-9] ?){3}\-(?:[0-9] ?){2}\-(?:[0-9] ?){2}$",ErrorMessage = "Поле {0} не содержит допустимый номер телефона.")]
    public string Phone { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "Поле {0} заполнено некорректно.")]
    [Display(Name = "e-mail")]
    public string Email { get; set; } = string.Empty;
    
    [Display(Name = "Текст отзыва")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    public string Text { get; set; } = string.Empty;

    [Display(Name = "Оценка")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    [Range(0,9,ErrorMessage = "Значение поля {0} должно быть в пределах от 0 до 9.")]
    public int Rate { get; set; }
    public string UtmInfo { get; set; } = string.Empty;
    public string SitePage { get; set; } = string.Empty;
    public string AdditionalInfo { get; set; } = string.Empty;
    public bool IsApproved { get; set; }
}