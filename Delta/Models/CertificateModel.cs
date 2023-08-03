using System.ComponentModel.DataAnnotations;

namespace Delta.Models;

public class CertificateModel
{
    public int Id { get; set; }
    
    [Display(Name = "Pdf")]
    public string Pdf { get; set; } = string.Empty;
    
    [Display(Name = "Картинка")]
    public string Image { get; set; } = string.Empty;
}