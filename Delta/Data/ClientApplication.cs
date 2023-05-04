namespace Delta.Data;

public class ClientApplication
{
    public int Id { get; set; }
    public DateTime CreationDateTime { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string SitePage { get; set; } = string.Empty;
    public string AdditionalInfo { get; set; } = string.Empty;
    public string UtmInfo { get; set; } = string.Empty;
}