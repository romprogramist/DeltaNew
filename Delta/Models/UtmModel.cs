namespace Delta.Models;

public class UtmModel
{
    public string Source { get; set; } = string.Empty;
    public string Medium { get; set; } = string.Empty;
    public string Campaign { get; set; } = string.Empty;

    public string GetUtmString() =>
        !string.IsNullOrEmpty(Source) ? $"{Source}.{(string.IsNullOrEmpty(Medium) ? "-" : Medium)}.{(string.IsNullOrEmpty(Campaign) ? "-" : Campaign)}" : string.Empty;
}