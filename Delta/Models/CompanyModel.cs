using System.ComponentModel.DataAnnotations;

namespace Delta.Models;

public class CompanyModel
{
    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    
    public string Name { get; set; } = string.Empty;
    
    [Display(Name = "Описание")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    
    public string Description { get; set; } = string.Empty;
    
    [Display(Name = "Картинка")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    
    public string iFormFile { get; set; } = string.Empty;
}