using System.ComponentModel.DataAnnotations;
namespace Delta.Models;

public class ReagentModel
{
    public int Id { get; set; }
    
    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Заполните поле {0}.")]
    public string Name { get; set; } = string.Empty;
    
    [Display(Name = "Id Компании")]
    public int CompanyId { get; set; }
}