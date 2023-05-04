namespace Delta.Data;

public class Review
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreationDateTime { get; set; }
    public string UtmInfo { get; set; } = string.Empty;
    public string SitePage { get; set; } = string.Empty;
    public string AdditionalInfo { get; set; } = string.Empty;
    public bool IsApproved { get; set; }

    public int Rate { get; set; }
}