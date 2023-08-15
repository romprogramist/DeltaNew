namespace Delta.Models.Dtos;

public class ReagentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string InstructionPdf { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = null!;
}