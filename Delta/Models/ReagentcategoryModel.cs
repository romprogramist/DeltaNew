using System.ComponentModel.DataAnnotations;

namespace Delta.Models;

public class ReagentcategoryModel
{
    public int Id { get; set; }
    
    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    
    public string Name { get; set; } = string.Empty;
    
}